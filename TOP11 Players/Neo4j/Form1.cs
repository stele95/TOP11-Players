using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neo4j.DomainModel;
using Neo4jClient;
using Neo4jClient.Cypher;
using Newtonsoft.Json;
using System.Net;
using ServiceStack.Redis;
using System.Threading;

namespace Neo4j
{
    public partial class Form1 : Form
    {
        
        public List<Igrac> odbrana;
        public List<Igrac> sredina;
        public List<Igrac> napad;        
        public Igrac golman;
        public Igrac KliknutIgrac;
        public GraphClient client;

        string[] klubovi = { "Arsenal", "Bournemouth", "Brighton", "Burnley", "Chelsea", "Crystal Palace", "Everton", "Huddersfield", "Leicester", "Liverpool",
            "Manchester City", "Manchester Utd", "Newcastle", "Southampton", "Stoke", "Swansea", "Tottenham", "Watford", "WBA", "West Ham" };


        public Form1()
        {
           
            InitializeComponent();
            button1.Visible=false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;

        }

        public void PrintTop11()
        {
            if (golman == null)
            {
                label1.Text = "Nisu ucitani podaci u bazu!\nMolimo Vas da ih ucitate!\nDataBase->Ucitaj podatke u bazu";
                return;
            }
            button1.Text = golman.ToString();
            button2.Text = odbrana[0].ToString();
            button3.Text = odbrana[1].ToString();
            button4.Text = odbrana[2].ToString();
            button5.Text = odbrana[3].ToString();
            button6.Text = sredina[0].ToString();
            button7.Text = sredina[1].ToString();
            button8.Text = sredina[2].ToString();
            button9.Text = sredina[3].ToString();
            button10.Text = napad[0].ToString();
            button11.Text = napad[1].ToString();

            label1.Visible = false;

            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;

        }

        public void LoadTop11()
        {
            label1.Text = "Ucitavam...";

            odbrana = new List<Igrac>();
            sredina = new List<Igrac>();
            napad = new List<Igrac>();

            /*
            //odbrana
            var query = new Neo4jClient.Cypher.CypherQuery("MATCH (player:Igrac) WHERE player.element_type = 2 RETURN player ORDER BY player.total_points DESC LIMIT 4",
                                                    new Dictionary<string, object>(), CypherResultMode.Set);          
            odbrana = ((IRawGraphClient)client).ExecuteGetCypherResults<Igrac>(query).ToList();


            //sredina
            query = new Neo4jClient.Cypher.CypherQuery("MATCH (player:Igrac) WHERE player.element_type = 3 RETURN player ORDER BY player.total_points DESC LIMIT 4",
                                                    new Dictionary<string, object>(), CypherResultMode.Set);
            sredina = ((IRawGraphClient)client).ExecuteGetCypherResults<Igrac>(query).ToList();


            //napad
            query = new Neo4jClient.Cypher.CypherQuery("MATCH (player:Igrac) WHERE player.element_type = 4 RETURN player ORDER BY player.total_points DESC LIMIT 2",
                                                    new Dictionary<string, object>(), CypherResultMode.Set);
            napad = ((IRawGraphClient)client).ExecuteGetCypherResults<Igrac>(query).ToList();


            //golman
            query = new Neo4jClient.Cypher.CypherQuery("MATCH (player:Igrac) WHERE player.element_type = 1 RETURN player ORDER BY player.total_points DESC LIMIT 1",
                                                    new Dictionary<string, object>(), CypherResultMode.Set);
            golman = ((IRawGraphClient)client).ExecuteGetCypherResults<Igrac>(query).FirstOrDefault();*/


            //golman
            List<IgracRedis> listaGolman = readFromRedis("golman");
            IgracRedis golmanRedis = listaGolman.OrderByDescending(x => x.total_points).ToList().FirstOrDefault();
            if (golmanRedis == null)
            {
                return;
            }
            var query = new Neo4jClient.Cypher.CypherQuery("MATCH (player:Igrac) WHERE player.id = " + golmanRedis.id + " RETURN player LIMIT 1",
                                                    new Dictionary<string, object>(), CypherResultMode.Set);
            Igrac golman1 = ((IRawGraphClient)client).ExecuteGetCypherResults<Igrac>(query).FirstOrDefault();
            golman = new Igrac(golman1, golmanRedis);


            //odbrana
            List<IgracRedis> listaOdbrana = readFromRedis("odbrana");
            List<IgracRedis> odbranaRedisList = listaOdbrana.OrderByDescending(x => x.total_points).Take(4).ToList();
            for (int i = 0; i < odbranaRedisList.Count; i++)
            {
                query = new Neo4jClient.Cypher.CypherQuery("MATCH (player:Igrac) WHERE player.id = " + odbranaRedisList[i].id + " RETURN player LIMIT 1",
                                                    new Dictionary<string, object>(), CypherResultMode.Set);
                Igrac igrac = ((IRawGraphClient)client).ExecuteGetCypherResults<Igrac>(query).FirstOrDefault();
                odbrana.Add(new Igrac(igrac, odbranaRedisList[i]));
            }

            //sredina
            List<IgracRedis> listaSredina = readFromRedis("sredina");
            List<IgracRedis> sredinaRedisList = listaSredina.OrderByDescending(x => x.total_points).Take(4).ToList();
            for (int i = 0; i < sredinaRedisList.Count; i++)
            {
                query = new Neo4jClient.Cypher.CypherQuery("MATCH (player:Igrac) WHERE player.id = " + sredinaRedisList[i].id + " RETURN player LIMIT 1",
                                                    new Dictionary<string, object>(), CypherResultMode.Set);
                Igrac igrac = ((IRawGraphClient)client).ExecuteGetCypherResults<Igrac>(query).FirstOrDefault();
                sredina.Add(new Igrac(igrac, sredinaRedisList[i]));
            }

            //napad
            List<IgracRedis> listaNapad = readFromRedis("napad");
            List<IgracRedis> NapadRedisList = listaNapad.OrderByDescending(x => x.total_points).Take(2).ToList();
            for (int i = 0; i < NapadRedisList.Count; i++)
            {
                query = new Neo4jClient.Cypher.CypherQuery("MATCH (player:Igrac) WHERE player.id = " + NapadRedisList[i].id + " RETURN player LIMIT 1",
                                                    new Dictionary<string, object>(), CypherResultMode.Set);
                Igrac igrac = ((IRawGraphClient)client).ExecuteGetCypherResults<Igrac>(query).FirstOrDefault();
                napad.Add(new Igrac(igrac, NapadRedisList[i]));
            }

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {            
            client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "starwars5");
            try
            {                
                client.Connect();                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        
        private void loadPlayers()
        {
            var url = "https://fantasy.premierleague.com/drf/elements/";

            using (var w = new WebClient())
            {
                byte[] bitovi;
                Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                Encoding utf8 = Encoding.UTF8;
                try
                {
                    bitovi = w.DownloadData(url);
                    byte[] isoBytes = Encoding.Convert(utf8, iso, bitovi);
                    string msg = iso.GetString(isoBytes);

                    List<Igrac> list = JsonConvert.DeserializeObject<List<Igrac>>(msg);

                    foreach (Igrac b in list)
                    {

                        Dictionary<string, object> queryDict = new Dictionary<string, object>();
                        queryDict.Add("first_name", b.first_name);
                        queryDict.Add("second_name", b.second_name);
                        queryDict.Add("id", b.id);
                        queryDict.Add("team", b.team);
                        queryDict.Add("element_type", b.element_type);

                        /*queryDict.Add("goals_scored", b.goals_scored);
                        queryDict.Add("assists", b.assists);
                        queryDict.Add("minutes", b.minutes);
                        queryDict.Add("yellow_cards", b.yellow_cards);
                        queryDict.Add("red_cards", b.red_cards);
                        queryDict.Add("dreamteam_count", b.dreamteam_count);
                        queryDict.Add("points_per_game", b.points_per_game);
                        queryDict.Add("total_points", b.total_points);

                        var query = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Igrac {id:" + b.id + ", first_name:'" + b.first_name +
                            "', second_name:'" + b.second_name + "', goals_scored:" + b.goals_scored + ", assists:" + b.assists + ", minutes:" + b.minutes +
                            ", yellow_cards:" + b.yellow_cards + ", red_cards:" + b.red_cards + ", dreamteam_count:" + b.dreamteam_count +
                            ", points_per_game:'" + b.points_per_game + "', team:" + b.team + ", element_type:" + b.element_type + ", total_points:" + b.total_points + "}) return n", queryDict, CypherResultMode.Set);*/


                        var query = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Igrac {id:" + b.id + ", first_name:'" + b.first_name +
                            "', second_name:'" + b.second_name + "', team:" + b.team + ", element_type:" + b.element_type + "}) return n", queryDict, CypherResultMode.Set);

                        ((IRawGraphClient)client).ExecuteCypherAsync(query);

                        IgracRedis igrac = new IgracRedis(b);
                        igrac.klub = klubovi[b.team-1];
                        saveToRedis(igrac);
                       
                    }
                }
                catch (Exception eb)
                {
                    MessageBox.Show(eb.Message);
                }

            }
        }

        private void createRelations()
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Igrac) return n",
                                                            queryDict, CypherResultMode.Set);

            List<Igrac> list = ((IRawGraphClient)client).ExecuteGetCypherResults<Igrac>(query).ToList();

            foreach (Igrac b in list)
            {
                var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (n:Igrac {id:" + b.id + "}), (k:Klub {id:" + b.team + "}) MERGE (n)-[:IgraU]->(k)", queryDict, CypherResultMode.Set);
                ((IRawGraphClient)client).ExecuteCypherAsync(query1);

                var query2 = new Neo4jClient.Cypher.CypherQuery("MATCH (n:Igrac {id:" + b.id + " }), (p:Pozicija {id:" + b.element_type + "}) MERGE (n)-[:Pozicija]->(p)", queryDict, CypherResultMode.Set);
                ((IRawGraphClient)client).ExecuteCypherAsync(query2);
            }
        }

        private void createClubsAndPositions()
        {
            
            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            //klubovi
            var query = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 1 + ", name:'Arsenal'}) return n", queryDict, CypherResultMode.Set);            
            ((IRawGraphClient)client).ExecuteCypherAsync(query);

            var query1 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 2 + ", name:'Bournemouth'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query1);

            var query2 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 3 + ", name:'Brighton'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query2);

            var query3 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 4 + ", name:'Burnley'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query3);

            var query4 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 5 + ", name:'Chelsea'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query4);

            var query5 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 6 + ", name:'Crystal Palace'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query5);

            var query6 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 7 + ", name:'Everton'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query6);

            var query7 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 8 + ", name:'Huddersfield'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query7);

            var query8 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 9 + ", name:'Leicester'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query8);

            var query9 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 10 + ", name:'Liverpool'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query9);

            var query10 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 11 + ", name:'Manchester City'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query10);

            var query11 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 12 + ", name:'Manchester Utd'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query11);

            var query12 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 13 + ", name:'Newcastle'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query12);

            var query13 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 14 + ", name:'Southampton'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query13);

            var query14 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 15 + ", name:'Stoke'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query14);

            var query15 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 16 + ", name:'Swansea'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query15);

            var query16 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 17 + ", name:'Tottenham'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query16);

            var query17 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 18 + ", name:'Watford'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query17);

            var query18 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 19 + ", name:'WBA'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query18);

            var query19 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Klub {id:" + 20 + ", name:'West Ham'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query19);
         

            //pozicije
            var query20 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Pozicija {id:" + 1 + ", name:'golman'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query20);

            var query21 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Pozicija {id:" + 2 + ", name:'odbrana'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query21);

            var query22 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Pozicija {id:" + 3 + ", name:'sredina'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query22);

            var query23 = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Pozicija {id:" + 4 + ", name:'napad'}) return n", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypherAsync(query23);

        }

        #region Button Clicks
        private void button1_Click(object sender, EventArgs e)
        {           
            FormPlayer formPlayer = new FormPlayer(golman);
            formPlayer.ShowDialog();
            LoadTop11();
            PrintTop11();
        }

        private void button2_Click(object sender, EventArgs e)
        {          
            FormPlayer formPlayer = new FormPlayer(odbrana[0]);
            formPlayer.ShowDialog();
            LoadTop11();
            PrintTop11();
        }

        private void button3_Click(object sender, EventArgs e)
        {                    
            FormPlayer formPlayer = new FormPlayer(odbrana[1]);
            formPlayer.ShowDialog();
            LoadTop11();
            PrintTop11();
        }

        private void button4_Click(object sender, EventArgs e)
        {           
            FormPlayer formPlayer = new FormPlayer(odbrana[2]);
            formPlayer.ShowDialog();
            LoadTop11();
            PrintTop11();
        }

        private void button5_Click(object sender, EventArgs e)
        {          
            FormPlayer formPlayer = new FormPlayer(odbrana[3]);
            formPlayer.ShowDialog();
            LoadTop11();
            PrintTop11();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormPlayer formPlayer = new FormPlayer(sredina[0]);
            formPlayer.ShowDialog();
            LoadTop11();
            PrintTop11();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormPlayer formPlayer = new FormPlayer(sredina[1]);
            formPlayer.ShowDialog();
            LoadTop11();
            PrintTop11();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormPlayer formPlayer = new FormPlayer(sredina[2]);
            formPlayer.ShowDialog();
            LoadTop11();
            PrintTop11();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormPlayer formPlayer = new FormPlayer(sredina[3]);
            formPlayer.ShowDialog();
            LoadTop11();
            PrintTop11();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormPlayer formPlayer = new FormPlayer(napad[0]);
            formPlayer.ShowDialog();
            LoadTop11();
            PrintTop11();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FormPlayer formPlayer = new FormPlayer(napad[1]);
            formPlayer.ShowDialog();
            LoadTop11();
            PrintTop11();
        }
        #endregion

        private void tsmNapuni_Click(object sender, EventArgs e)
        {
            label1.Text = "Ucitavam u bazu...";
            MessageBox.Show("Ovaj proces traje 15 - 20 sekundi zbog velikog broja igraca.\nMolimo Vas da budete strpljivi.");
            timer1.Start();
            createClubsAndPositions();
            loadPlayers();
            createRelations();
            //label1.Text = "Gotovo!\nUcitajte TOP11!";
        }

        private void tsmUcitaj_Click(object sender, EventArgs e)
        {
            LoadTop11();
            PrintTop11();
        }       

        private void saveToRedis(IgracRedis igrac)
        {           
            var json = JsonConvert.SerializeObject(igrac);

            var redisClient = new RedisClient(Config.SingleHost);

            switch (igrac.element_type)
            {
                case 1:
                    redisClient.SAdd("golman",Encoding.ASCII.GetBytes(json));
                    break;
                case 2:
                    redisClient.SAdd("odbrana", Encoding.ASCII.GetBytes(json));
                    break;
                case 3:
                    redisClient.SAdd("sredina", Encoding.ASCII.GetBytes(json));
                    break;
                case 4:
                    redisClient.SAdd("napad", Encoding.ASCII.GetBytes(json));
                    break;
            }
        }

        private List<IgracRedis> readFromRedis(string key)
        {
            var redisClient = new RedisClient(Config.SingleHost);

            byte[][] bitovi = redisClient.SMembers(key);

            List<IgracRedis> lista = new List<IgracRedis>();

            for(int i=0;i<bitovi.Length;i++)
            {                
                lista.Add(JsonConvert.DeserializeObject<IgracRedis>(Encoding.ASCII.GetString(bitovi[i])));
            }

            return lista;
        }

        int br=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(br!=15)
            {
                br++;
            }
            else
            {
                br = 0;
                label1.Text = "Ucitavanje je zavrseno!\nUcitajte TOP11!";
                timer1.Stop();
            }
        }
    }
}





