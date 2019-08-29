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
|                           Method |          Mean |        Error |       StdDev | Rank |
|--------------------------------- |--------------:|-------------:|-------------:|-----:|
|      Diacritical_LatinOnlyString |     198.07 ns |     54.44 ns |     2.984 ns |    2 |
| Diacritical_ShortDiacriticString |      91.85 ns |    119.61 ns |     6.556 ns |    1 |
|  Diacritical_LongDiacriticString |     315.78 ns |    102.86 ns |     5.638 ns |    3 |
|       Diacritics_LatinOnlyString |   1,146.72 ns |  1,965.70 ns |   107.747 ns |    4 |
|  Diacritics_ShortDiacriticString |   5,500.91 ns |  1,772.92 ns |    97.180 ns |    5 |
|   Diacritics_LongDiacriticString | 112,362.01 ns | 44,386.72 ns | 2,432.986 ns |    6 |
