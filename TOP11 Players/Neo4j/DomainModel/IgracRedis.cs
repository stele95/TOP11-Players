//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4j.DomainModel
{
    public class IgracRedis
    {
        public int id { get; set; } //"id"        
        public int goals_scored { get; set; } //"goals_scored"
        public int assists { get; set; }//"assists":
        public int minutes { get; set; }//"minutes":
        public int yellow_cards { get; set; }//"yellow_cards":
        public int red_cards { get; set; }//"red_cards":
        public int dreamteam_count { get; set; }//"dreamteam_count":
        public int element_type { get; set; }
        
        public string points_per_game { get; set; }
        public int total_points { get; set; }

        public string klub { get; set; }

        public IgracRedis() { }
        public IgracRedis(Igrac igrac)
        {
            id = igrac.id;
            goals_scored = igrac.goals_scored;
            assists = igrac.assists;
            minutes = igrac.minutes;
            yellow_cards = igrac.yellow_cards;
            element_type = igrac.element_type;
            red_cards = igrac.red_cards;
            dreamteam_count = igrac.dreamteam_count;
            points_per_game = igrac.points_per_game;
            total_points = igrac.total_points;            
        }
        
    }
}
