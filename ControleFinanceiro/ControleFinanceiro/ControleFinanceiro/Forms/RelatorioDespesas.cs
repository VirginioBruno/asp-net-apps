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
    public partial class RelatorioDespesas : Form
    {
        private readonly DespesasService despesasService = new DespesasService();
        public RelatorioDespesas()
        {
            InitializeComponent();
        }

        private void RelatorioDespesas_Load(object sender, EventArgs e)
        {
            dgvDespesas.DataSource = despesasService.Listar(DateTime.Now.AddMonths(-1), DateTime.Now);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvDespesas.DataSource = despesasService.Listar(dtInicio.Value, dtFim.Value);
        }
    }
}
