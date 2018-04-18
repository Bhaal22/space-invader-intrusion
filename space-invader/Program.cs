using System;

namespace space_invader
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = new NaiveInvaderDetector();
            system.Boostrap<KnownInvadersRepository, Palantir, StaticRadar>();

            var invaded = system.InvasionDetected();

            Console.WriteLine($"Invasion Detected: {invaded}");
        }
    }
}
