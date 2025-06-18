using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranianAgents
{
    //public enum SensorType
    // {
    //     Traffic,
    //     Thermal,
    //     Cellular,

    public interface ISensor
    {

        string Type { get; }
        void Activate();
    }
    class TrafficSensor : ISensor
    {
        public string Type => "Traffic";
        public void Activate()
        {
            Console.WriteLine($"Traffic sensor activated.");
        }
    }
    class ThermalSensor : ISensor
    {
        public string Type => "Thermal";
        public void Activate()
        {
            Console.WriteLine($"Thermal sensor activated.");
        }
    }
    class CellularSensor : ISensor
    {
        public string Type => "Cellular";
        public void Activate()
        {
            Console.WriteLine($"Cellular sensor activated.");
        }
    }
    public class PlusSensor : ISensor
    {
        private int activationCount = 0;
        private const int MaxActivations = 3;
        private bool isBroken = false;

        public string Type => "Plus";
        public bool IsBroken => isBroken;

        // מפעיל את הסנסור רק אם יש התאמה
        public void Activate()
        {
            Console.WriteLine("Plus sensor activated.");
        }

        // תמיד קוראים לפונקציה הזאת — גם אם לא הייתה התאמה
        public void RegisterUse()
        {
            if (isBroken)
                return;

            activationCount++;

            if (activationCount >= MaxActivations)
            {
                isBroken = true;
                Console.WriteLine("The Plus sensor has been broken after 3 uses.");
                Console.WriteLine("Please enter the sensor type for weakness (Thermal, Traffic, Cellular)");

            }
        }
    }

}



