
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxId = new System.Windows.Forms.ComboBox();
            this.panelPark = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelParkArea = new System.Windows.Forms.Label();
            this.learnMore_btn = new FontAwesome.Sharp.IconButton();
            this.labelParkBriefDesc = new System.Windows.Forms.Label();
            this.labelNomePark = new System.Windows.Forms.Label();
            this.scientificPark_panel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelPark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // scientificPark_panel
            // 
            this.scientificPark_panel.Controls.Add(this.panel4);
            this.scientificPark_panel.Controls.Add(this.panelPark);
            this.scientificPark_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scientificPark_panel.Location = new System.Drawing.Point(0, 0);
            this.scientificPark_panel.Name = "scientificPark_panel";
            this.scientificPark_panel.Size = new System.Drawing.Size(804, 510);
            this.scientificPark_panel.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(189)))), ((int)(((byte)(202)))));
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.comboBoxId);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(804, 118);
            this.panel4.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(163, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Below you can see all the different scientific parks that are inserted in our sys" +
    "tem\r\nYou can choose any park and a briefly description will be shown";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxId
            // 
            this.comboBoxId.BackColor = System.Drawing.Color.White;
            this.comboBoxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxId.FormattingEnabled = true;
            this.comboBoxId.Location = new System.Drawing.Point(294, 69);
            this.comboBoxId.Name = "comboBoxId";
            this.comboBoxId.Size = new System.Drawing.Size(216, 24);
            this.comboBoxId.TabIndex = 2;
            this.comboBoxId.SelectionChangeCommitted += new System.EventHandler(this.comboBoxId_SelectionChangeCommitted);
            // 
            // panelPark
            // 
            this.panelPark.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPark.Controls.Add(this.pictureBox1);
            this.panelPark.Controls.Add(this.panel1);
            this.panelPark.Controls.Add(this.labelParkArea);
            this.panelPark.Controls.Add(this.learnMore_btn);
            this.panelPark.Controls.Add(this.labelParkBriefDesc);
            this.panelPark.Controls.Add(this.labelNomePark);
            this.panelPark.Location = new System.Drawing.Point(47, 186);
            this.panelPark.Name = "panelPark";
            this.panelPark.Size = new System.Drawing.Size(711, 274);
            this.panelPark.TabIndex = 1;
            this.panelPark.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(50, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(0, 243);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 2);
            this.panel1.TabIndex = 6;
            // 
            // labelParkArea
            // 
            this.labelParkArea.AutoSize = true;
            this.labelParkArea.BackColor = System.Drawing.Color.Transparent;
            this.labelParkArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParkArea.ForeColor = System.Drawing.Color.Gray;
            this.labelParkArea.Location = new System.Drawing.Point(14, 251);
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
            this.learnMore_btn.Location = new System.Drawing.Point(602, 245);
            this.learnMore_btn.Name = "learnMore_btn";
            this.learnMore_btn.Size = new System.Drawing.Size(109, 29);
            this.learnMore_btn.TabIndex = 4;
            this.learnMore_btn.Text = "Learn More";
            this.learnMore_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.learnMore_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.learnMore_btn.UseVisualStyleBackColor = false;
            this.learnMore_btn.Click += new System.EventHandler(this.learnMore_btn_Click);
            // 
            // labelParkBriefDesc
            // 
            this.labelParkBriefDesc.AutoSize = true;
            this.labelParkBriefDesc.BackColor = System.Drawing.Color.Transparent;
            this.labelParkBriefDesc.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParkBriefDesc.ForeColor = System.Drawing.Color.Black;
            this.labelParkBriefDesc.Location = new System.Drawing.Point(291, 42);
            this.labelParkBriefDesc.Name = "labelParkBriefDesc";
            this.labelParkBriefDesc.Size = new System.Drawing.Size(368, 70);
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
            this.labelNomePark.Location = new System.Drawing.Point(233, 8);
            this.labelNomePark.Name = "labelNomePark";
            this.labelNomePark.Size = new System.Drawing.Size(244, 24);
            this.labelNomePark.TabIndex = 3;
            this.labelNomePark.Text = "Amsterdam Science Park";
            this.labelNomePark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelPark.ResumeLayout(false);
            this.panelPark.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel scientificPark_panel;
        private System.Windows.Forms.Panel panelPark;
        private FontAwesome.Sharp.IconButton learnMore_btn;
        private System.Windows.Forms.Label labelParkBriefDesc;
        private System.Windows.Forms.Label labelNomePark;
        private System.Windows.Forms.ComboBox comboBoxId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelParkArea;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}