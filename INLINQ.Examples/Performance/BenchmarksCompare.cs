using BenchmarkDotNet.Attributes;
using INLINQ.Core.Recompile;

//using INLINQ.Core;
#if RECOMPILE
using static INLINQ.Core.Generate.InLinqGenerate;
#else
using static INLINQ.Core.Generated.InLinqGenerated;
#endif
using LINQ = System.Linq.Enumerable;

namespace INLINQ.Examples.Performance
{
    [MemoryDiagnoser(false)]
    [Recompile]
    public class BenchmarksCompare
    {   
        [Params(1, 100,  100_000 , 100_000_000)]
        public int LENGTH { get; set; }


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
        public bool InLinqAll()
        {
            return InLinqAll(LENGTH);
        }

        public static bool InLinqAll(int length)
        {
            var query =
                from id in Range(0, length)
                select new TestObject(id, id * 3, 1 + 100 * id);
            return query.All(x => x.Value > 0);
        }

        [Benchmark]
        public bool LinqAll()
        {
            return LINQ.All(LINQ.Select(LINQ.Range(0, LENGTH), id => new TestObject(id, id * 3, 1 + 100 * id)), x => x.Value > 0);
        }


        //[Benchmark]
        //public long InLinqWhereSum()
        //{
        //    return InLinqWhereSum(LENGTH);
        //}

        //public static long InLinqWhereSum(int length)
        //{
        //    var testObjects =
        //        from id in Range(0, length)
        //        select new TestObject(id, id * 3, 1 + 100 * id);

        //    var sumValue =
        //        (from testObject in testObjects
        //         where testObject.Value > 0
        //         select testObject.Value * (80 / 5)).Sum();

        //    return sumValue;
        //}


    }
}
