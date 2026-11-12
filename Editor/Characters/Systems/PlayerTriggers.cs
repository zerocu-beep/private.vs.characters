using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using VisualScript.Runtime;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    /// <summary>
    /// Adds to a new Player the same Visual Script behaviours that Game Creator's Player prefab
    /// came with, each in its own child game object with a Visual Script Event component:
    /// OnDie, OnRevive, Jump, Interact, OnJump and OnLand.
    /// </summary>
    internal static class PlayerTriggers
    {
        private const string PATH_ANIMATIONS = RuntimePaths.CHARACTERS + "Assets/3D/Animations/Actions/";
        private const string PATH_JUMP_AIR = PATH_ANIMATIONS + "Human@Action_JumpAir.anim";
        private const string PATH_JUMP_LEFT = PATH_ANIMATIONS + "Human@Action_JumpGround_L.anim";
        private const string PATH_JUMP_RIGHT = PATH_ANIMATIONS + "Human@Action_JumpGround_R.anim";
        private const string PATH_FX_LAND = RuntimePaths.CHARACTERS + "Assets/Install/Particles/FX_Land.prefab";

        private const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public static void Create(Character character)
        {
            if (character == null) return;

            // one air jump (double jump), as Game Creator's Player prefab
            if (character.Kernel?.Motion != null)
            {
                character.Kernel.Motion.AirJumps = 1;
                EditorUtility.SetDirty(character);
            }

            // grouped as in Game Creator's Player prefab:
            // Interactions (input of the player) and Reactions (events of the character)
            Transform interactions = Group(character, "Interactions");
            Transform reactions = Group(character, "Reactions");

            // Space / Gamepad South -> exit if not controllable -> Jump
            Make(interactions, "Jump",
                new Trigger[] { KeyboardPress(Key.Space), GamepadPress(GamepadButton.South) },
                new Instruction[] { ExitIfNotControllable(), new InstructionCharacterNavigationJump() }
            );

            // E / Gamepad West -> exit if not controllable -> Interact
            Make(interactions, "Interact",
                new Trigger[] { KeyboardPress(Key.E), GamepadPress(GamepadButton.West) },
                new Instruction[] { ExitIfNotControllable(), new InstructionCharacterInteract() }
            );

            // On Die -> Start Ragdoll
            Make(reactions, "OnDie",
                new Trigger[] { new EventCharacterOnDie() },
                new Instruction[] { new InstructionCharacterStartRagdoll() }
            );

            // On Revive -> Recover Ragdoll
            Make(reactions, "OnRevive",
                new Trigger[] { new EventCharacterOnRevive() },
                new Instruction[] { new InstructionCharacterRecoverRagdoll() }
            );

            // On Jump -> jump gesture depending on the foot on the ground, or in the air
            Make(reactions, "OnJump",
                new Trigger[] { new EventCharacterOnJump() },
                new Instruction[]
                {
                    Branch(typeof(InstructionCoreConditionIf), new ConditionCharacterIsAirborne(), Gesture(PATH_JUMP_AIR)),
                    Branch(typeof(InstructionCoreConditionElseIf), Phase(0), Gesture(PATH_JUMP_LEFT)),
                    Branch(typeof(InstructionCoreConditionElseIf), Phase(1), Gesture(PATH_JUMP_RIGHT)),
                }
            );

            // On Land -> landing particles at the Character's feet (pooled)
            Make(reactions, "OnLand",
                new Trigger[] { new EventCharacterOnLand() },
                new Instruction[] { LandEffect() }
            );
        }

        // BUILDERS: ------------------------------------------------------------------------------

        private static Transform Group(Character character, string name)
        {
            GameObject group = new GameObject(name);
            group.transform.SetParent(character.transform, false);
            return group.transform;
        }

        private static void Make(Transform parent, string name, Trigger[] triggers, Instruction[] instructions)
        {
            GameObject instance = new GameObject(name);
            instance.transform.SetParent(parent, false);

            VisualScript.Runtime.Event component = instance.AddComponent<VisualScript.Runtime.Event>();
            Set(component, "m_Triggers", new Triggers(triggers));
            Set(component, "m_Instructions", new Instructions(instructions));

            EditorUtility.SetDirty(component);
        }

        private static Trigger KeyboardPress(Key key)
        {
            TriggerCoreInputKeyboardPress trigger = new TriggerCoreInputKeyboardPress();
            Set(trigger, "m_Key", key);
            return trigger;
        }

        private static Trigger GamepadPress(GamepadButton button)
        {
            TriggerCoreInputGamepadPress trigger = new TriggerCoreInputGamepadPress();
            Set(trigger, "m_Button", button);
            return trigger;
        }

        private static Instruction ExitIfNotControllable()
        {
            ConditionCharacterIsControllable isControllable = new ConditionCharacterIsControllable();
            Set(isControllable, "m_Sign", false);

            InstructionCoreReturn exit = new InstructionCoreReturn();
            Set(exit, "m_Conditions", new Conditions(isControllable));
            return exit;
        }

        private static Condition Phase(int limb)
        {
            ConditionCharacterPhase phase = new ConditionCharacterPhase();

            FieldInfo field = Field(phase.GetType(), "m_Phase");
            field?.SetValue(phase, Enum.ToObject(field.FieldType, limb));
            Set(phase, "m_IsGrounded", true);

            return phase;
        }

        private static Instruction Gesture(string clipPath)
        {
            AnimationClip clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(clipPath);

            InstructionCharacterGesture gesture = new InstructionCharacterGesture();
            Set(gesture, "m_AnimationClip", new GetAnimationClip(clip));
            Set(gesture, "m_TransitionIn", new GetNumber(0.1f));
            Set(gesture, "m_TransitionOut", new GetNumber(0.3f));
            Set(gesture, "m_WaitToComplete", false);

            return gesture;
        }

        private static Instruction Branch(Type branchType, Condition condition, Instruction instruction)
        {
            Instruction branch = (Instruction) Activator.CreateInstance(branchType);
            Set(branch, "m_Conditions", new Conditions(condition));
            Set(branch, "m_Instructions", new Instructions(instruction));
            return branch;
        }

        private static Instruction LandEffect()
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(PATH_FX_LAND);

            InstructionCoreGameObjectInstantiateFromPool instantiate = new InstructionCoreGameObjectInstantiateFromPool();
            Set(instantiate, "m_GameObject", new GetGameObject(new TypeGameObjectPrefab(prefab)));
            Set(instantiate, "m_Position", new GetVector3(new TypeVector3SourcePosition()));
            Set(instantiate, "m_Rotation", new GetQuaternion(new TypeQuaternionSourceRotation()));
            Set(instantiate, "m_PoolConfig", new PoolConfig(5, 5f));

            return instantiate;
        }

        // REFLECTION: ----------------------------------------------------------------------------

        private static FieldInfo Field(Type type, string name)
        {
            for (Type t = type; t != null; t = t.BaseType)
            {
                FieldInfo field = t.GetField(name, FLAGS | BindingFlags.DeclaredOnly);
                if (field != null) return field;
            }

            return null;
        }

        private static void Set(object target, string name, object value)
        {
            FieldInfo field = Field(target.GetType(), name);
            if (field == null)
            {
                Debug.LogWarning($"Player Triggers: field {name} not found in {target.GetType().Name}");
                return;
            }

            field.SetValue(target, value);
        }
    }
}
