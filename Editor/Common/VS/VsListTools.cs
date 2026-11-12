using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using VisualScript.Icons;
using VisualScript.Runtime;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;
    using VisualScript.Runtime.Characters.IK;

    // Lists of Character features drawn exactly like the lists of a Visual Script Event: a
    // Visual Script content list inside a Visual Script Box (the dark grey panel). Class names
    // and constructors are the ones the ported inspectors already use; the "Add ..." button
    // keeps Game Creator's text and icon, and every row shows the icon of its entry.

    internal static class VsListNames
    {
        private readonly struct Entry
        {
            public readonly string name;
            public readonly IIcon icon;

            public Entry(string name, IIcon icon)
            {
                this.name = name;
                this.icon = icon;
            }
        }

        // Visual Script computes the button text and icon while the list is being constructed,
        // so they come from a table keyed by the type of the entries.
        private static readonly Dictionary<Type, Entry> ENTRIES = new Dictionary<Type, Entry>
        {
            { typeof(TRig), new Entry("IK Rig Layer", new IconIK(ColorTheme.Type.TextLight)) },
            { typeof(Footstep), new Entry("Foot", new IconFootprint(ColorTheme.Type.TextLight)) },
            { typeof(IVolume), new Entry("Volume", new IconSkeleton(ColorTheme.Type.TextLight)) },
            { typeof(HandleItem), new Entry("Handle", new IconHandle(ColorTheme.Type.TextLight)) },
            { typeof(ReactionItem), new Entry("Reaction", new IconReaction(ColorTheme.Type.TextLight)) },
            { typeof(MaterialSoundTexture), new Entry("Material Sound", new IconTexture(ColorTheme.Type.TextLight)) },
            { typeof(VisualScript.Runtime.Hotspots.Spot), new Entry("Spot", new IconSpot(ColorTheme.Type.TextLight)) },
        };

        public static string Name(Type type) =>
            type != null && ENTRIES.TryGetValue(type, out Entry entry) ? entry.name : null;

        public static Texture Icon(Type type) =>
            type != null && ENTRIES.TryGetValue(type, out Entry entry) ? entry.icon.Texture : null;
    }

    /// <summary>
    /// A list entry like the ones of Visual Script's Triggers, Instructions and Conditions: no
    /// fold arrow, it opens by clicking its title.
    /// </summary>
    public class VsListItem : ContentListItemProperty
    {
        protected override bool DisplayFolding => false;

        public VsListItem(BaseContentListFieldPropertyAdd list) : base(list)
        { }
    }

    /// <summary>A list where each entry can be of a different type (chosen with the VS selector).</summary>
    public class VsPolymorphicList : ContentListFieldProperty
    {
        // right-click menu of the entries, as in the Event lists
        public override bool HasContextMenu => true;
        public override bool AllowCopy => true;
        public override bool AllowPaste => true;
        public override bool AllowDuplicate => true;
        public override bool AllowInsert => true;
        public override bool AllowExpand => true;
        public override bool AllowHelp => true;

        protected override BaseContentListItemProperty MakeListItem() => new VsListItem(this);

        protected override string CalculateBaseName => VsListNames.Name(this.BaseType) ?? base.CalculateBaseName;
        protected override Texture CalculateBaseImage => VsListNames.Icon(this.BaseType) ?? base.CalculateBaseImage;

        public VsPolymorphicList(SerializedProperty array, Type baseType)
            : base(array, baseType, true, true)
        { }
    }

    /// <summary>
    /// Same list whose entries can be disabled, only where Game Creator allowed it and the
    /// runtime skips disabled entries (IK rigs, Hotspot spots). A type, not a constructor
    /// argument: Visual Script reads it while the base constructor builds the rows.
    /// </summary>
    public class VsPolymorphicDisableList : VsPolymorphicList
    {
        public override bool AllowDisable => true;

        public VsPolymorphicDisableList(SerializedProperty array, Type baseType)
            : base(array, baseType)
        { }
    }

    /// <summary>A list where every entry is of the same type (added directly), with row icons.</summary>
    public class VsSingleList : ContentSingleListFieldProperty
    {
        public override bool HeadHasIcon => true;

        // same menu, without Replace / Insert: every entry is of the same type
        public override bool HasContextMenu => true;
        public override bool AllowCopy => true;
        public override bool AllowPaste => true;
        public override bool AllowDuplicate => true;
        public override bool AllowExpand => true;
        public override bool AllowHelp => true;

        protected override BaseContentListItemProperty MakeListItem() => new VsListItem(this);

        protected override string CalculateBaseName => VsListNames.Name(this.BaseType) ?? base.CalculateBaseName;
        protected override Texture CalculateBaseImage => VsListNames.Icon(this.BaseType) ?? base.CalculateBaseImage;

        public VsSingleList(SerializedProperty array, Type type)
            : base(array, type, true)
        { }
    }

    /// <summary>A list inside a Visual Script Box, as in the Event inspector.</summary>
    public abstract class VsBoxedList : VisualElement
    {
        protected VsBoxedList(VisualElement list)
        {
            Box box = new Box(null, string.Empty, false);
            box.Add(list);
            this.Add(box);
        }
    }

    public class RigLayersTool : VsBoxedList
    {
        public RigLayersTool(SerializedProperty property)
            : base(new VsPolymorphicDisableList(property.FindPropertyRelative("m_Rigs"), typeof(TRig)))
        { }
    }

    public class FeetTool : VsBoxedList
    {
        public FeetTool(SerializedProperty property)
            : base(new VsSingleList(property.FindPropertyRelative("m_Feet"), typeof(Footstep)))
        { }
    }

    public class VolumesTool : VsBoxedList
    {
        public VolumesTool(SerializedProperty property)
            : base(new VsPolymorphicList(property.FindPropertyRelative("m_Volumes"), typeof(IVolume)))
        { }
    }

    public class HandleListTool : VsBoxedList
    {
        public HandleListTool(SerializedProperty property)
            : base(new VsSingleList(property.FindPropertyRelative("m_Handles"), typeof(HandleItem)))
        { }
    }

    public class ReactionsTool : VsBoxedList
    {
        public ReactionsTool(SerializedProperty property)
            : base(new VsSingleList(property.FindPropertyRelative("m_List"), typeof(ReactionItem)))
        { }
    }

    public class SpotListTool : VsBoxedList
    {
        public SpotListTool(SerializedProperty property)
            : base(new VsPolymorphicDisableList(property.FindPropertyRelative("m_Spots"), typeof(VisualScript.Runtime.Hotspots.Spot)))
        { }
    }

    public class MaterialSoundsTool : VsBoxedList
    {
        public MaterialSoundsTool(SerializedProperty property)
            : base(new VsTextureList(property.FindPropertyRelative("m_MaterialSounds"), typeof(MaterialSoundTexture)))
        { }
    }

    /// <summary>
    /// A row that shows its texture (field m_Texture) as icon, as Game Creator's Material Sounds
    /// did, so each ground type is recognized at a glance. Without texture, the type's icon.
    /// </summary>
    public class VsTextureListItem : VsListItem
    {
        public VsTextureListItem(BaseContentListFieldPropertyAdd list) : base(list)
        { }

        protected override Texture GetIcon(SerializedProperty propertyItem)
        {
            Texture texture = propertyItem?.FindPropertyRelative("m_Texture")?.objectReferenceValue as Texture;
            return texture != null ? texture : base.GetIcon(propertyItem);
        }
    }

    public class VsTextureList : VsSingleList
    {
        protected override BaseContentListItemProperty MakeListItem() => new VsTextureListItem(this);

        public VsTextureList(SerializedProperty array, Type type) : base(array, type)
        { }
    }
}
