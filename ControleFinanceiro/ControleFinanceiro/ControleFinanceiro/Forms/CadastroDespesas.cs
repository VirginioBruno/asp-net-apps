﻿using ControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControleFinanceiro
{
    public partial class CadastroDespesas : Form
    {
        DespesasService despesasService = new DespesasService();

        public CadastroDespesas()
        {
            InitializeComponent();
        }

        private void CarregaDespesas(object sender, EventArgs e)
        {
            dgvDespesas.DataSource = despesasService.ListarAtual();
            dtDespesa.Value = DateTime.Now;
            CarregaTipos();
        }

        private void CarregaTipos()
        {
            var tipos = new List<TipoDespesa>()
            {
                new TipoDespesa { Id = 1, Nome = "Fixo" },
                new TipoDespesa { Id = 2, Nome = "Parcelado" },
                new TipoDespesa { Id = 3, Nome = "Outros" }
            };

            cboTipo.DataSource = tipos;
            cboTipo.DisplayMember = "Nome";
            cboTipo.ValueMember = "Id";
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            var despesa = new Despesa() {
                Nome = txtDespesa.Text,
                Valor = Convert.ToDecimal(txtValor.Text),
                Categoria = txtCategoria.Text,
                TipoId = cboTipo.SelectedIndex,
                Data = dtDespesa.Value
            };

            despesasService.Adicionar(despesa);

            MessageBox.Show("Nova despesa adicionada.");

            AtualizarDespesas();
            LimparCampos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        public void AtualizarDespesas()
        {
            dgvDespesas.DataSource = despesasService.ListarAtual();
        }

        public void LimparCampos()
        {
            btnAtualizar.Visible = false;
            btnExcluir.Visible = false;
            btnIncluir.Visible = true;

            hdnId.Text = string.Empty;
            txtDespesa.Text = string.Empty;
            txtValor.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            dtDespesa.Value = DateTime.Now;
        }

        public void CarregaDespesa(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDespesas.Rows[e.RowIndex];
                hdnId.Text = row.Cells[0].Value.ToString();
                txtDespesa.Text = row.Cells[1].Value.ToString();
                txtValor.Text = row.Cells[2].Value.ToString();
                txtCategoria.Text = row.Cells[3].Value.ToString();
                cboTipo.SelectedIndex = Convert.ToInt32(row.Cells[4].Value);
                dtDespesa.Value = Convert.ToDateTime(row.Cells[5].Value);

                btnAtualizar.Visible = true;
                btnExcluir.Visible = true;
                btnIncluir.Visible = false;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            var despesa = new Despesa()
            {
                Id = Convert.ToInt32(hdnId.Text),
                Nome = txtDespesa.Text,
                Categoria = txtCategoria.Text,
                TipoId = cboTipo.SelectedIndex,
                Valor = Convert.ToDecimal(txtValor.Text),
                Data = Convert.ToDateTime(dtDespesa.Value)
            };

            despesasService.Atualizar(despesa);

            MessageBox.Show("A despesa foi atualizada.");

            AtualizarDespesas();
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(hdnId.Text);

            despesasService.Excluir(id);

            MessageBox.Show("A despesa foi excluída.");

            AtualizarDespesas();
            LimparCampos();
        }

        private void dtDespesa_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}