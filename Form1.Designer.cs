namespace To_Do_List_Project
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblwelcome = new System.Windows.Forms.Label();
            this.lbluser = new System.Windows.Forms.Label();
            this.lblpass = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.usertxt = new System.Windows.Forms.TextBox();
            this.passtxt = new System.Windows.Forms.TextBox();
            this.chkpass = new System.Windows.Forms.CheckBox();
            this.btnuserlogin = new System.Windows.Forms.Button();
            this.btnadminlogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblwelcome
            // 
            this.lblwelcome.AutoSize = true;
            this.lblwelcome.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblwelcome.Font = new System.Drawing.Font("Cascadia Code", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwelcome.ForeColor = System.Drawing.SystemColors.Control;
            this.lblwelcome.Location = new System.Drawing.Point(70, 44);
            this.lblwelcome.Name = "lblwelcome";
            this.lblwelcome.Size = new System.Drawing.Size(595, 39);
            this.lblwelcome.TabIndex = 0;
            this.lblwelcome.Text = "Welcome To To_Do_List Login Screen";
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluser.Location = new System.Drawing.Point(95, 137);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(140, 32);
            this.lbluser.TabIndex = 1;
            this.lbluser.Text = "UserName:";
            // 
            // lblpass
            // 
            this.lblpass.AutoSize = true;
            this.lblpass.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpass.Location = new System.Drawing.Point(95, 201);
            this.lblpass.Name = "lblpass";
            this.lblpass.Size = new System.Drawing.Size(140, 32);
            this.lblpass.TabIndex = 2;
            this.lblpass.Text = "Password:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // usertxt
            // 
            this.usertxt.Font = new System.Drawing.Font("Cascadia Code SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usertxt.Location = new System.Drawing.Point(241, 137);
            this.usertxt.Multiline = true;
            this.usertxt.Name = "usertxt";
            this.usertxt.Size = new System.Drawing.Size(299, 32);
            this.usertxt.TabIndex = 3;
            // 
            // passtxt
            // 
            this.passtxt.Font = new System.Drawing.Font("Cascadia Code SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passtxt.Location = new System.Drawing.Point(241, 201);
            this.passtxt.Multiline = true;
            this.passtxt.Name = "passtxt";
            this.passtxt.PasswordChar = '*';
            this.passtxt.Size = new System.Drawing.Size(299, 32);
            this.passtxt.TabIndex = 4;
            // 
            // chkpass
            // 
            this.chkpass.AutoSize = true;
            this.chkpass.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkpass.Location = new System.Drawing.Point(241, 264);
            this.chkpass.Name = "chkpass";
            this.chkpass.Size = new System.Drawing.Size(146, 25);
            this.chkpass.TabIndex = 5;
            this.chkpass.Text = "Show Password";
            this.chkpass.UseVisualStyleBackColor = true;
            this.chkpass.CheckedChanged += new System.EventHandler(this.chkpass_CheckedChanged);
            // 
            // btnuserlogin
            // 
            this.btnuserlogin.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnuserlogin.Location = new System.Drawing.Point(77, 345);
            this.btnuserlogin.Name = "btnuserlogin";
            this.btnuserlogin.Size = new System.Drawing.Size(225, 56);
            this.btnuserlogin.TabIndex = 6;
            this.btnuserlogin.Text = "Login as User";
            this.btnuserlogin.UseVisualStyleBackColor = true;
            this.btnuserlogin.Click += new System.EventHandler(this.btnuserlogin_Click);
            // 
            // btnadminlogin
            // 
            this.btnadminlogin.Font = new System.Drawing.Font("Cascadia Code", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadminlogin.Location = new System.Drawing.Point(440, 345);
            this.btnadminlogin.Name = "btnadminlogin";
            this.btnadminlogin.Size = new System.Drawing.Size(225, 56);
            this.btnadminlogin.TabIndex = 7;
            this.btnadminlogin.Text = "Login as Admin";
            this.btnadminlogin.UseVisualStyleBackColor = true;
            this.btnadminlogin.Click += new System.EventHandler(this.btnadminlogin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::To_Do_List_Project.Properties.Resources.Gemini_Generated_Image_zegri4zegri4zegr;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnadminlogin);
            this.Controls.Add(this.btnuserlogin);
            this.Controls.Add(this.chkpass);
            this.Controls.Add(this.passtxt);
            this.Controls.Add(this.usertxt);
            this.Controls.Add(this.lblpass);
            this.Controls.Add(this.lbluser);
            this.Controls.Add(this.lblwelcome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblwelcome;
        private System.Windows.Forms.Label lbluser;
        private System.Windows.Forms.Label lblpass;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox usertxt;
        private System.Windows.Forms.TextBox passtxt;
        private System.Windows.Forms.CheckBox chkpass;
        private System.Windows.Forms.Button btnuserlogin;
        private System.Windows.Forms.Button btnadminlogin;
    }
}

