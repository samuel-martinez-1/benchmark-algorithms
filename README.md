# benchmark
- set in `realase` mode _(debug mode is not allowed for benchmark)_
- hit run .... and wait
  
| Method                                     | Mean        | Error    | StdDev   | Rank | Gen0   | Allocated |
|------------------------------------------- |------------:|---------:|---------:|-----:|-------:|----------:|
| HarishApproach_B_simpleData                |    32.95 ns | 0.667 ns | 0.935 ns |    1 | 0.0070 |      88 B |
| HarishApproach_B_SightVariation_SimpleData |    56.62 ns | 0.737 ns | 0.653 ns |    2 | 0.0147 |     184 B |
| HarishApproach_C_simpleData                |   132.18 ns | 1.774 ns | 1.573 ns |    3 | 0.0470 |     592 B |
| HarishApproach_B_largeData                 |   358.15 ns | 4.119 ns | 3.853 ns |    4 | 0.0138 |     176 B |
| HarishApproach_B_SightVariation_LargeData  |   449.88 ns | 1.887 ns | 1.765 ns |    5 | 0.0424 |     536 B |
| HarishApproach_C_largeData                 | 1,105.40 ns | 8.067 ns | 6.736 ns |    6 | 0.1450 |    1824 B |
