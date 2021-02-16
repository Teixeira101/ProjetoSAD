
namespace SadWork
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.label1 = new System.Windows.Forms.Label();
            this.NewPasswordLabel = new System.Windows.Forms.Label();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.textBoxRptPwd = new System.Windows.Forms.TextBox();
            this.RepeatPasswordLabel = new System.Windows.Forms.Label();
            this.submit_btn = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(187)))), ((int)(((byte)(200)))));
            this.label1.Location = new System.Drawing.Point(54, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "CHANGE PASSWORD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewPasswordLabel
            // 
            this.NewPasswordLabel.AutoSize = true;
            this.NewPasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.NewPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(187)))), ((int)(((byte)(200)))));
            this.NewPasswordLabel.Location = new System.Drawing.Point(35, 96);
            this.NewPasswordLabel.Name = "NewPasswordLabel";
            this.NewPasswordLabel.Size = new System.Drawing.Size(113, 20);
            this.NewPasswordLabel.TabIndex = 5;
            this.NewPasswordLabel.Text = "New Password";
            this.NewPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Location = new System.Drawing.Point(39, 119);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(228, 20);
            this.textBoxPwd.TabIndex = 1;
            // 
            // textBoxRptPwd
            // 
            this.textBoxRptPwd.Location = new System.Drawing.Point(39, 182);
            this.textBoxRptPwd.Name = "textBoxRptPwd";
            this.textBoxRptPwd.Size = new System.Drawing.Size(228, 20);
            this.textBoxRptPwd.TabIndex = 2;
            // 
            // RepeatPasswordLabel
            // 
            this.RepeatPasswordLabel.AutoSize = true;
            this.RepeatPasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.RepeatPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepeatPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(187)))), ((int)(((byte)(200)))));
            this.RepeatPasswordLabel.Location = new System.Drawing.Point(35, 159);
            this.RepeatPasswordLabel.Name = "RepeatPasswordLabel";
            this.RepeatPasswordLabel.Size = new System.Drawing.Size(135, 20);
            this.RepeatPasswordLabel.TabIndex = 22;
            this.RepeatPasswordLabel.Text = "Repeat Password";
            this.RepeatPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // submit_btn
            // 
            this.submit_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.submit_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(187)))), ((int)(((byte)(200)))));
            this.submit_btn.FlatAppearance.BorderSize = 0;
            this.submit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submit_btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit_btn.ForeColor = System.Drawing.Color.White;
            this.submit_btn.IconChar = FontAwesome.Sharp.IconChar.Spinner;
            this.submit_btn.IconColor = System.Drawing.Color.White;
            this.submit_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submit_btn.IconSize = 18;
            this.submit_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.submit_btn.Location = new System.Drawing.Point(39, 238);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(228, 41);
            this.submit_btn.TabIndex = 3;
            this.submit_btn.Text = "Submit";
            this.submit_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.submit_btn.UseVisualStyleBackColor = false;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 26);
            this.label2.TabIndex = 23;
            this.label2.Text = "Above it should be inserted the new password for your\r\naccount and also repeat it" +
    " for security reasons.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 22;
            this.btnExit.Location = new System.Drawing.Point(282, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(22, 22);
            this.btnExit.TabIndex = 35;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(306, 384);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.textBoxRptPwd);
            this.Controls.Add(this.RepeatPasswordLabel);
            this.Controls.Add(this.textBoxPwd);
            this.Controls.Add(this.NewPasswordLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recover Account";
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NewPasswordLabel;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.TextBox textBoxRptPwd;
        private System.Windows.Forms.Label RepeatPasswordLabel;
        private FontAwesome.Sharp.IconButton submit_btn;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconPictureBox btnExit;
    }
}