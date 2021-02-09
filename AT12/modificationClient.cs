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
    public partial class modificationClient : Form
    {
        banqueEntities Bq;
        public modificationClient()
        {
            InitializeComponent();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                int N = int.Parse(comboClient.Text.ToString());
                Client cl = Bq.Clients.Where(C => C.Num_client == N).First();
                cl.Nom_client = textNomCl.Text;
                cl.Prenom_Client = textPrenomCl.Text;
                Bq.SaveChanges();
                MessageBox.Show("Modification réussie");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void modificationClient_Load(object sender, EventArgs e)
        {
            Bq = new banqueEntities();
            comboClient.DisplayMember = "Num_Client";
            comboClient.ValueMember = "Num_Client";
            comboClient.DataSource = Bq.Clients.Select(c => new { Num_Client = c.Num_client }).ToList();

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
