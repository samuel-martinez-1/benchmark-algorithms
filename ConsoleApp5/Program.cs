using BenchmarkDotNet.Running;
using ConsoleApp5;

BenchmarkRunner.Run<AlgorithmDemo>();
// int[] array = { -1, -2, 0, -1, 2, 1, 4, 4 };
// int target = 3;
//
// var ss  = AlgorithmDemo.HarishAproach(target, array);
// foreach (var s in ss)
// {
//     Console.WriteLine($"{s.Item1} {s.Item2}");
// }