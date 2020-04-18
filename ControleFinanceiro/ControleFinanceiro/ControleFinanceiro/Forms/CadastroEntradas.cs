using ControleFinanceiro.Models;
using ControleFinanceiro.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiro.Forms
{
    public partial class CadastroEntradas : Form
    {
        EntradasService entradasService = new EntradasService();
        public CadastroEntradas()
        {
            InitializeComponent();
        }

        private void CarregaEntradas(object sender, EventArgs e)
        {
            dgvEntradas.DataSource = entradasService.Listar(DateTime.Now.AddMonths(-1), DateTime.Now);
            dgvEntradas.Columns["Id"].Visible = false;
            dtEntrada.Value = DateTime.Now;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            var despesa = new Entrada()
            {
                Descricao = txtDescricao.Text,
                Valor = Convert.ToDecimal(txtValor.Text),
                Data = dtEntrada.Value
            };

            entradasService.Adicionar(despesa);

            MessageBox.Show("Nova entrada adicionada.");

            AtualizarEntradas();
            LimparCampos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        public void AtualizarEntradas()
        {
            dgvEntradas.DataSource = entradasService.Listar(DateTime.Now.AddMonths(-1), DateTime.Now);
        }

        public void LimparCampos()
        {
            btnAtualizar.Visible = false;
            btnExcluir.Visible = false;
            btnIncluir.Visible = true;

            hdnId.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtValor.Text = string.Empty;
            dtEntrada.Value = DateTime.Now;
        }

        public void CarregaEntrada(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            var despesa = new Entrada()
            {
                Id = Convert.ToInt32(hdnId.Text),
                Descricao = txtDescricao.Text,
                Valor = Convert.ToDecimal(txtValor.Text),
                Data = Convert.ToDateTime(dtEntrada.Value)
            };

            entradasService.Atualizar(despesa);

            MessageBox.Show("A entrada foi atualizada.");

            AtualizarEntradas();
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(hdnId.Text);

            entradasService.Excluir(id);

            MessageBox.Show("A entrada foi excluída.");

            AtualizarEntradas();
            LimparCampos();
        }
    }
}
