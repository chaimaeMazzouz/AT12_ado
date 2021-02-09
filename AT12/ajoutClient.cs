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
    public partial class ajoutClient : Form
    {
        public ajoutClient()
        {
            InitializeComponent();
        }

        private void ajoutClient_Load(object sender, EventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (textNomCl.Text != "" && textNumClient.Text != "" && textPrenomCl.Text != "")
            {
                try
                {
                    banqueEntities Bq = new banqueEntities();
                    Client cl = new Client();
                    cl.Nom_client = textNomCl.Text;
                    cl.Num_client = int.Parse(textNumClient.Text);
                    cl.Prenom_Client = textPrenomCl.Text;
                    Bq.Clients.Add(cl);
                    Bq.SaveChanges();
                    MessageBox.Show("Ajout effectué");
                    textPrenomCl.Text = "";
                    textNomCl.Text = "";
                    textNumClient.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Remplir les champs SVP!");
            }
        }
    }
}
