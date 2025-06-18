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

                // נרשום שימוש אם זה פלוס
                if (inputSensor is PlusSensor plus)
                {
                    plus.RegisterUse();
                }

                // ספירת ניסיונות עבור SquadLeader
                bool triggeredCounter = false;
                if (agent is SquadLeader)
                {
                    totalAttempts++;
                    triggeredCounter = CheckCounterAttack(agent, ref sensorCount);  // נעדכן גם את sensorCount במקרה של מתקפה
                }

                bool found = false;

                for (int i = 0; i < agent.SecretWeaknesses.Length; i++)
                {
                    if (agent.SecretWeaknesses[i] != null &&
                        agent.SecretWeaknesses[i].GetType() == inputSensor.GetType())
                    {
                        inputSensor.Activate();
                        agent.Sensor.Add(inputSensor);
                        agent.SecretWeaknesses[i] = null;
                        sensorCount++;
                        found = true;
                        break;
                    }
                }

                // הדפסה רק אם לא הופעלה מתקפה (היא כבר מדפיסה)
                if (!triggeredCounter)
                {
                    Console.WriteLine($"you found [{sensorCount}/{agent.SecretWeaknesses.Length}]");
                }
            }

            Console.WriteLine("The Agent exposed");
            Console.ReadLine();
        }

        
        public static bool CheckCounterAttack(IAgent agent, ref int sensorCount)
        {
            if (totalAttempts % 3 == 0)
            {
                if (agent.Sensor.Count > 0)
                {
                    Random rnd = new Random();
                    int indexToRemove = rnd.Next(agent.Sensor.Count);
                    agent.Sensor.RemoveAt(indexToRemove);
                    sensorCount = Math.Max(0, sensorCount - 1);

                    Console.WriteLine($"Counter attack successful! One sensor removed from {agent.Name}.");
                }
                else
                {
                    Console.WriteLine($"Counter attack failed! {agent.Name} has no sensors to remove.");
                }

                Console.WriteLine($"you found [{sensorCount}/{agent.SecretWeaknesses.Length}]");
                return true; // הופעלה מתקפת נגד
            }
            return false; // לא הופעלה מתקפת נגד
        }

    }



}




        
    



    

