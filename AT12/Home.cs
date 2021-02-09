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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        void Changer_Form(Form NewForm)
        {
            if (this.ActiveMdiChild != null) this.ActiveMdiChild.Close();
            NewForm.MdiParent = this;
            NewForm.Dock = DockStyle.Fill;
            NewForm.Show();
        }
        private void consultationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Changer_Form(new consultationClient());
        }

        private void ajoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Changer_Form(new ajoutClient());

        }

        private void suppressionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Changer_Form(new suppressionClient());
        }

        private void modificationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Changer_Form(new modificationClient());
        }

        private void rechercheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Changer_Form(new recherche_client_compte());
        }

        private void consultationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Changer_Form(new consultationCompte());
        }

        private void ajoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Changer_Form(new ajoutCompte());
        }

        private void suppressionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Changer_Form(new suppressionCompte());
        }

        private void modificationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Changer_Form(new modificationCompte());
        }

        private void rechercheToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Changer_Form(new recherche_compte_client());

        }

        private void dépotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Changer_Form(new mouvementDepot());

        }

        private void retraitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Changer_Form(new mouvementRetrait());
        }

        private void virementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Changer_Form(new ajoutVairement());

        }
    }
}
