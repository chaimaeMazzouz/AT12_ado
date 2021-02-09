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
    public partial class modificationCompte : Form
    {
        banqueEntities Bq;
        public modificationCompte()
        {
            InitializeComponent();
        }

        private void modificationCompte_Load(object sender, EventArgs e)
        {
            Bq = new banqueEntities();
            comboCompte.DisplayMember = "Num_Compte";
            comboCompte.ValueMember = "Num_Compte";
            comboCompte.DataSource = Bq.Comptes.Select(c => new { Num_Compte = c.Num_Compte }).ToList();

            comboClient.DisplayMember = "Num_Client";
            comboClient.ValueMember = "Num_Client";
            comboClient.DataSource = Bq.Clients.Select(c => new { Num_Client = c.Num_client }).ToList();

        }

        private void comboCompte_SelectedIndexChanged(object sender, EventArgs e)
        {
            int N = int.Parse(comboCompte.Text.ToString());
            Compte cl = Bq.Comptes.Where(C => C.Num_Compte == N).First();
            comboClient.Text = cl.Num_Client.ToString();
            textSolde.Text = cl.Solde.ToString();
            textTypeC.Text = cl.TypeC;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                int N = int.Parse(comboCompte.Text.ToString());
                Compte cl = Bq.Comptes.Where(C => C.Num_Compte == N).First();
                cl.Num_Client = int.Parse(comboClient.Text);
                cl.Solde = Convert.ToDecimal(textSolde.Text);
                cl.TypeC = textTypeC.Text;
                Bq.SaveChanges();
                MessageBox.Show("Modification réussie");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
