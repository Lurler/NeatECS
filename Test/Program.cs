using NeatECS;
using System.Diagnostics;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ============ World initialization test ============
            StartTimer();
            World world = new();
            world
                .AddSystem<CounterSystem>()
                .Initialize();
            StopTimer("Initialization: ~");

            // ============ Entity creation test ============
            GC.TryStartNoGCRegion(1024 * 1024 * 1024);
            StartTimer();
            for (int i = 0; i < 10000; i++)
            {
                var entity = world.NewEntity();
                entity
                    .Set(new CounterComponent(0));
            }
            StopTimer("Entity creation x10000: ~");
            GC.EndNoGCRegion();
            GC.Collect();

            // ============ Update test ============
            GC.TryStartNoGCRegion(1024 * 1024 * 1024);
            StartTimer();
            for (int i = 0; i < 1000; i++)
            {
                world.Update();
            }
            StopTimer("Update: ", 1000);
            GC.EndNoGCRegion();
            GC.Collect();
        }

        private static Stopwatch stopwatch = new();

        private static void StartTimer()
        {
            stopwatch.Reset();
            stopwatch.Start();
        }

        private static void StopTimer(string textStart, int scale = 1, string textEnd = " ms.")
        {
            stopwatch.Stop();
            Console.WriteLine(textStart + (stopwatch.ElapsedMilliseconds / (float)scale) + textEnd);
        }
    }
}