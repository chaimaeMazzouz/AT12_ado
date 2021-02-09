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
    public partial class recherche_compte_client : Form
    {
        banqueEntities Bq;
        public recherche_compte_client()
        {
            InitializeComponent();
        }

        private void recherche_compte_client_Load(object sender, EventArgs e)
        {
            Bq = new banqueEntities();
            comboCompte.DisplayMember = "Num_Compte";
            comboCompte.ValueMember = "Num_Compte";
            comboCompte.DataSource = Bq.Comptes.Select(c => new { Num_Compte = c.Num_Compte }).ToList();
            comboCompte.Text = "-Faites Votre Choix-";
            dataGridView1.DataSource = null;
        }

        private void comboCompte_SelectedIndexChanged(object sender, EventArgs e)
        {
            int N = int.Parse(comboCompte.SelectedValue.ToString());
            dataGridView1.DataSource = Bq.Comptes.Where(c => c.Num_Compte == N).Select(c => new { c.Num_Compte, c.Num_Client, c.Solde, c.TypeC }).ToList();
            dataGridView1.Refresh();
        }
    }
}
