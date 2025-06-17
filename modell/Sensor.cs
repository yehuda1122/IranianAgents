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
        
        string Type { get;  }
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
        public string Type =>"Thermal";
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
}
    
