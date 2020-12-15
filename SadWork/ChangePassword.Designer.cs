
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
            this.label1 = new System.Windows.Forms.Label();
            this.NewPasswordLabel = new System.Windows.Forms.Label();
            this.NewPasswordBox = new System.Windows.Forms.TextBox();
            this.RepeatPasswordBox = new System.Windows.Forms.TextBox();
            this.RepeatPasswordLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.label1.Location = new System.Drawing.Point(32, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "CHANGE PASSWORD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // NewPasswordLabel
            // 
            this.NewPasswordLabel.AutoSize = true;
            this.NewPasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.NewPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.NewPasswordLabel.Location = new System.Drawing.Point(77, 92);
            this.NewPasswordLabel.Name = "NewPasswordLabel";
            this.NewPasswordLabel.Size = new System.Drawing.Size(89, 15);
            this.NewPasswordLabel.TabIndex = 5;
            this.NewPasswordLabel.Text = "New Password";
            this.NewPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewPasswordLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // NewPasswordBox
            // 
            this.NewPasswordBox.Location = new System.Drawing.Point(71, 114);
            this.NewPasswordBox.Name = "NewPasswordBox";
            this.NewPasswordBox.Size = new System.Drawing.Size(163, 20);
            this.NewPasswordBox.TabIndex = 1;
            // 
            // RepeatPasswordBox
            // 
            this.RepeatPasswordBox.Location = new System.Drawing.Point(72, 193);
            this.RepeatPasswordBox.Name = "RepeatPasswordBox";
            this.RepeatPasswordBox.Size = new System.Drawing.Size(163, 20);
            this.RepeatPasswordBox.TabIndex = 2;
            // 
            // RepeatPasswordLabel
            // 
            this.RepeatPasswordLabel.AutoSize = true;
            this.RepeatPasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.RepeatPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepeatPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.RepeatPasswordLabel.Location = new System.Drawing.Point(78, 171);
            this.RepeatPasswordLabel.Name = "RepeatPasswordLabel";
            this.RepeatPasswordLabel.Size = new System.Drawing.Size(104, 15);
            this.RepeatPasswordLabel.TabIndex = 22;
            this.RepeatPasswordLabel.Text = "Repeat Password";
            this.RepeatPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.SubmitButton.FlatAppearance.BorderSize = 0;
            this.SubmitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.ForeColor = System.Drawing.Color.White;
            this.SubmitButton.IconChar = FontAwesome.Sharp.IconChar.Spinner;
            this.SubmitButton.IconColor = System.Drawing.Color.White;
            this.SubmitButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubmitButton.IconSize = 18;
            this.SubmitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SubmitButton.Location = new System.Drawing.Point(113, 309);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(80, 25);
            this.SubmitButton.TabIndex = 3;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SubmitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SubmitButton.UseVisualStyleBackColor = false;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 384);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.RepeatPasswordBox);
            this.Controls.Add(this.RepeatPasswordLabel);
            this.Controls.Add(this.NewPasswordBox);
            this.Controls.Add(this.NewPasswordLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecoverAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NewPasswordLabel;
        private System.Windows.Forms.TextBox NewPasswordBox;
        private System.Windows.Forms.TextBox RepeatPasswordBox;
        private System.Windows.Forms.Label RepeatPasswordLabel;
        private FontAwesome.Sharp.IconButton SubmitButton;
    }
}