using BenchmarkDotNet.Running;
using INLINQ.Examples.Performance;

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
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarksCompare>();
        }
    }

    /* Output:
     *
BenchmarkDotNet v0.13.11, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i9-9880H CPU 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


| Method              | LENGTH  | MODE   | Mean        | Error     | StdDev    | Allocated   |
|-------------------- |-------- |------- |------------:|----------:|----------:|------------:|
| RangeSelectAll      | 100     | LINQ   |    160.7 us |   0.80 us |   0.75 us |    14.35 KB |
| RangeSelectWhereSum | 100     | LINQ   |    220.6 us |   1.56 us |   1.46 us |    19.26 KB |
| RangeSelectAll      | 100     | INLINQ |    262.1 us |   0.80 us |   0.67 us |    26.58 KB |
| RangeSelectWhereSum | 100     | INLINQ |    465.9 us |   1.28 us |   1.00 us |    44.67 KB |
| RangeSelectAll      | 10000   | LINQ   |    268.3 us |   1.57 us |   1.46 us |   401.07 KB |
| RangeSelectWhereSum | 10000   | LINQ   |    353.9 us |   4.00 us |   3.55 us |   405.98 KB |
| RangeSelectAll      | 10000   | INLINQ |    270.8 us |   1.49 us |   1.40 us |    26.58 KB |
| RangeSelectWhereSum | 10000   | INLINQ |    500.2 us |   0.82 us |   0.69 us |    44.67 KB |
| RangeSelectAll      | 1000000 | LINQ   | 11,744.6 us |  77.84 us |  72.81 us | 39073.27 KB |
| RangeSelectWhereSum | 1000000 | LINQ   | 13,683.4 us | 116.80 us | 109.26 us | 39078.27 KB |
| RangeSelectAll      | 1000000 | INLINQ |  1,012.3 us |   1.81 us |   1.51 us |    26.58 KB |
| RangeSelectWhereSum | 1000000 | INLINQ |  3,884.7 us |   9.08 us |   8.50 us |    44.64 KB |
     */
}
