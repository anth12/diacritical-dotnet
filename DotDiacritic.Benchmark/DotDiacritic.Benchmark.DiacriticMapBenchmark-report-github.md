``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.14393.2906 (1607/AnniversaryUpdate/Redstone1)
Intel Xeon CPU E3-1505M v5 2.80GHz, 1 CPU, 8 logical and 4 physical cores
Frequency=2742187 Hz, Resolution=364.6724 ns, Timer=TSC
.NET Core SDK=2.2.401
  [Host]     : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT


```
|               Method |        Mean |     Error |      StdDev |      Median | Rank |
|--------------------- |------------:|----------:|------------:|------------:|-----:|
|      LatinOnlyString |    249.4 ns |  11.64 ns |    34.32 ns |    252.7 ns |    1 |
| ShortDiacriticString |    427.2 ns |  13.80 ns |    37.54 ns |    416.9 ns |    2 |
|  LongDiacriticString | 15,569.4 ns | 639.10 ns | 1,874.38 ns | 14,859.1 ns |    3 |
