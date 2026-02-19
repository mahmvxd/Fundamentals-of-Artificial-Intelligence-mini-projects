using System;

namespace AmmoRule
{
    class Ammofuzzy
    {
        public static double low, high; 
        public static int rockets, reload;

        static void Main(string[] args)
        {
            rockets = 23;
            reload = 5;
            int rocketsfired;
            System.Random random = new System.Random();

            while (rockets > 0)
            {
                Console.WriteLine("Rockets remaining: " + rockets);
                Console.WriteLine("Reloading with: " + reload);
                rockets += reload;
                rocketsfired = random.Next(5, 35);
                if (rocketsfired > rockets)
                    rocketsfired = rockets;
                rockets -= rocketsfired;
                Console.WriteLine("Rockets fired: " + rocketsfired);

                low = 0.0;
                high = 0.0;

                rules();

                double reloadQuantity = (low * 25 + high * 5) / (low + high);
                reload = (int)Math.Round(reloadQuantity); 

                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine("Out of ammo!!");
            Console.ReadKey();
        }

        public static void rules()
        {
            low = Math.Max(0, Math.Min(1, 1 - (rockets / 40.0)));
            high = Math.Max(0, Math.Min(1, (rockets - 10.0) / 40.0));
        }
    }
}
