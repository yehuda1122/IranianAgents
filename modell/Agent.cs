using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranianAgents
{
    //public enum AgentRank
    //{
    //    Captain,
    //    SquadLeader,
    //    CompanyLeader,
    //    Senior
    //}


    public abstract class IAgent 
    {
       public string Name { get; set; }
        //AgentRank Rank { get; set; }
       public List<ISensor> Sensor { get; set; }
       public ISensor[] SecretWeaknesses { get; set; }


    }
    class SimpleAgent : IAgent
    {
        public SimpleAgent(string name)
        {
            Name = name;
            Sensor = new List<ISensor>();
            SecretWeaknesses = new ISensor[2]; // כל סוכן פשוט יקבל 2 חולשות
        }
        

    }
}
