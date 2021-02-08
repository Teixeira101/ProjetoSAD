namespace SadWork
{
    partial class ParkInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParkInfo));
            this.parkInfo_panel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.back_btn = new FontAwesome.Sharp.IconButton();
            this.labelDescTotalPark = new System.Windows.Forms.Label();
            this.labelParkSlogan = new System.Windows.Forms.Label();
            this.labelParkArea = new System.Windows.Forms.Label();
            this.labelNomePark = new System.Windows.Forms.Label();
            this.labelParkWebsite = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.parkInfo_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // parkInfo_panel
            // 
            this.parkInfo_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("parkInfo_panel.BackgroundImage")));
            this.parkInfo_panel.Controls.Add(this.label1);
            this.parkInfo_panel.Controls.Add(this.pictureBox2);
            this.parkInfo_panel.Controls.Add(this.pictureBox1);
            this.parkInfo_panel.Controls.Add(this.back_btn);
            this.parkInfo_panel.Controls.Add(this.labelDescTotalPark);
            this.parkInfo_panel.Controls.Add(this.labelParkSlogan);
            this.parkInfo_panel.Controls.Add(this.labelParkArea);
            this.parkInfo_panel.Controls.Add(this.labelNomePark);
            this.parkInfo_panel.Controls.Add(this.labelParkWebsite);
            this.parkInfo_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parkInfo_panel.Location = new System.Drawing.Point(0, 0);
            this.parkInfo_panel.Name = "parkInfo_panel";
            this.parkInfo_panel.Size = new System.Drawing.Size(804, 510);
            this.parkInfo_panel.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(584, 324);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(188, 167);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // back_btn
            // 
            this.back_btn.BackColor = System.Drawing.Color.Transparent;
            this.back_btn.FlatAppearance.BorderSize = 0;
            this.back_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_btn.ForeColor = System.Drawing.Color.Turquoise;
            this.back_btn.IconChar = FontAwesome.Sharp.IconChar.Backward;
            this.back_btn.IconColor = System.Drawing.Color.Turquoise;
            this.back_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.back_btn.IconSize = 25;
            this.back_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.back_btn.Location = new System.Drawing.Point(680, 21);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(96, 27);
            this.back_btn.TabIndex = 18;
            this.back_btn.Text = "Go Back";
            this.back_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.back_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.back_btn.UseVisualStyleBackColor = false;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // labelDescTotalPark
            // 
            this.labelDescTotalPark.AutoSize = true;
            this.labelDescTotalPark.BackColor = System.Drawing.Color.Transparent;
            this.labelDescTotalPark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescTotalPark.Location = new System.Drawing.Point(29, 250);
            this.labelDescTotalPark.Name = "labelDescTotalPark";
            this.labelDescTotalPark.Size = new System.Drawing.Size(129, 16);
            this.labelDescTotalPark.TabIndex = 17;
            this.labelDescTotalPark.Text = "labelDescTotalPark";
            // 
            // labelParkSlogan
            // 
            this.labelParkSlogan.AutoSize = true;
            this.labelParkSlogan.BackColor = System.Drawing.Color.Transparent;
            this.labelParkSlogan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParkSlogan.ForeColor = System.Drawing.Color.Navy;
            this.labelParkSlogan.Location = new System.Drawing.Point(454, 170);
            this.labelParkSlogan.Name = "labelParkSlogan";
            this.labelParkSlogan.Size = new System.Drawing.Size(169, 25);
            this.labelParkSlogan.TabIndex = 16;
            this.labelParkSlogan.Text = "labelParkSlogan";
            this.labelParkSlogan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelParkArea
            // 
            this.labelParkArea.AutoSize = true;
            this.labelParkArea.BackColor = System.Drawing.Color.Transparent;
            this.labelParkArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParkArea.ForeColor = System.Drawing.Color.White;
            this.labelParkArea.Location = new System.Drawing.Point(249, 51);
            this.labelParkArea.Name = "labelParkArea";
            this.labelParkArea.Size = new System.Drawing.Size(99, 18);
            this.labelParkArea.TabIndex = 15;
            this.labelParkArea.Text = "labelParkArea";
            // 
            // labelNomePark
            // 
            this.labelNomePark.AutoSize = true;
            this.labelNomePark.BackColor = System.Drawing.Color.Transparent;
            this.labelNomePark.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomePark.ForeColor = System.Drawing.Color.Green;
            this.labelNomePark.Location = new System.Drawing.Point(246, 19);
            this.labelNomePark.Name = "labelNomePark";
            this.labelNomePark.Size = new System.Drawing.Size(181, 29);
            this.labelNomePark.TabIndex = 14;
            this.labelNomePark.Text = "labelNomePark";
            // 
            // labelParkWebsite
            // 
            this.labelParkWebsite.AutoSize = true;
            this.labelParkWebsite.BackColor = System.Drawing.Color.Transparent;
            this.labelParkWebsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParkWebsite.ForeColor = System.Drawing.Color.DarkMagenta;
            this.labelParkWebsite.Location = new System.Drawing.Point(175, 475);
            this.labelParkWebsite.Name = "labelParkWebsite";
            this.labelParkWebsite.Size = new System.Drawing.Size(116, 16);
            this.labelParkWebsite.TabIndex = 13;
            this.labelParkWebsite.Text = "labelParkWebsite";
            this.labelParkWebsite.Click += new System.EventHandler(this.labelParkWebsite_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(27, 475);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Para mais informações:";
            // 
            // ParkInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(804, 510);
            this.Controls.Add(this.parkInfo_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ParkInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ParkInfo";
            this.parkInfo_panel.ResumeLayout(false);
            this.parkInfo_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel parkInfo_panel;
        private FontAwesome.Sharp.IconButton back_btn;
        private System.Windows.Forms.Label labelDescTotalPark;
        private System.Windows.Forms.Label labelParkSlogan;
        private System.Windows.Forms.Label labelParkArea;
        private System.Windows.Forms.Label labelNomePark;
        private System.Windows.Forms.Label labelParkWebsite;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}