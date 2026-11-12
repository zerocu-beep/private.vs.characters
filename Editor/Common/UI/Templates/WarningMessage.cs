using VisualScript.Runtime;
using VisualScript.Icons;
using UnityEngine;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    public sealed class WarningMessage : VisualElement
    {
        private const string USS_PATH = EditorPaths.COMMON + "UI/StyleSheets/WarningMessage";
        
        private static readonly IIcon ICON = new IconErrorOutline(ColorTheme.Type.TextLight);

        // MEMBERS: -------------------------------------------------------------------------------

        private readonly Image m_Image;
        private readonly Label m_Label;
        
        // PROPERTIES: ----------------------------------------------------------------------------

        public string Text
        {
            get => this.m_Label.text;
            set => this.m_Label.text = value;
        }
        
        public Texture Image
        {
            get => this.m_Image.image;
            set => this.m_Image.image = value;
        }
        
        // CONSTRUCTORS: --------------------------------------------------------------------------

        public WarningMessage(string message)
        {
            StyleSheet[] sheets = StyleSheetUtils.Load(USS_PATH);
            foreach (StyleSheet sheet in sheets)
            {
                this.styleSheets.Add(sheet);
            }

            this.m_Image = new Image { image = ICON.Texture };
            this.m_Label = new Label { text = message };
            
            this.Add(this.m_Image);
            this.Add(this.m_Label);
        }
    }
}
