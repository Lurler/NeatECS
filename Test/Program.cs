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
                .AddSystem<MixerSystem>()
                .Initialize();
            StopTimer("Initialization: ~");

            // ============ Entity creation test ============
            GC.TryStartNoGCRegion(1024 * 1024 * 1024);
            var random = new Random();
            StartTimer();
            for (int i = 0; i < 1000; i++)
            {
                var entity = world.NewEntity();

                if (random.NextDouble() > 0.5) 
                    entity.Set(new CounterAComponent(0));
                if (random.NextDouble() > 0.5)
                    entity.Set(new CounterBComponent(0));
                if (random.NextDouble() > 0.5)
                    entity.Set(new CounterCComponent(0));

                if (random.NextDouble() > 0.5)
                    entity.Set(new MixerComponent());
            }
            StopTimer("Entity creation x1000: ~");
            GC.EndNoGCRegion();
            GC.Collect();

            // ============ Update test ============
            StartTimer();
            for (int i = 0; i < 1000; i++)
            {
                world.Update();
            }
            StopTimer("Update: ", 1000);
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