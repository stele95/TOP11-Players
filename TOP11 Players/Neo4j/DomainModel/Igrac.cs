﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4j.DomainModel
{
    public class Igrac
    {
        public int id { get; set; } //"id"
        public String first_name { get; set; } // "first_name":
        public String second_name { get; set; } // "second_name"
        public int goals_scored { get; set; } //"goals_scored"
        public int assists { get; set; }//"assists":
        public int minutes { get; set; }//"minutes":
        public int yellow_cards { get; set; }//"yellow_cards":
        public int red_cards { get; set; }//"red_cards":
        public int dreamteam_count { get; set; }//"dreamteam_count":

        public int team { get; set; }

        public string klub { get; set; }
        public int element_type { get; set; }


        public string points_per_game { get; set; }
        public int total_points { get; set; }

        public Igrac() { }

        public Igrac(Igrac igrac, IgracRedis igracRedis)
        {
            id = igrac.id;
            first_name = igrac.first_name;
            second_name = igrac.second_name;
            team = igrac.team;
            element_type = igrac.element_type;

            goals_scored = igracRedis.goals_scored;
            assists = igracRedis.assists;
            minutes = igracRedis.minutes;
            yellow_cards = igracRedis.yellow_cards;
            red_cards = igracRedis.red_cards;
            dreamteam_count = igracRedis.dreamteam_count;
            points_per_game = igracRedis.points_per_game;
            total_points = igracRedis.total_points;
            klub = igracRedis.klub;
        }


        override
        public string ToString()
        {
            return first_name + " " + second_name;
        }
        
        //public int id { get; set; }
        //public string photo { get; set; }
        //public string web_name { get; set; }
        //public string status { get; set; }
        //public int code { get; set; }
        //public string first_name { get; set; }
        //public string second_name { get; set; }
        //public int squad_number { get; set; }
        //public string news { get; set; }
        //public int now_cost { get; set; }
        //public DateTime news_added { get; set; }
        //public int chance_of_playing_this_round { get; set; }
        //public int chance_of_playing_next_round { get; set; }
        //public string value_form { get; set; }
        //public string value_season { get; set; }
        //public int cost_change_start { get; set; }
        //public int cost_change_event { get; set; }
        //public int cost_change_start_fall { get; set; }
        //public int cost_change_event_fall { get; set; }
        //public bool in_dreamteam { get; set; }
        //public int dreamteam_count { get; set; }
        //public string selected_by_percent { get; set; }
        //public string form { get; set; }
        //public int transfers_out { get; set; }
        //public int transfers_in { get; set; }
        //public int transfers_out_event { get; set; }
        //public int transfers_in_event { get; set; }
        //public int loans_in { get; set; }
        //public int loans_out { get; set; }
        //public int loaned_in { get; set; }
        //public int loaned_out { get; set; }
        //public int total_points { get; set; }
        //public int event_points { get; set; }
        //public string points_per_game { get; set; }
        //public string ep_this { get; set; }
        //public string ep_next { get; set; }
        //public bool special { get; set; }
        //public int minutes { get; set; }
        //public int goals_scored { get; set; }
        //public int assists { get; set; }
        //public int clean_sheets { get; set; }
        //public int goals_conceded { get; set; }
        //public int own_goals { get; set; }
        //public int penalties_saved { get; set; }
        //public int penalties_missed { get; set; }
        //public int yellow_cards { get; set; }
        //public int red_cards { get; set; }
        //public int saves { get; set; }
        //public int bonus { get; set; }
        //public int bps { get; set; }
        //public string influence { get; set; }
        //public string creativity { get; set; }
        //public string threat { get; set; }
        //public string ict_index { get; set; }
        //public int ea_index { get; set; }
        
        //public int team { get; set; }
        
    }



}

