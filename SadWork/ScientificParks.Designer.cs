
namespace SadWork
{
    partial class ScientificParks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScientificParks));
            this.scientificPark_panel = new System.Windows.Forms.Panel();
            this.loadParks_btn = new FontAwesome.Sharp.IconButton();
            this.seePark_btn = new FontAwesome.Sharp.IconButton();
            this.comboBoxId = new System.Windows.Forms.ComboBox();
            this.panelPark = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelParkArea = new System.Windows.Forms.Label();
            this.learnMore_btn = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelParkBriefDesc = new System.Windows.Forms.Label();
            this.labelNomePark = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.scientificPark_panel.SuspendLayout();
            this.panelPark.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // scientificPark_panel
            // 
            this.scientificPark_panel.Controls.Add(this.loadParks_btn);
            this.scientificPark_panel.Controls.Add(this.seePark_btn);
            this.scientificPark_panel.Controls.Add(this.comboBoxId);
            this.scientificPark_panel.Controls.Add(this.panelPark);
            this.scientificPark_panel.Controls.Add(this.panel3);
            this.scientificPark_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scientificPark_panel.Location = new System.Drawing.Point(0, 0);
            this.scientificPark_panel.Name = "scientificPark_panel";
            this.scientificPark_panel.Size = new System.Drawing.Size(804, 510);
            this.scientificPark_panel.TabIndex = 0;
            // 
            // loadParks_btn
            // 
            this.loadParks_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadParks_btn.BackColor = System.Drawing.Color.ForestGreen;
            this.loadParks_btn.FlatAppearance.BorderSize = 0;
            this.loadParks_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadParks_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadParks_btn.ForeColor = System.Drawing.Color.White;
            this.loadParks_btn.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.loadParks_btn.IconColor = System.Drawing.Color.White;
            this.loadParks_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.loadParks_btn.IconSize = 25;
            this.loadParks_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadParks_btn.Location = new System.Drawing.Point(347, 37);
            this.loadParks_btn.Name = "loadParks_btn";
            this.loadParks_btn.Size = new System.Drawing.Size(110, 28);
            this.loadParks_btn.TabIndex = 1;
            this.loadParks_btn.Text = "Load Parks";
            this.loadParks_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadParks_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.loadParks_btn.UseVisualStyleBackColor = false;
            this.loadParks_btn.Click += new System.EventHandler(this.loadParks_btn_Click);
            // 
            // seePark_btn
            // 
            this.seePark_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.seePark_btn.FlatAppearance.BorderSize = 0;
            this.seePark_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seePark_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seePark_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(189)))), ((int)(((byte)(202)))));
            this.seePark_btn.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.seePark_btn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(189)))), ((int)(((byte)(202)))));
            this.seePark_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.seePark_btn.IconSize = 25;
            this.seePark_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.seePark_btn.Location = new System.Drawing.Point(325, 93);
            this.seePark_btn.Name = "seePark_btn";
            this.seePark_btn.Size = new System.Drawing.Size(154, 28);
            this.seePark_btn.TabIndex = 3;
            this.seePark_btn.Text = "See Selected Park";
            this.seePark_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.seePark_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.seePark_btn.UseVisualStyleBackColor = true;
            this.seePark_btn.Visible = false;
            this.seePark_btn.Click += new System.EventHandler(this.seePark_btn_Click);
            // 
            // comboBoxId
            // 
            this.comboBoxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxId.FormattingEnabled = true;
            this.comboBoxId.Location = new System.Drawing.Point(294, 64);
            this.comboBoxId.Name = "comboBoxId";
            this.comboBoxId.Size = new System.Drawing.Size(216, 28);
            this.comboBoxId.TabIndex = 2;
            // 
            // panelPark
            // 
            this.panelPark.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPark.Controls.Add(this.panel1);
            this.panelPark.Controls.Add(this.labelParkArea);
            this.panelPark.Controls.Add(this.learnMore_btn);
            this.panelPark.Controls.Add(this.panel2);
            this.panelPark.Controls.Add(this.labelParkBriefDesc);
            this.panelPark.Controls.Add(this.labelNomePark);
            this.panelPark.Location = new System.Drawing.Point(130, 197);
            this.panelPark.Name = "panelPark";
            this.panelPark.Size = new System.Drawing.Size(545, 217);
            this.panelPark.TabIndex = 1;
            this.panelPark.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(0, 187);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 2);
            this.panel1.TabIndex = 6;
            // 
            // labelParkArea
            // 
            this.labelParkArea.AutoSize = true;
            this.labelParkArea.BackColor = System.Drawing.Color.Transparent;
            this.labelParkArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParkArea.ForeColor = System.Drawing.Color.Green;
            this.labelParkArea.Location = new System.Drawing.Point(47, 194);
            this.labelParkArea.Name = "labelParkArea";
            this.labelParkArea.Size = new System.Drawing.Size(80, 15);
            this.labelParkArea.TabIndex = 5;
            this.labelParkArea.Text = "Park\'s Area";
            this.labelParkArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // learnMore_btn
            // 
            this.learnMore_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(189)))), ((int)(((byte)(202)))));
            this.learnMore_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.learnMore_btn.FlatAppearance.BorderSize = 0;
            this.learnMore_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.learnMore_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learnMore_btn.ForeColor = System.Drawing.Color.White;
            this.learnMore_btn.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.learnMore_btn.IconColor = System.Drawing.Color.White;
            this.learnMore_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.learnMore_btn.IconSize = 25;
            this.learnMore_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.learnMore_btn.Location = new System.Drawing.Point(436, 188);
            this.learnMore_btn.Name = "learnMore_btn";
            this.learnMore_btn.Size = new System.Drawing.Size(109, 29);
            this.learnMore_btn.TabIndex = 4;
            this.learnMore_btn.Text = "Learn More";
            this.learnMore_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.learnMore_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.learnMore_btn.UseVisualStyleBackColor = false;
            this.learnMore_btn.Click += new System.EventHandler(this.learnMore_btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Orange;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(381, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 138);
            this.panel2.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelParkBriefDesc
            // 
            this.labelParkBriefDesc.AutoSize = true;
            this.labelParkBriefDesc.BackColor = System.Drawing.Color.Transparent;
            this.labelParkBriefDesc.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParkBriefDesc.ForeColor = System.Drawing.Color.Black;
            this.labelParkBriefDesc.Location = new System.Drawing.Point(27, 46);
            this.labelParkBriefDesc.Name = "labelParkBriefDesc";
            this.labelParkBriefDesc.Size = new System.Drawing.Size(300, 70);
            this.labelParkBriefDesc.TabIndex = 4;
            this.labelParkBriefDesc.Text = resources.GetString("labelParkBriefDesc.Text");
            this.labelParkBriefDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNomePark
            // 
            this.labelNomePark.AutoSize = true;
            this.labelNomePark.BackColor = System.Drawing.Color.Transparent;
            this.labelNomePark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomePark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(189)))), ((int)(((byte)(202)))));
            this.labelNomePark.Location = new System.Drawing.Point(8, 8);
            this.labelNomePark.Name = "labelNomePark";
            this.labelNomePark.Size = new System.Drawing.Size(244, 24);
            this.labelNomePark.TabIndex = 3;
            this.labelNomePark.Text = "Amsterdam Science Park";
            this.labelNomePark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.ForeColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(128, 195);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(549, 221);
            this.panel3.TabIndex = 8;
            this.panel3.Visible = false;
            // 
            // ScientificParks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(47)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(804, 510);
            this.Controls.Add(this.scientificPark_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScientificParks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScientificParks";
            this.scientificPark_panel.ResumeLayout(false);
            this.panelPark.ResumeLayout(false);
            this.panelPark.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel scientificPark_panel;
        private System.Windows.Forms.Panel panelPark;
        private FontAwesome.Sharp.IconButton learnMore_btn;
        private System.Windows.Forms.Label labelParkBriefDesc;
        private System.Windows.Forms.Label labelNomePark;
        private System.Windows.Forms.PictureBox pictureBox1;
        public FontAwesome.Sharp.IconButton loadParks_btn;
        public FontAwesome.Sharp.IconButton seePark_btn;
        private System.Windows.Forms.ComboBox comboBoxId;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelParkArea;
        private System.Windows.Forms.Panel panel3;
    }
}