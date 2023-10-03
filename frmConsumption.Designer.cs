namespace Dentist_Clinic.Views
{
    partial class frmConsumption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsumption));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCountConsumption = new System.Windows.Forms.Label();
            this.btnShowSpending = new Guna.UI.WinForms.GunaAdvenceButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.lblPayed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dGVConsumption = new System.Windows.Forms.DataGridView();
            this.gunaPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVConsumption)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.Controls.Add(this.comboBox1);
            this.gunaPanel1.Controls.Add(this.label3);
            this.gunaPanel1.Controls.Add(this.label2);
            this.gunaPanel1.Controls.Add(this.lblCountConsumption);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(1205, 58);
            this.gunaPanel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Desc",
            "Asc"});
            this.comboBox1.Location = new System.Drawing.Point(261, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(197, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sort by";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(67, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Consumption";
            // 
            // lblCountConsumption
            // 
            this.lblCountConsumption.AutoSize = true;
            this.lblCountConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountConsumption.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblCountConsumption.Location = new System.Drawing.Point(12, 9);
            this.lblCountConsumption.Name = "lblCountConsumption";
            this.lblCountConsumption.Size = new System.Drawing.Size(49, 36);
            this.lblCountConsumption.TabIndex = 0;
            this.lblCountConsumption.Text = "75";
            // 
            // btnShowSpending
            // 
            this.btnShowSpending.AnimationHoverSpeed = 0.07F;
            this.btnShowSpending.AnimationSpeed = 0.03F;
            this.btnShowSpending.BackColor = System.Drawing.Color.Transparent;
            this.btnShowSpending.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnShowSpending.BorderColor = System.Drawing.Color.Black;
            this.btnShowSpending.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnShowSpending.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnShowSpending.CheckedForeColor = System.Drawing.Color.Black;
            this.btnShowSpending.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnShowSpending.CheckedImage")));
            this.btnShowSpending.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnShowSpending.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnShowSpending.FocusedColor = System.Drawing.Color.Empty;
            this.btnShowSpending.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.btnShowSpending.ForeColor = System.Drawing.Color.Black;
            this.btnShowSpending.Image = null;
            this.btnShowSpending.ImageSize = new System.Drawing.Size(20, 20);
            this.btnShowSpending.LineBottom = 1;
            this.btnShowSpending.LineColor = System.Drawing.Color.Black;
            this.btnShowSpending.LineLeft = 1;
            this.btnShowSpending.LineRight = 1;
            this.btnShowSpending.LineTop = 1;
            this.btnShowSpending.Location = new System.Drawing.Point(72, 9);
            this.btnShowSpending.Name = "btnShowSpending";
            this.btnShowSpending.OnHoverBaseColor = System.Drawing.Color.Goldenrod;
            this.btnShowSpending.OnHoverBorderColor = System.Drawing.Color.Goldenrod;
            this.btnShowSpending.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnShowSpending.OnHoverImage = null;
            this.btnShowSpending.OnHoverLineColor = System.Drawing.Color.Black;
            this.btnShowSpending.OnPressedColor = System.Drawing.Color.Black;
            this.btnShowSpending.Radius = 5;
            this.btnShowSpending.Size = new System.Drawing.Size(402, 47);
            this.btnShowSpending.TabIndex = 45;
            this.btnShowSpending.Text = "Spending";
            this.btnShowSpending.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnShowSpending.Click += new System.EventHandler(this.btnShowSpending_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShowSpending);
            this.panel1.Controls.Add(this.lblRemaining);
            this.panel1.Controls.Add(this.lblPayed);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 671);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1205, 64);
            this.panel1.TabIndex = 1;
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemaining.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblRemaining.Location = new System.Drawing.Point(1057, 14);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(49, 36);
            this.lblRemaining.TabIndex = 6;
            this.lblRemaining.Text = "75";
            // 
            // lblPayed
            // 
            this.lblPayed.AutoSize = true;
            this.lblPayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayed.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblPayed.Location = new System.Drawing.Point(681, 14);
            this.lblPayed.Name = "lblPayed";
            this.lblPayed.Size = new System.Drawing.Size(49, 36);
            this.lblPayed.TabIndex = 5;
            this.lblPayed.Text = "75";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(560, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Payed  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(875, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "Remaining :";
            // 
            // dGVConsumption
            // 
            this.dGVConsumption.AllowUserToAddRows = false;
            this.dGVConsumption.AllowUserToDeleteRows = false;
            this.dGVConsumption.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVConsumption.BackgroundColor = System.Drawing.Color.White;
            this.dGVConsumption.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVConsumption.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVConsumption.ColumnHeadersHeight = 25;
            this.dGVConsumption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVConsumption.GridColor = System.Drawing.Color.White;
            this.dGVConsumption.Location = new System.Drawing.Point(0, 58);
            this.dGVConsumption.Name = "dGVConsumption";
            this.dGVConsumption.ReadOnly = true;
            this.dGVConsumption.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVConsumption.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVConsumption.RowHeadersWidth = 4;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dGVConsumption.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVConsumption.RowTemplate.Height = 26;
            this.dGVConsumption.Size = new System.Drawing.Size(1205, 613);
            this.dGVConsumption.TabIndex = 2;
            // 
            // frmConsumption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1205, 735);
            this.Controls.Add(this.dGVConsumption);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gunaPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConsumption";
            this.Text = "frmPatients";
            this.Load += new System.EventHandler(this.frmConsumption_Load);
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVConsumption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.Label lblCountConsumption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label lblPayed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaAdvenceButton btnShowSpending;
        public System.Windows.Forms.DataGridView dGVConsumption;
    }
}