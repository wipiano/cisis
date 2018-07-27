using System;
using System.Collections.Generic;
using Cisis.Linq;
using Xunit;
using static System.Array;

namespace Cisis.Test.Linq
{
    public class ForEachTest
    {
        [Fact]
        public void ForEachArgumentCheckTest()
        {
            Action ForEach(IEnumerable<int> source, Action<int> action)
                => () => source.ForEach(action);
            
            ForEach(null, i => {}).Throws<ArgumentNullException>();

            ForEach(Empty<int>(), null).Throws<ArgumentNullException>();
        }

        [Fact]
        public void ForEachEmptyTest()
        {
            var list = new List<int>();
            Empty<int>().ForEach(list.Add);
        }

        [Fact]
        public void ForEachShortArrayTest()
        {
            var list = new List<int>();
            new [] {1, 2, 3, 4, 5}.ForEach(list.Add);
            
            list.Is(1, 2, 3, 4, 5);
        }
    }
}