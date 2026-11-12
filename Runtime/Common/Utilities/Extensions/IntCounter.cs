namespace VisualScript.Runtime.Characters
{
    public static class IntegerCounter
    {
        private static int Counter;

        public static int Generate() => Counter++;
    }
}