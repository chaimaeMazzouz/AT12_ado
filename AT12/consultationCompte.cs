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
    public partial class consultationCompte : Form
    {
        public consultationCompte()
        {
            InitializeComponent();
        }

        private void consultationCompte_Load(object sender, EventArgs e)
        {

            banqueEntities bnq = new banqueEntities();
            dataGridView1.DataSource = bnq.Comptes.Select(pl => new { pl.Num_Compte, pl.Num_Client, pl.Solde, pl.TypeC }).ToList();

        }
    }
}
