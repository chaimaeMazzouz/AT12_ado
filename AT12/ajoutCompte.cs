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
    public partial class ajoutCompte : Form
    {
        public ajoutCompte()
        {
            InitializeComponent();
        }
        banqueEntities Bq;
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Bq = new banqueEntities();
            Compte cp = new Compte();
            cp.Num_Compte = int.Parse(textNumCmp.Text);
            cp.Num_Client = int.Parse(comboClient.Text);
            cp.Solde = Convert.ToDecimal(textSolde.Text);
            cp.TypeC = comboTypeC.Text;
            Bq.Comptes.Add(cp);
            Bq.SaveChanges();
            MessageBox.Show("Ajout effectué");
            textSolde.Text = "";
            textNumCmp.Text = "";
            comboClient.Text = "-Faites votre choix-";
            comboTypeC.Text = "-Faites votre choix-";
        }

        private void ajoutCompte_Load(object sender, EventArgs e)
        {
            Bq = new banqueEntities();
            comboClient.DisplayMember = "Num_Client";
            comboClient.ValueMember = "Num_Client";
            comboClient.DataSource = Bq.Clients.Select(c => new { Num_Client = c.Num_client }).ToList();

            comboClient.Text = "-Faites votre choix-";
            comboTypeC.Text = "-Faites votre choix-";
        }
    }
}
