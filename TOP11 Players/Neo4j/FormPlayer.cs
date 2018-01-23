using Neo4j.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceStack.Redis;
using Newtonsoft.Json;

namespace Neo4j
{
    public partial class FormPlayer : Form
    {        
        public Igrac i;
        string[] klubovi = { "Arsenal", "Bournemouth", "Brighton", "Burnley", "Chelsea", "Crystal Palace", "Everton", "Huddersfield", "Leicester", "Liverpool",
            "Manchester City", "Manchester Utd", "Newcastle", "Southampton", "Stoke", "Swansea", "Tottenham", "Watford", "WBA", "West Ham" };

        public FormPlayer(Igrac i)
        {
            InitializeComponent();            
            this.i = i;      
        }

        private void FormPlayer_Load(object sender, EventArgs e)
        {
            txtIme.Text = "" + i.first_name;
            txtPrezime.Text = "" + i.second_name;
            txtGolovi.Text = "" + i.goals_scored;
            txtAsistencije.Text = "" + i.assists;
            txtPoeniPoUtakmici.Text = "" + i.points_per_game;
            txtUkupnoPoena.Text = "" + i.total_points;
            
            txtKlub.Text = "" + i.klub;
            txtZutiKartoni.Text = "" + i.yellow_cards;
            txtCrveniKartoni.Text = "" + i.red_cards;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            var redisClient = new RedisClient(Config.SingleHost);

            IgracRedis toEdit = new IgracRedis(i);
            toEdit.klub = klubovi[i.team - 1];
            switch (i.element_type)
            {
                case 1:
                    redisClient.SRem("golman", Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(toEdit)));
                    break;
                case 2:
                    redisClient.SRem("odbrana", Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(toEdit)));
                    break;
                case 3:
                    redisClient.SRem("sredina", Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(toEdit)));
                    break;
                case 4:
                    redisClient.SRem("napad", Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(toEdit)));
                    break;
                default:
                    break;
            }
            toEdit.goals_scored = Int32.Parse(txtGolovi.Text);
            toEdit.assists = Int32.Parse(txtAsistencije.Text);
            toEdit.points_per_game = txtPoeniPoUtakmici.Text;
            toEdit.total_points = Int32.Parse(txtUkupnoPoena.Text);
            toEdit.yellow_cards = Int32.Parse(txtZutiKartoni.Text);
            toEdit.red_cards = Int32.Parse(txtCrveniKartoni.Text);
            
            var json = JsonConvert.SerializeObject(toEdit);
            switch (i.element_type)
            {
                case 1:
                    redisClient.SAdd("golman", Encoding.ASCII.GetBytes(json));
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
                      

            MessageBox.Show("Izmenjeno!");          
        }

        #region KeyPress Eventi
        private void txtIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void txtPrezime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void txtGolovi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && Char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void txtAsistencije_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && Char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void txtPoeniPoUtakmici_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && Char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void txtUkupnoPoena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && Char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void txtZutiKartoni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && Char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void txtCrveniKartoni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && Char.IsLetter(e.KeyChar))
                e.Handled = true;
        }
        #endregion
    }
}
