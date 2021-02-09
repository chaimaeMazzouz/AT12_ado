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
    public partial class mouvementRetrait : Form
    {
        public mouvementRetrait()
        {
            InitializeComponent();
        }
        banqueEntities Bq;
        private void mouvementRetrait_Load(object sender, EventArgs e)
        {
            Bq = new banqueEntities();
            comboNuComp.DisplayMember = "Num_Compte";
            comboNuComp.ValueMember = "Num_Compte";
            comboNuComp.DataSource = Bq.Comptes.Select(c => new { Num_Compte = c.Num_Compte }).ToList();
            comboNuComp.Text = "--Faites votre choix--";
            dataGridView1.DataSource = Bq.Comptes.Select(cp => new { cp.Num_Compte, cp.Solde }).ToList();
            dataGridView2.DataSource = Bq.Mouvements.Select(mvt => new { mvt.Num_Mouvement, mvt.Num_Compte, mvt.Montant }).ToList();

        }

        private void btbRetrait_Click(object sender, EventArgs e)
        {
            if (comboNuComp.Text != "" && comboNuComp.Text != "--Faites votre choix--" && textMontant.Text != "")
            {
                int c = Bq.Mouvements.Count();
                Bq.ps_Retrait(int.Parse(comboNuComp.SelectedValue.ToString()), decimal.Parse(textMontant.Text));
                int c1 = Bq.Mouvements.Count();
                if (c == c1)
                {
                    MessageBox.Show("Opération rejetée");
                }
                else
                {
                    MessageBox.Show("Retrait effectué");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Tous les champs sont obligatoires");
            }

        }
    }
}
