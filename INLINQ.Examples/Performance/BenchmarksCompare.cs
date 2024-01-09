using BenchmarkDotNet.Attributes;
using INLINQ.Core;
using static INLINQ.Core.InLinq;

namespace INLINQ.Examples.Performance
{
    [MemoryDiagnoser(false)]
    public class BenchmarksCompare
    {   public enum BENCHMARK_MODE
        {
           INLINQ, LINQ
        };

        [Params(100, 100_000, 100_000_000)]
        public int LENGTH { get; set; }

        [Params(BENCHMARK_MODE.LINQ, BENCHMARK_MODE.INLINQ)]
        public BENCHMARK_MODE MODE { get; set; }


        [GlobalSetup]
        public void DoSetup()
        {
            if (MODE == BENCHMARK_MODE.LINQ)
            {
                InLinq.SetModeLinq();
            }
            else
            {
                InLinq.SetModeInLinqRuntime();
            }
        }


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

        
        


        [Benchmark]
        public bool RangeSelectAll()
        {
            var query =
                from id in Range(0, LENGTH)
                select new TestObject(id, id * 3, 1 + 100 * id);
            return query.All(x => x.Value > 0);
        }

        [Benchmark]
        public long RangeSelectWhereSum()
        {
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
