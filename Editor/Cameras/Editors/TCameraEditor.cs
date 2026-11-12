using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;
    using VisualScript.Editor.Characters;

    [CustomEditor(typeof(TCamera), true)]
    public class TCameraEditor : UnityEditor.Editor
    {
        // CREATE INSPECTOR: ----------------------------------------------------------------------

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();

            SerializedProperty timeMode = this.serializedObject.FindProperty("m_TimeMode");
            SerializedProperty runIn = this.serializedObject.FindProperty("m_RunIn");
            
            PropertyField fieldTimeMode = new PropertyField(timeMode);
            PropertyField fieldRunIn = new PropertyField(runIn);
            
            root.Add(fieldTimeMode);
            root.Add(fieldRunIn);
            
            SerializedProperty transition = this.serializedObject.FindProperty("m_Transition");
            PropertyField fieldTransition = new PropertyField(transition);
            
            root.Add(new SpaceSmall());
            root.Add(fieldTransition);
            
            SerializedProperty clip = this.serializedObject.FindProperty("m_Clip");
            PropertyElement fieldClip = new PropertyElement(clip, "Avoid Clip", false);
            
            root.Add(new SpaceSmall());
            root.Add(fieldClip);

            return root;
        }
        
        // CREATION MENU: -------------------------------------------------------------------------
        
        [MenuItem("GameObject/Visual Script/Cameras/Main Camera", false, 0)]
        private static void CreateElement(MenuCommand menuCommand)
        {
            GameObject instance = new GameObject("Main Camera");
            instance.tag = "MainCamera";
            
            instance.AddComponent<Camera>();
            instance.AddComponent<AudioListener>();
            instance.AddComponent<PhysicsRaycaster>();
            
            MainCamera mainCamera = instance.AddComponent<MainCamera>();

            ShotCamera candidateShot = FindAnyObjectByType<ShotCamera>();
            if (candidateShot != null)
            {
                SerializedObject mainCameraSerializedObject = new SerializedObject(mainCamera);
                mainCameraSerializedObject
                    .FindProperty("m_Transition")
                    .FindPropertyRelative("m_CurrentShotCamera")
                    .objectReferenceValue = candidateShot;
                
                mainCameraSerializedObject.ApplyModifiedPropertiesWithoutUndo();
            }

            GameObjectUtility.SetParentAndAlign(instance, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(instance, $"Create {instance.name}");
            Selection.activeObject = instance;
        }
    }
}
