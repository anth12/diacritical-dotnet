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
|                           Method |        Mean |       Error |       StdDev | Rank |
|--------------------------------- |------------:|------------:|-------------:|-----:|
|     Diacritical_ShortLatinString |    237.5 ns |    193.0 ns |    10.578 ns |    1 |
|      Diacritical_LongLatinString |  7,902.8 ns |  3,905.6 ns |   214.080 ns |    5 |
| Diacritical_ShortDiacriticString |    424.6 ns |    181.0 ns |     9.920 ns |    2 |
|  Diacritical_LongDiacriticString | 14,354.8 ns |  3,277.9 ns |   179.672 ns |    7 |
|  Diacritics_ShortLatinOnlyString |    903.8 ns |    407.2 ns |    22.323 ns |    3 |
|   Diacritics_LongLatinOnlyString | 10,418.1 ns |  6,565.6 ns |   359.882 ns |    6 |
|  Diacritics_ShortDiacriticString |  3,880.6 ns |  1,149.3 ns |    62.996 ns |    4 |
|   Diacritics_LongDiacriticString | 83,636.7 ns | 55,190.8 ns | 3,025.192 ns |    8 |
