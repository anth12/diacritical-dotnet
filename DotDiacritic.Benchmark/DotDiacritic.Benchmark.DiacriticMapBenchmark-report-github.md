``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.14393.2906 (1607/AnniversaryUpdate/Redstone1)
Intel Xeon CPU E3-1505M v5 2.80GHz, 1 CPU, 8 logical and 4 physical cores
Frequency=2742187 Hz, Resolution=364.6724 ns, Timer=TSC
.NET Core SDK=2.2.401
  [Host]     : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT


```
|               Method |     Mean |     Error |    StdDev |   Median | Rank |
|--------------------- |---------:|----------:|----------:|---------:|-----:|
|      LatinOnlyString | 218.0 ns |  5.130 ns |  14.55 ns | 212.4 ns |    1 |
| ShortDiacriticString | 501.4 ns |  9.930 ns |  28.33 ns | 494.7 ns |    2 |
|  LongDiacriticString | 613.3 ns | 36.738 ns | 108.32 ns | 576.4 ns |    3 |
