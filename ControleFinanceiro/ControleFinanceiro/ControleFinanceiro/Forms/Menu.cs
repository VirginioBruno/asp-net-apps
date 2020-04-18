using ControleFinanceiro.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiro
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void lblCadastroDespesas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var cadastro = new CadastroDespesas();

            cadastro.Show();
        }

        private void lblRelatorioDespesas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var relatorio = new RelatorioDespesas();

            relatorio.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var cadastro = new CadastroEntradas();

            cadastro.Show();
        }
    }
}
