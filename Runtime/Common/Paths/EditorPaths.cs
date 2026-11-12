namespace VisualScript.Runtime.Characters
{
    public static class EditorPaths
    {
        public const string PACKAGE = RuntimePaths.PACKAGE;

        public const string EDITOR = PACKAGE + "Editor/";

        public const string COMMON = EDITOR + "Common/";
        public const string CHARACTERS = EDITOR + "Characters/";
        public const string CAMERAS = EDITOR + "Cameras/";
        public const string GIZMOS = EDITOR + "Gizmos/";
    }

    public static class StyleSheetPaths
    {
        public const string STYLESHEETS = EditorPaths.COMMON + "UI/StyleSheets/";
    }
}
