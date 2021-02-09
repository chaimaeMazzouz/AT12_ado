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
    public partial class ajoutVairement : Form
    {
        public ajoutVairement()
        {
            InitializeComponent();
        }
        banqueEntities Bq;
        private void ajoutVairement_Load(object sender, EventArgs e)
        {
            Bq = new banqueEntities();
            comboCrediteur.DisplayMember = "Num_Compte";
            comboCrediteur.ValueMember = "Num_Compte";
            comboCrediteur.DataSource = Bq.Comptes.Select(c => new { Num_Compte = c.Num_Compte }).ToList();
            comboCrediteur.Text = "--Faites votre choix--";

            comboDebiteur.DisplayMember = "Num_Compte";
            comboDebiteur.ValueMember = "Num_Compte";
            comboDebiteur.DataSource = Bq.Comptes.Select(c => new { Num_Compte = c.Num_Compte }).ToList();
            comboDebiteur.Text = "--Faites votre choix--";

            dataGridView1.DataSource = Bq.Comptes.Select(cp => new { cp.Num_Compte, cp.Solde }).ToList();
            dataGridView2.DataSource = Bq.Virements.Select(mvt => new { mvt.Num_Virement, mvt.Num_Debiteur, mvt.Num_Crediteur,mvt.Montant_Vr,mvt.Date_Vr }).ToList();

        }

        private void btbVirer_Click(object sender, EventArgs e)
        {
            if (comboDebiteur.Text != "--Faites votre choix--" && comboCrediteur.Text != "--Faites votre choix--" && textMontant.Text != "")
            {
                int Ndb = int.Parse(comboDebiteur.Text.ToString());
                int Ncr = int.Parse(comboCrediteur.Text.ToString());
                decimal Mt = decimal.Parse(textMontant.Text);
                bool b;
                Bq.ps_Virement(Ndb, Ncr, Mt);
                MessageBox.Show("virement effectué");
                comboCrediteur.Text = "--Faites votre choix--";
                comboDebiteur.Text = "--Faites votre choix--";
                textMontant.Clear();

                dataGridView1.DataSource = Bq.Comptes.Select(cp => new { cp.Num_Compte, cp.Solde }).ToList();
                dataGridView2.DataSource = Bq.Virements.Select(mvt => new { mvt.Num_Virement, mvt.Num_Debiteur, mvt.Num_Crediteur, mvt.Montant_Vr, mvt.Date_Vr }).ToList();

            }
            else
            {
                MessageBox.Show("Tous les champs sont obligatoires");
            }

        }
    }
}
