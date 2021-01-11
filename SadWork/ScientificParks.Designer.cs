
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.learnMore_btn = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.scientificPark_panel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // scientificPark_panel
            // 
            this.scientificPark_panel.Controls.Add(this.panel2);
            this.scientificPark_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scientificPark_panel.Location = new System.Drawing.Point(0, 0);
            this.scientificPark_panel.Name = "scientificPark_panel";
            this.scientificPark_panel.Size = new System.Drawing.Size(804, 510);
            this.scientificPark_panel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.learnMore_btn);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(59, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(587, 106);
            this.panel2.TabIndex = 1;
            // 
            // learnMore_btn
            // 
            this.learnMore_btn.FlatAppearance.BorderSize = 0;
            this.learnMore_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.learnMore_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learnMore_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.learnMore_btn.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.learnMore_btn.IconColor = System.Drawing.Color.Gainsboro;
            this.learnMore_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.learnMore_btn.IconSize = 25;
            this.learnMore_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.learnMore_btn.Location = new System.Drawing.Point(473, 68);
            this.learnMore_btn.Name = "learnMore_btn";
            this.learnMore_btn.Size = new System.Drawing.Size(114, 38);
            this.learnMore_btn.TabIndex = 9;
            this.learnMore_btn.Text = "Learn More";
            this.learnMore_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.learnMore_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.learnMore_btn.UseVisualStyleBackColor = true;
            this.learnMore_btn.Click += new System.EventHandler(this.learnMore_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(125, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(458, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "This science park is located in the Oost city district of Amsterdam and has focus" +
    " on\r\nphysics, mathematics, information technology and the life sciences.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(189)))), ((int)(((byte)(202)))));
            this.label1.Location = new System.Drawing.Point(122, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Amsterdam Science Park";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel scientificPark_panel;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton learnMore_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}