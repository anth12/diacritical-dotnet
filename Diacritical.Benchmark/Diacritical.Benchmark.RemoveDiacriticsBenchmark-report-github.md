``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.14393.2906 (1607/AnniversaryUpdate/Redstone1)
Intel Xeon CPU E3-1505M v5 2.80GHz, 1 CPU, 8 logical and 4 physical cores
Frequency=2742187 Hz, Resolution=364.6724 ns, Timer=TSC
.NET Core SDK=2.2.401
  [Host]   : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
  ShortRun : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                           Method |        Mean |        Error |     StdDev | Rank |
|--------------------------------- |------------:|-------------:|-----------:|-----:|
|      Diacritical_LatinOnlyString |    200.2 ns |     75.39 ns |   4.132 ns |    1 |
| Diacritical_ShortDiacriticString |    420.2 ns |    433.37 ns |  23.754 ns |    2 |
|  Diacritical_LongDiacriticString | 14,309.4 ns |  3,800.80 ns | 208.335 ns |    5 |
|       Diacritics_LatinOnlyString |    878.0 ns |    404.79 ns |  22.188 ns |    3 |
|  Diacritics_ShortDiacriticString |  3,717.4 ns |  1,233.59 ns |  67.617 ns |    4 |
|   Diacritics_LongDiacriticString | 79,569.4 ns | 12,520.32 ns | 686.281 ns |    6 |
