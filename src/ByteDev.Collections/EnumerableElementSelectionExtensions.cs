using System;
using System.Collections.Generic;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for selecting elements in an IEnumerable.
    /// </summary>
    public static class EnumerableElementSelectionExtensions
    {
        /// <summary>
        /// Returns the second element of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the second element of.</param>
        /// <returns>The second element in the specified sequence.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no second element.</exception>
        public static TSource Second<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 1);
        }

        /// <summary>
        /// Returns the second element of a sequence, or a default value if the sequence does not contain a second element.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the second element of.</param>
        /// <returns>default if <paramref name="source" /> does not contain the second element; otherwise, the second element in <paramref name="source" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static TSource SecondOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 1, false);
        }
        
        /// <summary>
        /// Returns the third element of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the third element of.</param>
        /// <returns>The third element in the specified sequence.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no third element.</exception>
        public static TSource Third<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 2);
        }

        /// <summary>
        /// Returns the third element of a sequence, or a default value if the sequence does not contain a third element.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the third element of.</param>
        /// <returns>default if <paramref name="source" /> does not contain the third element; otherwise, the third element in <paramref name="source" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static TSource ThirdOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 2, false);
        }

        /// <summary>
        /// Returns the fourth element of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the fourth element of.</param>
        /// <returns>The fourth element in the specified sequence.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no fourth element.</exception>
        public static TSource Fourth<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 3);
        }

        /// <summary>
        /// Returns the fourth element of a sequence, or a default value if the sequence does not contain a fourth element.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the fourth element of.</param>
        /// <returns>default if <paramref name="source" /> does not contain the fourth element; otherwise, the fourth element in <paramref name="source" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static TSource FourthOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 3, false);
        }

        /// <summary>
        /// Returns the fifth element of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the fifth element of.</param>
        /// <returns>The fifth element in the specified sequence.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no fifth element.</exception>
        public static TSource Fifth<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 4);
        }

        /// <summary>
        /// Returns the fifth element of a sequence, or a default value if the sequence does not contain a fifth element.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the fifth element of.</param>
        /// <returns>default if <paramref name="source" /> does not contain the fifth element; otherwise, the fifth element in <paramref name="source" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static TSource FifthOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 4, false);
        }

        /// <summary>
        /// Returns the sixth element of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the sixth element of.</param>
        /// <returns>The sixth element in the specified sequence.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no sixth element.</exception>
        public static TSource Sixth<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 5);
        }

        /// <summary>
        /// Returns the sixth element of a sequence, or a default value if the sequence does not contain a sixth element.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the sixth element of.</param>
        /// <returns>default if <paramref name="source" /> does not contain the sixth element; otherwise, the sixth element in <paramref name="source" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static TSource SixthOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 5, false);
        }

        /// <summary>
        /// Returns the seventh element of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the seventh element of.</param>
        /// <returns>The seventh element in the specified sequence.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no seventh element.</exception>
        public static TSource Seventh<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 6);
        }

        /// <summary>
        /// Returns the seventh element of a sequence, or a default value if the sequence does not contain a seventh element.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the seventh element of.</param>
        /// <returns>default if <paramref name="source" /> does not contain the seventh element; otherwise, the seventh element in <paramref name="source" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static TSource SeventhOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 6, false);
        }

        /// <summary>
        /// Returns the eighth element of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the eighth element of.</param>
        /// <returns>The eighth element in the specified sequence.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no eighth element.</exception>
        public static TSource Eighth<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 7);
        }

        /// <summary>
        /// Returns the eighth element of a sequence, or a default value if the sequence does not contain a eighth element.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the eighth element of.</param>
        /// <returns>default if <paramref name="source" /> does not contain the eighth element; otherwise, the eighth element in <paramref name="source" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static TSource EighthOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 7, false);
        }

        /// <summary>
        /// Returns the ninth element of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the ninth element of.</param>
        /// <returns>The ninth element in the specified sequence.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no ninth element.</exception>
        public static TSource Ninth<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 8);
        }

        /// <summary>
        /// Returns the ninth element of a sequence, or a default value if the sequence does not contain a ninth element.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the ninth element of.</param>
        /// <returns>default if <paramref name="source" /> does not contain the ninth element; otherwise, the ninth element in <paramref name="source" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static TSource NinthOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 8, false);
        }

        /// <summary>
        /// Returns the tenth element of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the tenth element of.</param>
        /// <returns>The tenth element in the specified sequence.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no tenth element.</exception>
        public static TSource Tenth<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 9);
        }

        /// <summary>
        /// Returns the tenth element of a sequence, or a default value if the sequence does not contain a tenth element.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the tenth element of.</param>
        /// <returns>default if <paramref name="source" /> does not contain the tenth element; otherwise, the tenth element in <paramref name="source" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static TSource TenthOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 9, false);
        }

        private static TSource GetElement<TSource>(IEnumerable<TSource> source, byte index, bool throwException = true)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            byte count = 0;

            foreach (var element in source)
            {
                if (count == index)
                    return element;
                
                count++;
            }

            if (count == 0)
            {
                if (throwException)
                    throw new InvalidOperationException("Sequence contains no elements.");

                return default(TSource);
            }

            if(throwException)
                throw new InvalidOperationException(GetErrorMessageNoElementFor(index));

            return default(TSource);
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
                    throw new InvalidOperationException($"Position: {index}, was unhandled.");
            }
        }
    }
}