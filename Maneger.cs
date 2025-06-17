using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranianAgents
{
    public class Maneger
    {
        public static ISensor CreateSensorByName(string name)
        {
            switch (name.ToLower())
            {
                case "thermal":
                    return new ThermalSensor();
                case "traffic":
                    return new TrafficSensor();
                case "cellular":
                    return new CellularSensor();
                default:
                    return null;
            }
        }
        public static void run(IAgent agent)
        {
            Console.WriteLine($"Iranian Agent Type {agent.GetType().Name}, name: {agent.Name}");
            Console.WriteLine($"Please enter the sensor type for weakness (Thermal, Traffic, Cellular):");
            
            int sensorCount = 0;
            while (sensorCount < agent.SecretWeaknesses.Length)
            {
                string Sensor = Console.ReadLine();
                ISensor InputSensor = CreateSensorByName(Sensor);


                if (InputSensor == null)
                {
                    Console.WriteLine("Invalid sensor type. Please try again.");
                    continue;
                }
                


                bool found = false;
                for (int i = 0; i < agent.SecretWeaknesses.Length; i++)
                {
                    if (agent.SecretWeaknesses[i].Type == Sensor)
                    {
                        sensorCount++;
                        Console.WriteLine($"you found [{sensorCount}/{agent.SecretWeaknesses.Length}]");
                        agent.Sensor.Add(InputSensor);
                        InputSensor.Activate();
                        found = true;
                        break;

                    }
                }
                if (!found)
                {
                    Console.WriteLine($"you found[{sensorCount}/{agent.SecretWeaknesses.Length}]"); 
                }
            }
            Console.WriteLine("The Agent exposed");
        }
    }
}
