using System;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// Execution order constants used by the ported components. Application lifetime is
    /// handled by the Visual Script AppManager.
    /// </summary>
    public static class ApplicationManager
    {
        public const int EXECUTION_ORDER_DEFAULT = 0;
        public const int EXECUTION_ORDER_DEFAULT_LATER = EXECUTION_ORDER_DEFAULT + 1;
        public const int EXECUTION_ORDER_DEFAULT_EARLIER = EXECUTION_ORDER_DEFAULT - 1;

        public const int EXECUTION_ORDER_FIRST = EXECUTION_ORDER_DEFAULT - 50;
        public const int EXECUTION_ORDER_FIRST_LATER = EXECUTION_ORDER_FIRST + 1;
        public const int EXECUTION_ORDER_FIRST_EARLIER = EXECUTION_ORDER_FIRST - 1;

        public const int EXECUTION_ORDER_LAST = EXECUTION_ORDER_DEFAULT + 50;
        public const int EXECUTION_ORDER_LAST_LATER = EXECUTION_ORDER_LAST + 1;
        public const int EXECUTION_ORDER_LAST_EARLIER = EXECUTION_ORDER_LAST - 1;

        public static bool IsExiting => AppManager.IsExiting;

        public static event Action EventExit
        {
            add => AppManager.EventExit += value;
            remove => AppManager.EventExit -= value;
        }
    }
}
