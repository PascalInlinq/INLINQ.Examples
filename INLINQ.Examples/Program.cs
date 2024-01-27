using BenchmarkDotNet.Running;
using INLINQ.Examples.Performance;
using System.Reflection;

namespace INLINQ.Examples
{
    /*
     * Add the following to your project file:
     * <ItemGroup>
     *     <Using Remove="System.Linq" />
     * </ItemGroup>
     * */
    internal class Program
    {
#if RECOMPILE
        static void Main(string[] args)
        {
            string projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string fileName = Path.Combine(projectDir, "Intercept", "RecompiledQueries.cs");
            INLINQ.Core.Recompile.Recompiler.Recompile(Assembly.GetExecutingAssembly(), fileName, "Recompiled", "RecompiledQueries");
        }
#else
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarksCompare>();
        }
#endif
    }

    /* Output:
     *
BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3930/22H2/2022Update)
Intel Core i9-9880H CPU 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


| Method    | LENGTH    | Mean              | Error          | StdDev           | Allocated   |
|---------- |---------- |------------------:|---------------:|-----------------:|------------:|
| InLinqAll | 1         |          40.90 ns |       0.329 ns |         0.292 ns |       160 B |
| LinqAll   | 1         |          39.94 ns |       0.157 ns |         0.147 ns |       128 B |
| InLinqAll | 100       |         131.32 ns |       0.406 ns |         0.339 ns |       160 B |
| LinqAll   | 100       |         820.97 ns |       4.199 ns |         3.278 ns |      4088 B |
| InLinqAll | 100000    |      77,659.33 ns |      66.210 ns |        58.694 ns |       160 B |
| LinqAll   | 100000    |     844,892.15 ns |  11,416.034 ns |    10,678.565 ns |   4000088 B |
| InLinqAll | 100000000 |  16,620,779.17 ns |  20,233.310 ns |    18,926.251 ns |       172 B |
| LinqAll   | 100000000 | 205,801,556.72 ns | 657,274.098 ns | 1,562,081.436 ns | 858996680 B |

     */
}
