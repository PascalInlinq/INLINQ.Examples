using BenchmarkDotNet.Attributes;
using static INLINQ.Core.InLinq;

namespace INLINQ.Examples.Performance
{
    [MemoryDiagnoser(false)]
    public class BenchmarksCompare
    {
        public class TestObject
        {
            public long Id { get; set; }
            public long NameCode { get; set; }
            public long Value { get; set; }

            public TestObject(long id, long nameCode, long value)
            {
                Id = id;
                NameCode = nameCode;
                Value = value;
            }

        }

        [Params(100, 10_000, 1_000_000)]
        public int LENGTH { get; set; }

        [Params(LINQ_MODE.LINQ, LINQ_MODE.INLINQ)]
        public LINQ_MODE MODE { get; set; }


        [Benchmark]
        public bool RangeSelectAll()
        {
            Mode = MODE;
            var query =
                from id in Range(0, LENGTH)
                select new TestObject(id, id * 3, 1 + 100 * id);
            return query.All(x => x.Value > 0);
        }

        [Benchmark]
        public long RangeSelectWhereSum()
        {
            Mode = MODE;
            var testObjects =
                from id in Range(0, LENGTH)
                select new TestObject(id, id * 3, 1 + 100 * id);

            var sumValue =
                (from testObject in testObjects
                 where testObject.Value > 0
                 select testObject.Value * (80 / 5)).Sum();

            return sumValue;
        }


    }
}
