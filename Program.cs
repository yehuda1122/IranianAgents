using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranianAgents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SimpleAgent agent = new SimpleAgent("Agent007");

            //AllSensor.AddSensor(agent);
            //Maneger.run(agent);

            SquadLeader squadLeader = new SquadLeader("SquadLeader");

            AllSensor.AddSensor(squadLeader);
            Maneger.run(squadLeader);

        }
    }
}
