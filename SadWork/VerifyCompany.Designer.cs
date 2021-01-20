
namespace SadWork
{
    partial class VerifyCompany
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
            this.verCompany_btn = new FontAwesome.Sharp.IconButton();
            this.openFile = new FontAwesome.Sharp.IconButton();
            this.panelCompVal = new System.Windows.Forms.Panel();
            this.delete_btn = new FontAwesome.Sharp.IconButton();
            this.labelCompName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCompArea = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCompEmail = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCompLocation = new System.Windows.Forms.Label();
            this.loadUnVerComp_btn = new FontAwesome.Sharp.IconButton();
            this.seeUnVerComp_btn = new FontAwesome.Sharp.IconButton();
            this.comboBoxId = new System.Windows.Forms.ComboBox();
            this.panelCompVal.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.label1.Location = new System.Drawing.Point(50, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "VERIFY COMPANY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // verCompany_btn
            // 
            this.verCompany_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.verCompany_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.verCompany_btn.FlatAppearance.BorderSize = 0;
            this.verCompany_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verCompany_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verCompany_btn.ForeColor = System.Drawing.Color.White;
            this.verCompany_btn.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.verCompany_btn.IconColor = System.Drawing.Color.White;
            this.verCompany_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.verCompany_btn.IconSize = 20;
            this.verCompany_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.verCompany_btn.Location = new System.Drawing.Point(160, 270);
            this.verCompany_btn.Name = "verCompany_btn";
            this.verCompany_btn.Size = new System.Drawing.Size(76, 30);
            this.verCompany_btn.TabIndex = 18;
            this.verCompany_btn.Text = "Verify";
            this.verCompany_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.verCompany_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.verCompany_btn.UseVisualStyleBackColor = false;
            this.verCompany_btn.Visible = false;
            this.verCompany_btn.Click += new System.EventHandler(this.verCompany_btn_Click);
            // 
            // openFile
            // 
            this.openFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.openFile.FlatAppearance.BorderSize = 0;
            this.openFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFile.ForeColor = System.Drawing.Color.White;
            this.openFile.IconChar = FontAwesome.Sharp.IconChar.FileArchive;
            this.openFile.IconColor = System.Drawing.Color.White;
            this.openFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.openFile.IconSize = 20;
            this.openFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openFile.Location = new System.Drawing.Point(203, 235);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(73, 30);
            this.openFile.TabIndex = 26;
            this.openFile.Text = "Proof";
            this.openFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.openFile.UseVisualStyleBackColor = false;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // panelCompVal
            // 
            this.panelCompVal.Controls.Add(this.delete_btn);
            this.panelCompVal.Controls.Add(this.labelCompName);
            this.panelCompVal.Controls.Add(this.verCompany_btn);
            this.panelCompVal.Controls.Add(this.openFile);
            this.panelCompVal.Controls.Add(this.label3);
            this.panelCompVal.Controls.Add(this.labelCompArea);
            this.panelCompVal.Controls.Add(this.label4);
            this.panelCompVal.Controls.Add(this.labelCompEmail);
            this.panelCompVal.Controls.Add(this.label2);
            this.panelCompVal.Controls.Add(this.label5);
            this.panelCompVal.Controls.Add(this.labelCompLocation);
            this.panelCompVal.Location = new System.Drawing.Point(163, 174);
            this.panelCompVal.Name = "panelCompVal";
            this.panelCompVal.Size = new System.Drawing.Size(479, 324);
            this.panelCompVal.TabIndex = 33;
            this.panelCompVal.Visible = false;
            // 
            // delete_btn
            // 
            this.delete_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delete_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.delete_btn.FlatAppearance.BorderSize = 0;
            this.delete_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_btn.ForeColor = System.Drawing.Color.White;
            this.delete_btn.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.delete_btn.IconColor = System.Drawing.Color.White;
            this.delete_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.delete_btn.IconSize = 20;
            this.delete_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delete_btn.Location = new System.Drawing.Point(242, 270);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(82, 30);
            this.delete_btn.TabIndex = 42;
            this.delete_btn.Text = "Delete";
            this.delete_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delete_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.delete_btn.UseVisualStyleBackColor = false;
            this.delete_btn.Visible = false;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // labelCompName
            // 
            this.labelCompName.AutoSize = true;
            this.labelCompName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompName.Location = new System.Drawing.Point(214, 27);
            this.labelCompName.Name = "labelCompName";
            this.labelCompName.Size = new System.Drawing.Size(50, 16);
            this.labelCompName.TabIndex = 34;
            this.labelCompName.Text = "Park#1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.label3.Location = new System.Drawing.Point(187, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 18);
            this.label3.TabIndex = 39;
            this.label3.Text = "Park\'s Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompArea
            // 
            this.labelCompArea.AutoSize = true;
            this.labelCompArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompArea.Location = new System.Drawing.Point(214, 198);
            this.labelCompArea.Name = "labelCompArea";
            this.labelCompArea.Size = new System.Drawing.Size(51, 16);
            this.labelCompArea.TabIndex = 35;
            this.labelCompArea.Text = "Area#1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.label4.Location = new System.Drawing.Point(179, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 18);
            this.label4.TabIndex = 40;
            this.label4.Text = "Contact E-mail";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompEmail
            // 
            this.labelCompEmail.AutoSize = true;
            this.labelCompEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompEmail.Location = new System.Drawing.Point(173, 78);
            this.labelCompEmail.Name = "labelCompEmail";
            this.labelCompEmail.Size = new System.Drawing.Size(133, 16);
            this.labelCompEmail.TabIndex = 36;
            this.labelCompEmail.Text = "Email#1@Email.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.label2.Location = new System.Drawing.Point(192, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 38;
            this.label2.Text = "Park\'s Area";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.label5.Location = new System.Drawing.Point(176, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 18);
            this.label5.TabIndex = 41;
            this.label5.Text = "Park\'s Location";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompLocation
            // 
            this.labelCompLocation.AutoSize = true;
            this.labelCompLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompLocation.Location = new System.Drawing.Point(177, 139);
            this.labelCompLocation.Name = "labelCompLocation";
            this.labelCompLocation.Size = new System.Drawing.Size(125, 16);
            this.labelCompLocation.TabIndex = 37;
            this.labelCompLocation.Text = "Location#1 Street#1";
            // 
            // loadUnVerComp_btn
            // 
            this.loadUnVerComp_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadUnVerComp_btn.BackColor = System.Drawing.Color.Red;
            this.loadUnVerComp_btn.FlatAppearance.BorderSize = 0;
            this.loadUnVerComp_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadUnVerComp_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadUnVerComp_btn.ForeColor = System.Drawing.Color.White;
            this.loadUnVerComp_btn.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.loadUnVerComp_btn.IconColor = System.Drawing.Color.White;
            this.loadUnVerComp_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.loadUnVerComp_btn.IconSize = 25;
            this.loadUnVerComp_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadUnVerComp_btn.Location = new System.Drawing.Point(298, 79);
            this.loadUnVerComp_btn.Name = "loadUnVerComp_btn";
            this.loadUnVerComp_btn.Size = new System.Drawing.Size(208, 28);
            this.loadUnVerComp_btn.TabIndex = 36;
            this.loadUnVerComp_btn.Text = "Load Unverified Companies";
            this.loadUnVerComp_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadUnVerComp_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.loadUnVerComp_btn.UseVisualStyleBackColor = false;
            this.loadUnVerComp_btn.Click += new System.EventHandler(this.loadUnVerComp_btn_Click);
            // 
            // seeUnVerComp_btn
            // 
            this.seeUnVerComp_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.seeUnVerComp_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seeUnVerComp_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seeUnVerComp_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(189)))), ((int)(((byte)(202)))));
            this.seeUnVerComp_btn.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.seeUnVerComp_btn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(189)))), ((int)(((byte)(202)))));
            this.seeUnVerComp_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.seeUnVerComp_btn.IconSize = 25;
            this.seeUnVerComp_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.seeUnVerComp_btn.Location = new System.Drawing.Point(325, 131);
            this.seeUnVerComp_btn.Name = "seeUnVerComp_btn";
            this.seeUnVerComp_btn.Size = new System.Drawing.Size(156, 30);
            this.seeUnVerComp_btn.TabIndex = 35;
            this.seeUnVerComp_btn.Text = "See Selected Park";
            this.seeUnVerComp_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.seeUnVerComp_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.seeUnVerComp_btn.UseVisualStyleBackColor = true;
            this.seeUnVerComp_btn.Visible = false;
            this.seeUnVerComp_btn.Click += new System.EventHandler(this.seeUnVerComp_btn_Click);
            // 
            // comboBoxId
            // 
            this.comboBoxId.BackColor = System.Drawing.Color.White;
            this.comboBoxId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxId.FormattingEnabled = true;
            this.comboBoxId.Location = new System.Drawing.Point(263, 107);
            this.comboBoxId.Name = "comboBoxId";
            this.comboBoxId.Size = new System.Drawing.Size(278, 28);
            this.comboBoxId.TabIndex = 34;
            // 
            // VerifyCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 510);
            this.Controls.Add(this.loadUnVerComp_btn);
            this.Controls.Add(this.comboBoxId);
            this.Controls.Add(this.panelCompVal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seeUnVerComp_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VerifyCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VerifyCompany";
            this.panelCompVal.ResumeLayout(false);
            this.panelCompVal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton verCompany_btn;
        private FontAwesome.Sharp.IconButton openFile;
        private System.Windows.Forms.Panel panelCompVal;
        private System.Windows.Forms.Label labelCompName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCompArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCompEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCompLocation;
        public FontAwesome.Sharp.IconButton loadUnVerComp_btn;
        public FontAwesome.Sharp.IconButton seeUnVerComp_btn;
        private System.Windows.Forms.ComboBox comboBoxId;
        private FontAwesome.Sharp.IconButton delete_btn;
    }
}