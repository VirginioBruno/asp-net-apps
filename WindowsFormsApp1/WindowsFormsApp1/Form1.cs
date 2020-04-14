using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Context;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Database.EnsureCreated();

                var produtos = context.TB_TST_PRODUTO.ToList();

                dataGridView1.DataSource = produtos;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
