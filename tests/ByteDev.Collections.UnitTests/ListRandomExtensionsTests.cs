using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests;

[TestFixture]
public class ListRandomExtensionsTests
{
    [Test]
    public void WhenIsNull_ThenThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => (null as IList<int>).Shuffle());
    }

    [Test]
    public void WhenIsEmpty_ThenDoNothing()
    {
        IList<int> sut = new List<int>();

        sut.Shuffle();

        Assert.That(sut, Is.Empty);
    }

    [Test]
    public void WhenIsSingle_ThenDoNothing()
    {
        IList<int> sut = new List<int> {1};

        sut.Shuffle();

        Assert.That(sut.Single(), Is.EqualTo(1));
    }

    [Test]
    public void WhenIsTwoElements_ThenShuffle()
    {
        IList<int> sut = new List<int> {1, 2};

        sut.Shuffle();
            
        Assert.That(sut.Count, Is.EqualTo(2));
        Assert.That(sut.ContainsAll(1, 2), Is.True);
    }

    [Test]
    public void WhenIsManyElements_ThenShuffle()
    {
        IList<int> sut = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        sut.Shuffle();
            
        Assert.That(sut.Count, Is.EqualTo(10));
        Assert.That(sut.ContainsAll(1, 2, 3, 4, 5, 6, 7, 8, 9, 10), Is.True);
    }
}