namespace ControleFinanceiro
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblCadastroDespesas = new System.Windows.Forms.LinkLabel();
            this.lblRelatorioDespesas = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Controle Financeiro 1.0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCadastroDespesas
            // 
            this.lblCadastroDespesas.AutoSize = true;
            this.lblCadastroDespesas.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadastroDespesas.Location = new System.Drawing.Point(150, 144);
            this.lblCadastroDespesas.Name = "lblCadastroDespesas";
            this.lblCadastroDespesas.Size = new System.Drawing.Size(189, 23);
            this.lblCadastroDespesas.TabIndex = 2;
            this.lblCadastroDespesas.TabStop = true;
            this.lblCadastroDespesas.Text = "Cadastro de Despesas";
            this.lblCadastroDespesas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCadastroDespesas_LinkClicked);
            // 
            // lblRelatorioDespesas
            // 
            this.lblRelatorioDespesas.AutoSize = true;
            this.lblRelatorioDespesas.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelatorioDespesas.Location = new System.Drawing.Point(151, 200);
            this.lblRelatorioDespesas.Name = "lblRelatorioDespesas";
            this.lblRelatorioDespesas.Size = new System.Drawing.Size(194, 23);
            this.lblRelatorioDespesas.TabIndex = 3;
            this.lblRelatorioDespesas.TabStop = true;
            this.lblRelatorioDespesas.Text = "Relatório de Despesas";
            this.lblRelatorioDespesas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRelatorioDespesas_LinkClicked);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRelatorioDespesas);
            this.Controls.Add(this.lblCadastroDespesas);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Controle Financeiro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblCadastroDespesas;
        private System.Windows.Forms.LinkLabel lblRelatorioDespesas;
    }
}

