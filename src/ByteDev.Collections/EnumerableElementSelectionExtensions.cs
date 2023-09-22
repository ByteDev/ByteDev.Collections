using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for selecting elements in an IEnumerable.
    /// </summary>
    public static class EnumerableElementSelectionExtensions
    {
        /// <summary>
        /// Returns the last <paramref name="count" /> number of elements from the sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the elements from.</param>
        /// <param name="count">Number of elements to return from the sequence.</param>
        /// <returns>The last elements in the sequence.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static IEnumerable<TSource> Last<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            if (count < 1)
                return Enumerable.Empty<TSource>();
            
            if (count == 1)
                return new[] { source.Last() };

            return source.Skip(source.Count() - count);
        }

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

            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext() == false)
                {
                    if (throwException)
                        ExceptionThrower.SequenceEmpty();

                    return default;
                }

                if (enumerator.MoveNext(index) == false)
                {
                    if (throwException)
                        ExceptionThrower.SequenceNoElementAt(index);

                    return default;
                }
                
                return enumerator.Current;
            }
        }
    }
}