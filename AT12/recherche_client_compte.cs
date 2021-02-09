using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AT12
{
    public partial class recherche_client_compte : Form
    {
        banqueEntities Bq;
        public recherche_client_compte()
        {
            InitializeComponent();
        }

        private void comboClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int N = int.Parse(comboClient.SelectedValue.ToString());
            dataGridView1.DataSource = Bq.Clients.Where(c => c.Num_client == N).Select(c => new { c.Num_client, c.Nom_client, c.Prenom_Client }).ToList();
            dataGridView1.Refresh();
        }

        private void recherche_client_compte_Load(object sender, EventArgs e)
        {
            Bq = new banqueEntities();
            comboClient.DisplayMember = "Nom";
            comboClient.ValueMember = "Num";
            comboClient.DataSource = Bq.Clients.Select(c => new { Nom = c.Nom_client + " " + c.Prenom_Client, Num = c.Num_client }).ToList();
            comboClient.Text = "-Faites Votre Choix-";
            dataGridView1.DataSource = null;
        }
    }
}
