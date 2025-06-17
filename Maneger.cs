using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranianAgents
{
    public class Maneger
    {
        public static class AllSensor
        {
            public static List<ISensor> SensorType = new List<ISensor>
    {
        new TrafficSensor(),
        new ThermalSensor(),
        new CellularSensor()
    };
        }

        SimpleAgent agent = new SimpleAgent("Ali");
        Random random = new Random();
        public void AddSensorToAgent()
        {
            for (int i = 0; i < agent.SecretWeaknesses.Length; i++)
            {
                int index = random.Next(AllSensor.SensorType.Count); // בוחר אינדקס רנדומלי
                var sensorType = AllSensor.SensorType[index]; // לוקח סנסור מהרשימה
                                                              // יוצר עותק חדש מאותו סוג (חשוב!)
                if (sensorType is TrafficSensor)
                    agent.SecretWeaknesses[i] = new TrafficSensor();
                else if (sensorType is ThremalSensor)
                    agent.SecretWeaknesses[i] = new ThremalSensor();
                else if (sensorType is CellularSensor)
                    agent.SecretWeaknesses[i] = new CellularSensor();
            }
        }
    }
}
