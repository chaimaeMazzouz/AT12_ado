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
    public partial class suppressionCompte : Form
    {
        banqueEntities Bq;
        public suppressionCompte()
        {
            InitializeComponent();
        }

        private void suppressionCompte_Load(object sender, EventArgs e)
        {
            Bq = new banqueEntities();
            comboCompte.DisplayMember = "Num_Compte";
            comboCompte.ValueMember = "Num_Compte";
            comboCompte.DataSource = Bq.Comptes.Select(c => new { Num_Compte = c.Num_Compte }).ToList();

        }

        private void comboCompte_SelectedIndexChanged(object sender, EventArgs e)
        {
            int N = int.Parse(comboCompte.Text.ToString());
            Compte cl = Bq.Comptes.Where(C => C.Num_Compte == N).First();
            textClient.Text = cl.Num_Client.ToString();
            textSolde.Text = cl.Solde.ToString();
            textTypeC.Text = cl.TypeC;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int N = int.Parse(comboCompte.Text.ToString());
            Compte cl = Bq.Comptes.Where(C => C.Num_Compte == N).First();
            Bq.Comptes.Remove(cl);
            Bq.SaveChanges();
            MessageBox.Show("Suppression effectué");
            this.Close();
        }
    }
}
