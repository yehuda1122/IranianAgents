using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranianAgents
{
    public class Maneger
    {
        private static int totalAttempts = 0;
        private static PlusSensor plusSensorInstance = new PlusSensor();
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
                case "plussensor":
                    return plusSensorInstance;
                default:
                    return null;
            }
        }
        public static void run(IAgent agent)
        {
            Console.WriteLine($"Iranian Agent Type {agent.GetType().Name}, name: {agent.Name}");
            Console.WriteLine("Please enter the sensor type for weakness (Thermal, Traffic, Cellular, PlusSensor):");
            int sensorCount = 0;

            while (sensorCount < agent.SecretWeaknesses.Length)
            {
                string sensor = Console.ReadLine();
                ISensor inputSensor = CreateSensorByName(sensor);

                if (inputSensor == null)
                {
                    Console.WriteLine("Invalid sensor type. Please try again.");
                    continue;
                }

                totalAttempts++; // ספירת כמות פעמים שהמשתמש הכניס סנסורים

                if (agent is SquadLeader)
                {
                    CheckCounterAttack(agent); // מחיקת סנסור של משתמש רק בסוכן מסוים
                }

                bool found = false;
                for (int i = 0; i < agent.SecretWeaknesses.Length; i++)
                {
                    if (agent.SecretWeaknesses[i] != null && agent.SecretWeaknesses[i].GetType() == inputSensor.GetType())
                    {
                        if (inputSensor is PlusSensor plusMatch)
                        {
                            plusMatch.RegisterUse();
                            plusMatch.Activate();
                        }
                        else
                        {
                            inputSensor.Activate();
                        }
                        agent.Sensor.Add(inputSensor);
                        agent.SecretWeaknesses[i] = null;
                        sensorCount++;
                        found = true;
                        break;
                    }
                }

                if (!found && inputSensor is PlusSensor plusMissed)
                {
                    plusMissed.RegisterUse();
                }
                Console.WriteLine($"you found [{agent.Sensor.Count}/{agent.SecretWeaknesses.Length}]");
            }
            Console.WriteLine("The Agent exposed");
            Console.ReadLine();
        }
        public static void CheckCounterAttack(IAgent agent)
        {
            if (totalAttempts % 3 == 0)
            {
                if (agent.Sensor.Count > 0)
                {
                    Random rnd = new Random();
                    int indexToRemove = rnd.Next(agent.Sensor.Count);
                    agent.Sensor.RemoveAt(indexToRemove);
                    Console.WriteLine($"Counter attack successful! One sensor removed from {agent.Name}.");
                }
                else
                {
                    Console.WriteLine($"Counter attack failed! {agent.Name} has no sensors to remove.");
                }
            }
        }

    }
}



        
    



    

