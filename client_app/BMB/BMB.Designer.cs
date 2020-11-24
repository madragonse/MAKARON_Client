
namespace BMB
{
    partial class BMB
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelGry = new System.Windows.Forms.Panel();
            this.connectButton = new System.Windows.Forms.Button();
            this.textBoxIPI1 = new System.Windows.Forms.TextBox();
            this.labelGetIP = new System.Windows.Forms.Label();
            this.textBoxIPI2 = new System.Windows.Forms.TextBox();
            this.textBoxIPI4 = new System.Windows.Forms.TextBox();
            this.textBoxIPI3 = new System.Windows.Forms.TextBox();
            this.labelPortSeparator = new System.Windows.Forms.Label();
            this.textBoxPortI = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelSide = new System.Windows.Forms.Panel();
            this.panelConnected = new System.Windows.Forms.Panel();
            this.labelConnected = new System.Windows.Forms.Label();
            this.panelConnect = new System.Windows.Forms.Panel();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panelSide.SuspendLayout();
            this.panelConnected.SuspendLayout();
            this.panelConnect.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGry
            // 
            this.panelGry.Location = new System.Drawing.Point(0, 0);
            this.panelGry.Margin = new System.Windows.Forms.Padding(0);
            this.panelGry.Name = "panelGry";
            this.panelGry.Size = new System.Drawing.Size(977, 977);
            this.panelGry.TabIndex = 0;
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.connectButton.Location = new System.Drawing.Point(22, 103);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(349, 62);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Dołącz do serwera";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // textBoxIPI1
            // 
            this.textBoxIPI1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxIPI1.Location = new System.Drawing.Point(22, 45);
            this.textBoxIPI1.Name = "textBoxIPI1";
            this.textBoxIPI1.Size = new System.Drawing.Size(60, 37);
            this.textBoxIPI1.TabIndex = 2;
            // 
            // labelGetIP
            // 
            this.labelGetIP.AutoSize = true;
            this.labelGetIP.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGetIP.Location = new System.Drawing.Point(16, 3);
            this.labelGetIP.Name = "labelGetIP";
            this.labelGetIP.Size = new System.Drawing.Size(249, 31);
            this.labelGetIP.TabIndex = 3;
            this.labelGetIP.Text = "Podaj adres serwera:";
            // 
            // textBoxIPI2
            // 
            this.textBoxIPI2.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxIPI2.Location = new System.Drawing.Point(88, 45);
            this.textBoxIPI2.Name = "textBoxIPI2";
            this.textBoxIPI2.Size = new System.Drawing.Size(60, 37);
            this.textBoxIPI2.TabIndex = 4;
            // 
            // textBoxIPI4
            // 
            this.textBoxIPI4.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxIPI4.Location = new System.Drawing.Point(220, 45);
            this.textBoxIPI4.Name = "textBoxIPI4";
            this.textBoxIPI4.Size = new System.Drawing.Size(60, 37);
            this.textBoxIPI4.TabIndex = 6;
            // 
            // textBoxIPI3
            // 
            this.textBoxIPI3.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxIPI3.Location = new System.Drawing.Point(154, 45);
            this.textBoxIPI3.Name = "textBoxIPI3";
            this.textBoxIPI3.Size = new System.Drawing.Size(60, 37);
            this.textBoxIPI3.TabIndex = 5;
            // 
            // labelPortSeparator
            // 
            this.labelPortSeparator.AutoSize = true;
            this.labelPortSeparator.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPortSeparator.Location = new System.Drawing.Point(286, 45);
            this.labelPortSeparator.Name = "labelPortSeparator";
            this.labelPortSeparator.Size = new System.Drawing.Size(20, 31);
            this.labelPortSeparator.TabIndex = 7;
            this.labelPortSeparator.Text = ":";
            // 
            // textBoxPortI
            // 
            this.textBoxPortI.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPortI.Location = new System.Drawing.Point(306, 45);
            this.textBoxPortI.Name = "textBoxPortI";
            this.textBoxPortI.Size = new System.Drawing.Size(65, 37);
            this.textBoxPortI.TabIndex = 8;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxLogin.Location = new System.Drawing.Point(24, 43);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(350, 37);
            this.textBoxLogin.TabIndex = 9;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPassword.Location = new System.Drawing.Point(24, 137);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(350, 37);
            this.textBoxPassword.TabIndex = 10;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLogin.Location = new System.Drawing.Point(18, 9);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(83, 31);
            this.labelLogin.TabIndex = 11;
            this.labelLogin.Text = "Login:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPassword.Location = new System.Drawing.Point(21, 103);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(84, 31);
            this.labelPassword.TabIndex = 12;
            this.labelPassword.Text = "Hasło:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panelSide
            // 
            this.panelSide.Controls.Add(this.panelConnect);
            this.panelSide.Controls.Add(this.panelLogin);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSide.Location = new System.Drawing.Point(980, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(456, 960);
            this.panelSide.TabIndex = 14;
            // 
            // panelConnected
            // 
            this.panelConnected.Controls.Add(this.labelConnected);
            this.panelConnected.Location = new System.Drawing.Point(0, 0);
            this.panelConnected.Name = "panelConnected";
            this.panelConnected.Size = new System.Drawing.Size(426, 209);
            this.panelConnected.TabIndex = 0;
            this.panelConnected.Visible = false;
            // 
            // labelConnected
            // 
            this.labelConnected.AutoSize = true;
            this.labelConnected.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelConnected.Location = new System.Drawing.Point(133, 87);
            this.labelConnected.Name = "labelConnected";
            this.labelConnected.Size = new System.Drawing.Size(160, 37);
            this.labelConnected.TabIndex = 0;
            this.labelConnected.Text = "Połączono";
            // 
            // panelConnect
            // 
            this.panelConnect.Controls.Add(this.panelConnected);
            this.panelConnect.Controls.Add(this.textBoxPortI);
            this.panelConnect.Controls.Add(this.labelPortSeparator);
            this.panelConnect.Controls.Add(this.textBoxIPI4);
            this.panelConnect.Controls.Add(this.textBoxIPI3);
            this.panelConnect.Controls.Add(this.textBoxIPI2);
            this.panelConnect.Controls.Add(this.labelGetIP);
            this.panelConnect.Controls.Add(this.textBoxIPI1);
            this.panelConnect.Controls.Add(this.connectButton);
            this.panelConnect.Location = new System.Drawing.Point(18, 10);
            this.panelConnect.Name = "panelConnect";
            this.panelConnect.Size = new System.Drawing.Size(426, 202);
            this.panelConnect.TabIndex = 14;
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.buttonLogin);
            this.panelLogin.Controls.Add(this.labelLogin);
            this.panelLogin.Controls.Add(this.textBoxLogin);
            this.panelLogin.Controls.Add(this.labelPassword);
            this.panelLogin.Controls.Add(this.textBoxPassword);
            this.panelLogin.Location = new System.Drawing.Point(18, 237);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(426, 293);
            this.panelLogin.TabIndex = 13;
            this.panelLogin.Visible = false;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogin.Location = new System.Drawing.Point(27, 196);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(344, 63);
            this.buttonLogin.TabIndex = 13;
            this.buttonLogin.Text = "Log In";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // BMB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1436, 960);
            this.Controls.Add(this.panelSide);
            this.Controls.Add(this.panelGry);
            this.KeyPreview = true;
            this.Name = "BMB";
            this.Text = "--";
            this.Load += new System.EventHandler(this.BMB_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BMB_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BMB_KeyUp);
            this.panelSide.ResumeLayout(false);
            this.panelConnected.ResumeLayout(false);
            this.panelConnected.PerformLayout();
            this.panelConnect.ResumeLayout(false);
            this.panelConnect.PerformLayout();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGry;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox textBoxIPI1;
        private System.Windows.Forms.Label labelGetIP;
        private System.Windows.Forms.TextBox textBoxIPI2;
        private System.Windows.Forms.TextBox textBoxIPI4;
        private System.Windows.Forms.TextBox textBoxIPI3;
        private System.Windows.Forms.Label labelPortSeparator;
        private System.Windows.Forms.TextBox textBoxPortI;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panelConnected;
        private System.Windows.Forms.Label labelConnected;
        private System.Windows.Forms.Panel panelConnect;
        private System.Windows.Forms.Button buttonLogin;
    }
}

