using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Hotspots
{
    [Title("Cursor")]
    [Image(typeof(IconCursor), ColorTheme.Type.Yellow)]
    
    [Category("UI/Cursor")]
    [Description("Changes the cursor image when hovering the Hotspot")]

    [Serializable]
    public class SpotCursor : Spot
    {
        // EXPOSED MEMBERS: -----------------------------------------------------------------------

        [SerializeField] protected GetTexture m_Texture = new GetTexture();
        [SerializeField] protected GetVector3 m_Origin = new GetVector3(Vector3.zero);

        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => $"Change Cursor to {this.m_Texture}";
        
        [field: NonSerialized] private bool IsPointerHovering { get; set; }

        // OVERRIDE METHODS: ----------------------------------------------------------------------

        public override void OnPointerEnter(Hotspot hotspot)
        {
            base.OnPointerEnter(hotspot);
            
            this.IsPointerHovering = true;
            this.RefreshCursor(hotspot.IsActive && this.IsPointerHovering, hotspot.Args);
        }

        public override void OnPointerExit(Hotspot hotspot)
        {
            base.OnPointerExit(hotspot);
            
            this.IsPointerHovering = false;
            this.RefreshCursor(hotspot.IsActive && this.IsPointerHovering, hotspot.Args);
        }

        public override void OnDisable(Hotspot hotspot)
        {
            base.OnDisable(hotspot);

            if (hotspot.IsActive && this.IsPointerHovering)
            {
                this.RefreshCursor(false, hotspot.Args);
            }
            
            this.IsPointerHovering = false;
        }
        
        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void RefreshCursor(bool customCursor, Args args)
        {
            switch (customCursor)
            {
                case true:
                    Texture2D texture = this.m_Texture.Get(args) as Texture2D;
                    Vector3 origin = this.m_Origin.Get(args).XY();
                    Cursor.SetCursor(texture, origin, CursorMode.Auto);
                    break;
                
                case false:
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    break;
            }
        }
    }
}