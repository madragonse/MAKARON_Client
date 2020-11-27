
namespace BMB
{
    partial class client
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
            this.panelGnome = new System.Windows.Forms.Panel();
            this.panelCover = new System.Windows.Forms.Panel();
            this.panelGamesList = new System.Windows.Forms.Panel();
            this.panelLobbysList = new System.Windows.Forms.Panel();
            this.labelLobbyList = new System.Windows.Forms.Label();
            this.listBoxLobbys = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxGames = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelSide = new System.Windows.Forms.Panel();
            this.panelSetUp = new System.Windows.Forms.Panel();
            this.labelTest = new System.Windows.Forms.Label();
            this.panelSignUp = new System.Windows.Forms.Panel();
            this.labelSUError = new System.Windows.Forms.Label();
            this.labelPasswordAInSU = new System.Windows.Forms.Label();
            this.textBoxPasswordAInSU = new System.Windows.Forms.TextBox();
            this.buttonSUInSU = new System.Windows.Forms.Button();
            this.labelLoginInSU = new System.Windows.Forms.Label();
            this.textBoxLoginInSU = new System.Windows.Forms.TextBox();
            this.labelPasswordInSU = new System.Windows.Forms.Label();
            this.textBoxPasswordInSU = new System.Windows.Forms.TextBox();
            this.panelLOrSU = new System.Windows.Forms.Panel();
            this.buttonLIChoose = new System.Windows.Forms.Button();
            this.buttonSUChoose = new System.Windows.Forms.Button();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.labelLoginError = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.panelConnect = new System.Windows.Forms.Panel();
            this.panelConnected = new System.Windows.Forms.Panel();
            this.labelConnected = new System.Windows.Forms.Label();
            this.labelConnectingError = new System.Windows.Forms.Label();
            this.textBoxPortI = new System.Windows.Forms.TextBox();
            this.labelPortSeparator = new System.Windows.Forms.Label();
            this.textBoxIPI4 = new System.Windows.Forms.TextBox();
            this.textBoxIPI3 = new System.Windows.Forms.TextBox();
            this.textBoxIPI2 = new System.Windows.Forms.TextBox();
            this.labelGetIP = new System.Windows.Forms.Label();
            this.textBoxIPI1 = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelGry.SuspendLayout();
            this.panelGnome.SuspendLayout();
            this.panelGamesList.SuspendLayout();
            this.panelLobbysList.SuspendLayout();
            this.panelSide.SuspendLayout();
            this.panelSetUp.SuspendLayout();
            this.panelSignUp.SuspendLayout();
            this.panelLOrSU.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.panelConnect.SuspendLayout();
            this.panelConnected.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGry
            // 
            this.panelGry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGry.BackColor = System.Drawing.SystemColors.Info;
            this.panelGry.Controls.Add(this.panelGnome);
            this.panelGry.Controls.Add(this.panelGamesList);
            this.panelGry.Location = new System.Drawing.Point(0, 3);
            this.panelGry.Margin = new System.Windows.Forms.Padding(0);
            this.panelGry.Name = "panelGry";
            this.panelGry.Size = new System.Drawing.Size(977, 1031);
            this.panelGry.TabIndex = 0;
            this.panelGry.Resize += new System.EventHandler(this.panelGry_Resize);
            // 
            // panelGnome
            // 
            this.panelGnome.BackgroundImage = global::BMB.Properties.Resources.noggin;
            this.panelGnome.Controls.Add(this.panelCover);
            this.panelGnome.Location = new System.Drawing.Point(167, 56);
            this.panelGnome.Name = "panelGnome";
            this.panelGnome.Size = new System.Drawing.Size(692, 972);
            this.panelGnome.TabIndex = 19;
            this.panelGnome.Visible = false;
            // 
            // panelCover
            // 
            this.panelCover.Location = new System.Drawing.Point(3, -14);
            this.panelCover.Name = "panelCover";
            this.panelCover.Size = new System.Drawing.Size(733, 983);
            this.panelCover.TabIndex = 20;
            this.panelCover.Visible = false;
            // 
            // panelGamesList
            // 
            this.panelGamesList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelGamesList.Controls.Add(this.panelLobbysList);
            this.panelGamesList.Controls.Add(this.label1);
            this.panelGamesList.Controls.Add(this.listBoxGames);
            this.panelGamesList.Location = new System.Drawing.Point(273, 130);
            this.panelGamesList.Name = "panelGamesList";
            this.panelGamesList.Size = new System.Drawing.Size(401, 434);
            this.panelGamesList.TabIndex = 2;
            this.panelGamesList.Visible = false;
            // 
            // panelLobbysList
            // 
            this.panelLobbysList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelLobbysList.Controls.Add(this.labelLobbyList);
            this.panelLobbysList.Controls.Add(this.listBoxLobbys);
            this.panelLobbysList.Location = new System.Drawing.Point(0, 0);
            this.panelLobbysList.Name = "panelLobbysList";
            this.panelLobbysList.Size = new System.Drawing.Size(401, 434);
            this.panelLobbysList.TabIndex = 3;
            this.panelLobbysList.Visible = false;
            // 
            // labelLobbyList
            // 
            this.labelLobbyList.AutoSize = true;
            this.labelLobbyList.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLobbyList.Location = new System.Drawing.Point(119, 23);
            this.labelLobbyList.Name = "labelLobbyList";
            this.labelLobbyList.Size = new System.Drawing.Size(154, 31);
            this.labelLobbyList.TabIndex = 2;
            this.labelLobbyList.Text = "LISTA LOBB";
            // 
            // listBoxLobbys
            // 
            this.listBoxLobbys.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxLobbys.FormattingEnabled = true;
            this.listBoxLobbys.HorizontalScrollbar = true;
            this.listBoxLobbys.IntegralHeight = false;
            this.listBoxLobbys.ItemHeight = 30;
            this.listBoxLobbys.Location = new System.Drawing.Point(22, 79);
            this.listBoxLobbys.Name = "listBoxLobbys";
            this.listBoxLobbys.Size = new System.Drawing.Size(353, 329);
            this.listBoxLobbys.TabIndex = 1;
            this.listBoxLobbys.SelectedIndexChanged += new System.EventHandler(this.listBoxLobbys_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(119, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "LISTA GIER";
            // 
            // listBoxGames
            // 
            this.listBoxGames.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxGames.FormattingEnabled = true;
            this.listBoxGames.HorizontalScrollbar = true;
            this.listBoxGames.IntegralHeight = false;
            this.listBoxGames.ItemHeight = 30;
            this.listBoxGames.Location = new System.Drawing.Point(22, 79);
            this.listBoxGames.Name = "listBoxGames";
            this.listBoxGames.Size = new System.Drawing.Size(353, 329);
            this.listBoxGames.TabIndex = 1;
            this.listBoxGames.SelectedIndexChanged += new System.EventHandler(this.listBoxGames_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.contextMenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Text = "test";
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelSide.Controls.Add(this.panelSetUp);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSide.Location = new System.Drawing.Point(980, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(456, 1055);
            this.panelSide.TabIndex = 14;
            // 
            // panelSetUp
            // 
            this.panelSetUp.Controls.Add(this.labelTest);
            this.panelSetUp.Controls.Add(this.panelSignUp);
            this.panelSetUp.Controls.Add(this.panelLOrSU);
            this.panelSetUp.Controls.Add(this.panelLogin);
            this.panelSetUp.Controls.Add(this.panelConnect);
            this.panelSetUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetUp.Location = new System.Drawing.Point(0, 0);
            this.panelSetUp.Name = "panelSetUp";
            this.panelSetUp.Size = new System.Drawing.Size(456, 1055);
            this.panelSetUp.TabIndex = 0;
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTest.Location = new System.Drawing.Point(33, 691);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(69, 27);
            this.labelTest.TabIndex = 18;
            this.labelTest.Text = "label2";
            // 
            // panelSignUp
            // 
            this.panelSignUp.Controls.Add(this.labelSUError);
            this.panelSignUp.Controls.Add(this.labelPasswordAInSU);
            this.panelSignUp.Controls.Add(this.textBoxPasswordAInSU);
            this.panelSignUp.Controls.Add(this.buttonSUInSU);
            this.panelSignUp.Controls.Add(this.labelLoginInSU);
            this.panelSignUp.Controls.Add(this.textBoxLoginInSU);
            this.panelSignUp.Controls.Add(this.labelPasswordInSU);
            this.panelSignUp.Controls.Add(this.textBoxPasswordInSU);
            this.panelSignUp.Location = new System.Drawing.Point(0, 284);
            this.panelSignUp.Name = "panelSignUp";
            this.panelSignUp.Size = new System.Drawing.Size(453, 377);
            this.panelSignUp.TabIndex = 15;
            this.panelSignUp.Visible = false;
            // 
            // labelSUError
            // 
            this.labelSUError.AutoSize = true;
            this.labelSUError.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSUError.ForeColor = System.Drawing.Color.Red;
            this.labelSUError.Location = new System.Drawing.Point(32, 336);
            this.labelSUError.Name = "labelSUError";
            this.labelSUError.Size = new System.Drawing.Size(108, 23);
            this.labelSUError.TabIndex = 16;
            this.labelSUError.Text = "Coś nie tak: ";
            this.labelSUError.Visible = false;
            // 
            // labelPasswordAInSU
            // 
            this.labelPasswordAInSU.AutoSize = true;
            this.labelPasswordAInSU.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPasswordAInSU.Location = new System.Drawing.Point(22, 165);
            this.labelPasswordAInSU.Name = "labelPasswordAInSU";
            this.labelPasswordAInSU.Size = new System.Drawing.Size(213, 31);
            this.labelPasswordAInSU.TabIndex = 15;
            this.labelPasswordAInSU.Text = "Hasło jeszcze raz:";
            // 
            // textBoxPasswordAInSU
            // 
            this.textBoxPasswordAInSU.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPasswordAInSU.Location = new System.Drawing.Point(25, 199);
            this.textBoxPasswordAInSU.Name = "textBoxPasswordAInSU";
            this.textBoxPasswordAInSU.PasswordChar = '*';
            this.textBoxPasswordAInSU.Size = new System.Drawing.Size(350, 37);
            this.textBoxPasswordAInSU.TabIndex = 14;
            // 
            // buttonSUInSU
            // 
            this.buttonSUInSU.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSUInSU.Location = new System.Drawing.Point(25, 265);
            this.buttonSUInSU.Name = "buttonSUInSU";
            this.buttonSUInSU.Size = new System.Drawing.Size(344, 63);
            this.buttonSUInSU.TabIndex = 13;
            this.buttonSUInSU.Text = "SIGN UP";
            this.buttonSUInSU.UseVisualStyleBackColor = true;
            this.buttonSUInSU.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // labelLoginInSU
            // 
            this.labelLoginInSU.AutoSize = true;
            this.labelLoginInSU.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLoginInSU.Location = new System.Drawing.Point(18, 9);
            this.labelLoginInSU.Name = "labelLoginInSU";
            this.labelLoginInSU.Size = new System.Drawing.Size(83, 31);
            this.labelLoginInSU.TabIndex = 11;
            this.labelLoginInSU.Text = "Login:";
            // 
            // textBoxLoginInSU
            // 
            this.textBoxLoginInSU.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxLoginInSU.Location = new System.Drawing.Point(24, 43);
            this.textBoxLoginInSU.Name = "textBoxLoginInSU";
            this.textBoxLoginInSU.Size = new System.Drawing.Size(350, 37);
            this.textBoxLoginInSU.TabIndex = 9;
            // 
            // labelPasswordInSU
            // 
            this.labelPasswordInSU.AutoSize = true;
            this.labelPasswordInSU.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPasswordInSU.Location = new System.Drawing.Point(21, 87);
            this.labelPasswordInSU.Name = "labelPasswordInSU";
            this.labelPasswordInSU.Size = new System.Drawing.Size(84, 31);
            this.labelPasswordInSU.TabIndex = 12;
            this.labelPasswordInSU.Text = "Hasło:";
            // 
            // textBoxPasswordInSU
            // 
            this.textBoxPasswordInSU.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPasswordInSU.Location = new System.Drawing.Point(24, 121);
            this.textBoxPasswordInSU.Name = "textBoxPasswordInSU";
            this.textBoxPasswordInSU.PasswordChar = '*';
            this.textBoxPasswordInSU.Size = new System.Drawing.Size(350, 37);
            this.textBoxPasswordInSU.TabIndex = 10;
            // 
            // panelLOrSU
            // 
            this.panelLOrSU.Controls.Add(this.buttonLIChoose);
            this.panelLOrSU.Controls.Add(this.buttonSUChoose);
            this.panelLOrSU.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLOrSU.Location = new System.Drawing.Point(0, 202);
            this.panelLOrSU.Name = "panelLOrSU";
            this.panelLOrSU.Size = new System.Drawing.Size(456, 76);
            this.panelLOrSU.TabIndex = 17;
            this.panelLOrSU.Visible = false;
            // 
            // buttonLIChoose
            // 
            this.buttonLIChoose.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLIChoose.Location = new System.Drawing.Point(3, 6);
            this.buttonLIChoose.Name = "buttonLIChoose";
            this.buttonLIChoose.Size = new System.Drawing.Size(260, 59);
            this.buttonLIChoose.TabIndex = 15;
            this.buttonLIChoose.Text = "LOGIN";
            this.buttonLIChoose.UseVisualStyleBackColor = true;
            this.buttonLIChoose.Click += new System.EventHandler(this.buttonLIChoose_Click);
            // 
            // buttonSUChoose
            // 
            this.buttonSUChoose.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSUChoose.Location = new System.Drawing.Point(268, 6);
            this.buttonSUChoose.Name = "buttonSUChoose";
            this.buttonSUChoose.Size = new System.Drawing.Size(183, 59);
            this.buttonSUChoose.TabIndex = 16;
            this.buttonSUChoose.Text = "SIGN UP";
            this.buttonSUChoose.UseVisualStyleBackColor = true;
            this.buttonSUChoose.Click += new System.EventHandler(this.buttonSUChoose_Click);
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.labelLoginError);
            this.panelLogin.Controls.Add(this.buttonLogin);
            this.panelLogin.Controls.Add(this.labelLogin);
            this.panelLogin.Controls.Add(this.textBoxLogin);
            this.panelLogin.Controls.Add(this.labelPassword);
            this.panelLogin.Controls.Add(this.textBoxPassword);
            this.panelLogin.Location = new System.Drawing.Point(0, 284);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(453, 291);
            this.panelLogin.TabIndex = 13;
            this.panelLogin.Visible = false;
            // 
            // labelLoginError
            // 
            this.labelLoginError.AutoSize = true;
            this.labelLoginError.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLoginError.ForeColor = System.Drawing.Color.Red;
            this.labelLoginError.Location = new System.Drawing.Point(21, 251);
            this.labelLoginError.Name = "labelLoginError";
            this.labelLoginError.Size = new System.Drawing.Size(179, 23);
            this.labelLoginError.TabIndex = 14;
            this.labelLoginError.Text = "Błąd przy logowaniu:";
            this.labelLoginError.Visible = false;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogin.Location = new System.Drawing.Point(24, 185);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(344, 63);
            this.buttonLogin.TabIndex = 13;
            this.buttonLogin.Text = "LOG IN";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
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
            // textBoxLogin
            // 
            this.textBoxLogin.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxLogin.Location = new System.Drawing.Point(24, 43);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(350, 37);
            this.textBoxLogin.TabIndex = 9;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPassword.Location = new System.Drawing.Point(19, 89);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(84, 31);
            this.labelPassword.TabIndex = 12;
            this.labelPassword.Text = "Hasło:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPassword.Location = new System.Drawing.Point(22, 123);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(350, 37);
            this.textBoxPassword.TabIndex = 10;
            // 
            // panelConnect
            // 
            this.panelConnect.Controls.Add(this.panelConnected);
            this.panelConnect.Controls.Add(this.labelConnectingError);
            this.panelConnect.Controls.Add(this.textBoxPortI);
            this.panelConnect.Controls.Add(this.labelPortSeparator);
            this.panelConnect.Controls.Add(this.textBoxIPI4);
            this.panelConnect.Controls.Add(this.textBoxIPI3);
            this.panelConnect.Controls.Add(this.textBoxIPI2);
            this.panelConnect.Controls.Add(this.labelGetIP);
            this.panelConnect.Controls.Add(this.textBoxIPI1);
            this.panelConnect.Controls.Add(this.connectButton);
            this.panelConnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConnect.Location = new System.Drawing.Point(0, 0);
            this.panelConnect.Name = "panelConnect";
            this.panelConnect.Size = new System.Drawing.Size(456, 202);
            this.panelConnect.TabIndex = 14;
            // 
            // panelConnected
            // 
            this.panelConnected.Controls.Add(this.labelConnected);
            this.panelConnected.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConnected.Location = new System.Drawing.Point(0, 0);
            this.panelConnected.Name = "panelConnected";
            this.panelConnected.Size = new System.Drawing.Size(456, 202);
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
            // labelConnectingError
            // 
            this.labelConnectingError.AutoSize = true;
            this.labelConnectingError.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelConnectingError.ForeColor = System.Drawing.Color.Red;
            this.labelConnectingError.Location = new System.Drawing.Point(21, 168);
            this.labelConnectingError.Name = "labelConnectingError";
            this.labelConnectingError.Size = new System.Drawing.Size(182, 23);
            this.labelConnectingError.TabIndex = 15;
            this.labelConnectingError.Text = "Błąd przy połączeniu.";
            this.labelConnectingError.Visible = false;
            // 
            // textBoxPortI
            // 
            this.textBoxPortI.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPortI.Location = new System.Drawing.Point(306, 45);
            this.textBoxPortI.Name = "textBoxPortI";
            this.textBoxPortI.Size = new System.Drawing.Size(65, 37);
            this.textBoxPortI.TabIndex = 8;
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
            // textBoxIPI2
            // 
            this.textBoxIPI2.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxIPI2.Location = new System.Drawing.Point(88, 45);
            this.textBoxIPI2.Name = "textBoxIPI2";
            this.textBoxIPI2.Size = new System.Drawing.Size(60, 37);
            this.textBoxIPI2.TabIndex = 4;
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
            // textBoxIPI1
            // 
            this.textBoxIPI1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxIPI1.Location = new System.Drawing.Point(22, 45);
            this.textBoxIPI1.Name = "textBoxIPI1";
            this.textBoxIPI1.Size = new System.Drawing.Size(60, 37);
            this.textBoxIPI1.TabIndex = 2;
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
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1436, 1055);
            this.Controls.Add(this.panelSide);
            this.Controls.Add(this.panelGry);
            this.KeyPreview = true;
            this.Name = "client";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "--";
            this.Load += new System.EventHandler(this.BMB_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BMB_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BMB_KeyUp);
            this.panelGry.ResumeLayout(false);
            this.panelGnome.ResumeLayout(false);
            this.panelGamesList.ResumeLayout(false);
            this.panelGamesList.PerformLayout();
            this.panelLobbysList.ResumeLayout(false);
            this.panelLobbysList.PerformLayout();
            this.panelSide.ResumeLayout(false);
            this.panelSetUp.ResumeLayout(false);
            this.panelSetUp.PerformLayout();
            this.panelSignUp.ResumeLayout(false);
            this.panelSignUp.PerformLayout();
            this.panelLOrSU.ResumeLayout(false);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelConnect.ResumeLayout(false);
            this.panelConnect.PerformLayout();
            this.panelConnected.ResumeLayout(false);
            this.panelConnected.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGry;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.ListBox listBoxGames;
        private System.Windows.Forms.Panel panelGamesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Panel panelSetUp;
        private System.Windows.Forms.Panel panelSignUp;
        private System.Windows.Forms.Label labelPasswordAInSU;
        private System.Windows.Forms.TextBox textBoxPasswordAInSU;
        private System.Windows.Forms.Button buttonSUInSU;
        private System.Windows.Forms.Label labelLoginInSU;
        private System.Windows.Forms.TextBox textBoxLoginInSU;
        private System.Windows.Forms.Label labelPasswordInSU;
        private System.Windows.Forms.TextBox textBoxPasswordInSU;
        private System.Windows.Forms.Panel panelLOrSU;
        private System.Windows.Forms.Button buttonLIChoose;
        private System.Windows.Forms.Button buttonSUChoose;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label labelLoginError;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Panel panelConnect;
        private System.Windows.Forms.Panel panelConnected;
        private System.Windows.Forms.Label labelConnected;
        private System.Windows.Forms.Label labelConnectingError;
        private System.Windows.Forms.TextBox textBoxPortI;
        private System.Windows.Forms.Label labelPortSeparator;
        private System.Windows.Forms.TextBox textBoxIPI4;
        private System.Windows.Forms.TextBox textBoxIPI3;
        private System.Windows.Forms.TextBox textBoxIPI2;
        private System.Windows.Forms.Label labelGetIP;
        private System.Windows.Forms.TextBox textBoxIPI1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label labelSUError;
        private System.Windows.Forms.Panel panelLobbysList;
        private System.Windows.Forms.Label labelLobbyList;
        private System.Windows.Forms.ListBox listBoxLobbys;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.Panel panelGnome;
        private System.Windows.Forms.Panel panelCover;
    }
}

