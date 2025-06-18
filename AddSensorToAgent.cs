using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranianAgents
{
    public class AllSensor
    {
        public static List<Type> SensorType = new List<Type>
    {
        typeof(TrafficSensor),
        typeof(ThermalSensor),
        typeof(CellularSensor),
        typeof(PlusSensor)
    };
        public static void AddSensor(IAgent agent)
        {
            Random random = new Random();

            for (int i = 0; i < agent.SecretWeaknesses.Length; i++)
            {
                int index = random.Next(SensorType.Count);
                var sensorType = SensorType[index];

                if (sensorType == typeof(TrafficSensor))
                    agent.SecretWeaknesses[i] = new TrafficSensor();
                else if (sensorType == typeof(ThermalSensor))
                    agent.SecretWeaknesses[i] = new ThermalSensor();
                else if (sensorType == typeof(CellularSensor))
                    agent.SecretWeaknesses[i] = new CellularSensor();
                else if (sensorType == typeof(PlusSensor))
                    agent.SecretWeaknesses[i] = new PlusSensor();
            }
        }

    }
}