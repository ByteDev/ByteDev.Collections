using System;
using System.Collections.Generic;

namespace ByteDev.Collections
{
    public static class EnumerableElementSelectionExtensions
    {
        /// <summary>Returns the second element of a sequence.</summary>
        /// <returns>The second element in the specified sequence.</returns>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the second element of.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no second element.</exception>
        public static TSource Second<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 1);
        }

        /// <summary>Returns the third element of a sequence.</summary>
        /// <returns>The third element in the specified sequence.</returns>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the third element of.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no third element.</exception>
        public static TSource Third<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 2);
        }

        /// <summary>Returns the fourth element of a sequence.</summary>
        /// <returns>The fourth element in the specified sequence.</returns>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the fourth element of.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no fourth element.</exception>
        public static TSource Fourth<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 3);
        }

        /// <summary>Returns the fifth element of a sequence.</summary>
        /// <returns>The fifth element in the specified sequence.</returns>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the fifth element of.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no fifth element.</exception>
        public static TSource Fifth<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 4);
        }

        /// <summary>Returns the sixth element of a sequence.</summary>
        /// <returns>The sixth element in the specified sequence.</returns>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the sixth element of.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no sixth element.</exception>
        public static TSource Sixth<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 5);
        }

        /// <summary>Returns the seventh element of a sequence.</summary>
        /// <returns>The seventh element in the specified sequence.</returns>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the seventh element of.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no seventh element.</exception>
        public static TSource Seventh<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 6);
        }

        /// <summary>Returns the eighth element of a sequence.</summary>
        /// <returns>The eighth element in the specified sequence.</returns>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the eighth element of.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no eighth element.</exception>
        public static TSource Eighth<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 7);
        }

        /// <summary>Returns the ninth element of a sequence.</summary>
        /// <returns>The ninth element in the specified sequence.</returns>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the ninth element of.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no ninth element.</exception>
        public static TSource Ninth<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 8);
        }

        /// <summary>Returns the tenth element of a sequence.</summary>
        /// <returns>The tenth element in the specified sequence.</returns>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the tenth element of.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The source sequence contains no tenth element.</exception>
        public static TSource Tenth<TSource>(this IEnumerable<TSource> source)
        {
            return GetElement(source, 9);
        }

        private static T GetElement<T>(IEnumerable<T> source, int index)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var count = 0;

            foreach (var element in source)
            {
                if (count == index)
                    return element;
                
                count++;
            }

            if(count == 0)
                throw new InvalidOperationException("Sequence contains no elements.");

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
                    throw new InvalidOperationException($"Position: {index}, was unhandled.");
            }
        }
    }
}