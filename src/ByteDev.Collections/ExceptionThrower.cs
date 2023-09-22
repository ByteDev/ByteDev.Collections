using System;

namespace ByteDev.Collections
{
    internal static class ExceptionThrower
    {
        public static void SequenceEmpty()
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }

        public static void SequenceNoElementAt(int index)
        {
            throw new InvalidOperationException(GetErrorMessageNoElementFor(index));
        }

        private static string GetErrorMessageNoElementFor(int index)
        {
            const string template = "Sequence contains no {0} element.";

            switch (index)
            {
                case 1:
                    return string.Format(template, "second");
                case 2:
                    return string.Format(template, "third");
                case 3:
                    return string.Format(template, "fourth");
                case 4:
                    return string.Format(template, "fifth");
                case 5:
                    return string.Format(template, "sixth");
                case 6:
                    return string.Format(template, "seventh");
                case 7:
                    return string.Format(template, "eighth");
                case 8:
                    return string.Format(template, "ninth");
                case 9:
                    return string.Format(template, "tenth");
                default:
                    throw new InvalidOperationException($"Index: {index} was not handled.");
            }
        }
    }
}