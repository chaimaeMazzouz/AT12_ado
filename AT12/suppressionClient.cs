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
    public partial class suppressionClient : Form
    {
        banqueEntities Bq;
        public suppressionClient()
        {
            InitializeComponent();
        }

        private void suppressionClient_Load(object sender, EventArgs e)
        {
            Bq = new banqueEntities();
            comboClient.DisplayMember = "Num_Client";
            comboClient.ValueMember = "Num_Client";
            comboClient.DataSource = Bq.Clients.Select(c => new { Num_Client = c.Num_client }).ToList();

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                int N = int.Parse(comboClient.Text.ToString());
                Client cl = Bq.Clients.Where(C => C.Num_client == N).First();
                Bq.Clients.Remove(cl);
                Bq.SaveChanges();
                MessageBox.Show("Suppression effectué");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int N = int.Parse(comboClient.Text.ToString());
            Client cl = Bq.Clients.Where(C => C.Num_client == N).First();
            textNomCl.Text = cl.Nom_client;
            textPrenomCl.Text = cl.Prenom_Client;
        }
    }
}
