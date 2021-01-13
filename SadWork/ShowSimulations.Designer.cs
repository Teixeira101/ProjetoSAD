
namespace SadWork
{
    partial class ShowSimulations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowSimulations));
            this.panelShowSimul = new System.Windows.Forms.Panel();
            this.loadData_btn = new FontAwesome.Sharp.IconButton();
            this.seeSimul_btn = new FontAwesome.Sharp.IconButton();
            this.comboBoxId = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelData = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelPark3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelPark2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPark1 = new System.Windows.Forms.Label();
            this.labelArea = new System.Windows.Forms.Label();
            this.simul_btn = new System.Windows.Forms.Button();
            this.panelShowSimul.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelShowSimul
            // 
            this.panelShowSimul.BackColor = System.Drawing.SystemColors.Control;
            this.panelShowSimul.Controls.Add(this.loadData_btn);
            this.panelShowSimul.Controls.Add(this.seeSimul_btn);
            this.panelShowSimul.Controls.Add(this.comboBoxId);
            this.panelShowSimul.Controls.Add(this.panel2);
            this.panelShowSimul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowSimul.Location = new System.Drawing.Point(0, 0);
            this.panelShowSimul.Name = "panelShowSimul";
            this.panelShowSimul.Size = new System.Drawing.Size(804, 510);
            this.panelShowSimul.TabIndex = 0;
            // 
            // loadData_btn
            // 
            this.loadData_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadData_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(173)))), ((int)(((byte)(45)))));
            this.loadData_btn.FlatAppearance.BorderSize = 0;
            this.loadData_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadData_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadData_btn.ForeColor = System.Drawing.Color.White;
            this.loadData_btn.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.loadData_btn.IconColor = System.Drawing.Color.White;
            this.loadData_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.loadData_btn.IconSize = 25;
            this.loadData_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadData_btn.Location = new System.Drawing.Point(533, 121);
            this.loadData_btn.Name = "loadData_btn";
            this.loadData_btn.Size = new System.Drawing.Size(104, 28);
            this.loadData_btn.TabIndex = 1;
            this.loadData_btn.Text = "Load Data";
            this.loadData_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadData_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.loadData_btn.UseVisualStyleBackColor = false;
            this.loadData_btn.Click += new System.EventHandler(this.loadData_btn_Click);
            // 
            // seeSimul_btn
            // 
            this.seeSimul_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.seeSimul_btn.FlatAppearance.BorderSize = 0;
            this.seeSimul_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seeSimul_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seeSimul_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(189)))), ((int)(((byte)(202)))));
            this.seeSimul_btn.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.seeSimul_btn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(189)))), ((int)(((byte)(202)))));
            this.seeSimul_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.seeSimul_btn.IconSize = 25;
            this.seeSimul_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.seeSimul_btn.Location = new System.Drawing.Point(384, 150);
            this.seeSimul_btn.Name = "seeSimul_btn";
            this.seeSimul_btn.Size = new System.Drawing.Size(131, 28);
            this.seeSimul_btn.TabIndex = 3;
            this.seeSimul_btn.Text = "See Simulation";
            this.seeSimul_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.seeSimul_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.seeSimul_btn.UseVisualStyleBackColor = true;
            this.seeSimul_btn.Visible = false;
            this.seeSimul_btn.Click += new System.EventHandler(this.seeSimul_btn_Click);
            // 
            // comboBoxId
            // 
            this.comboBoxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxId.FormattingEnabled = true;
            this.comboBoxId.Location = new System.Drawing.Point(371, 121);
            this.comboBoxId.Name = "comboBoxId";
            this.comboBoxId.Size = new System.Drawing.Size(156, 28);
            this.comboBoxId.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.panel2.Controls.Add(this.labelData);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.labelPark3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.labelPark2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.labelPark1);
            this.panel2.Controls.Add(this.labelArea);
            this.panel2.Controls.Add(this.simul_btn);
            this.panel2.Location = new System.Drawing.Point(36, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(227, 440);
            this.panel2.TabIndex = 0;
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelData.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelData.Location = new System.Drawing.Point(67, 337);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(147, 20);
            this.labelData.TabIndex = 12;
            this.labelData.Text = "Data da simulação";
            this.labelData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelData.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(10, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Date -";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPark3
            // 
            this.labelPark3.AutoSize = true;
            this.labelPark3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPark3.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPark3.Location = new System.Drawing.Point(67, 295);
            this.labelPark3.Name = "labelPark3";
            this.labelPark3.Size = new System.Drawing.Size(146, 20);
            this.labelPark3.TabIndex = 10;
            this.labelPark3.Text = "Nome do Parque 3";
            this.labelPark3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPark3.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(10, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Park 3 -";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPark2
            // 
            this.labelPark2.AutoSize = true;
            this.labelPark2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPark2.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPark2.Location = new System.Drawing.Point(67, 251);
            this.labelPark2.Name = "labelPark2";
            this.labelPark2.Size = new System.Drawing.Size(146, 20);
            this.labelPark2.TabIndex = 8;
            this.labelPark2.Text = "Nome do Parque 2";
            this.labelPark2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPark2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(10, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Park 2 -";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(10, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Park 1 -";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(10, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Area -";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPark1
            // 
            this.labelPark1.AutoSize = true;
            this.labelPark1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPark1.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPark1.Location = new System.Drawing.Point(67, 207);
            this.labelPark1.Name = "labelPark1";
            this.labelPark1.Size = new System.Drawing.Size(146, 20);
            this.labelPark1.TabIndex = 3;
            this.labelPark1.Text = "Nome do Parque 1";
            this.labelPark1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPark1.Visible = false;
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArea.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelArea.Location = new System.Drawing.Point(67, 166);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(147, 20);
            this.labelArea.TabIndex = 1;
            this.labelArea.Text = "Telecomunicações";
            this.labelArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelArea.Visible = false;
            // 
            // simul_btn
            // 
            this.simul_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.simul_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simul_btn.BackgroundImage")));
            this.simul_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.simul_btn.FlatAppearance.BorderSize = 0;
            this.simul_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simul_btn.Location = new System.Drawing.Point(23, 21);
            this.simul_btn.Name = "simul_btn";
            this.simul_btn.Size = new System.Drawing.Size(181, 121);
            this.simul_btn.TabIndex = 0;
            this.simul_btn.UseVisualStyleBackColor = false;
            this.simul_btn.Click += new System.EventHandler(this.simul_btn_Click);
            // 
            // ShowSimulations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 510);
            this.Controls.Add(this.panelShowSimul);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowSimulations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowSimulations";
            this.panelShowSimul.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelShowSimul;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button simul_btn;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.Label labelPark1;
        private System.Windows.Forms.ComboBox comboBoxId;
        public FontAwesome.Sharp.IconButton seeSimul_btn;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelPark3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPark2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public FontAwesome.Sharp.IconButton loadData_btn;
    }
}