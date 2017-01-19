﻿using System.Collections.Generic;

using Shouldly;

using Stove.Collections.Extensions;

using Xunit;

namespace Stove.Tests.Collections.Extensions
{
    public class ListExtensions_SortByDependencies_Tests
    {
        [Fact]
        public void Should_SortByDependencies()
        {
            var a = new DependedObject("A");
            var b = new DependedObject("B");
            var c = new DependedObject("C");
            var d = new DependedObject("D");

            b.Dependencies.Add(a);
            c.Dependencies.Add(a);
            c.Dependencies.Add(d);
            d.Dependencies.Add(b);

            ShouldSortedCorrectly(new List<DependedObject> { a, b, c, d });
            ShouldSortedCorrectly(new List<DependedObject> { d, c, b, a });
            ShouldSortedCorrectly(new List<DependedObject> { a, c, d, b });
            ShouldSortedCorrectly(new List<DependedObject> { c, a, d, b });
        }

        private static void ShouldSortedCorrectly(List<DependedObject> dependedObjects)
        {
            List<DependedObject> sorted = dependedObjects.SortByDependencies(o => o.Dependencies);
            sorted[0].Name.ShouldBe("A");
            sorted[1].Name.ShouldBe("B");
            sorted[2].Name.ShouldBe("D");
            sorted[3].Name.ShouldBe("C");
        }

        private class DependedObject
        {
            public DependedObject(string name)
            {
                Name = name;
                Dependencies = new List<DependedObject>();
            }

            public string Name { get; }

            public List<DependedObject> Dependencies { get; }
        }
    }
}
