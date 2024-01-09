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


| Method              | LENGTH    | MODE   | Mean           | Error       | StdDev      | Median         | Allocated     |
|-------------------- |---------- |------- |---------------:|------------:|------------:|---------------:|--------------:|
| RangeSelectAll      | 100       | INLINQ |       275.8 us |     1.56 us |     1.46 us |       275.3 us |      36.04 KB |
| RangeSelectWhereSum | 100       | INLINQ |       449.9 us |     1.77 us |     1.57 us |       450.3 us |      52.47 KB |
| RangeSelectAll      | 100       | LINQ   |       161.0 us |     0.65 us |     0.61 us |       161.2 us |      14.35 KB |
| RangeSelectWhereSum | 100       | LINQ   |       223.1 us |     1.47 us |     1.30 us |       223.6 us |      19.26 KB |
| RangeSelectAll      | 100000    | INLINQ |       352.2 us |     0.85 us |     0.79 us |       352.3 us |      36.04 KB |
| RangeSelectWhereSum | 100000    | INLINQ |       879.3 us |     1.83 us |     1.62 us |       879.3 us |      52.47 KB |
| RangeSelectAll      | 100000    | LINQ   |     1,217.5 us |     4.40 us |     4.12 us |     1,219.1 us |    3916.82 KB |
| RangeSelectWhereSum | 100000    | LINQ   |     1,537.8 us |    11.83 us |    11.06 us |     1,535.4 us |    3921.74 KB |
| RangeSelectAll      | 100000000 | INLINQ |    16,397.3 us |    10.96 us |     9.72 us |    16,398.2 us |      36.04 KB |
| RangeSelectWhereSum | 100000000 | INLINQ |   331,497.4 us |   207.95 us |   184.34 us |   331,560.7 us |      53.01 KB |
| RangeSelectAll      | 100000000 | LINQ   |   256,852.3 us |   648.30 us | 1,578.06 us |   256,328.3 us |  838871.73 KB |
| RangeSelectWhereSum | 100000000 | LINQ   | 1,408,833.0 us | 7,866.62 us | 7,358.45 us | 1,411,684.1 us | 3906265.95 KB |
     */
}
