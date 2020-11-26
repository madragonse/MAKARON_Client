using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using client_lib;

namespace BMB
{


    public partial class BMB : Form
    {
        private Thread mainLoopThread;
        private Graphics window;
        private PointF cornerPoint;

        private Game game;
        private BMB_Input input;

        private int serverPort;
        private IPAddress serverIP;
        private TCP_Connector connector;
        private Communication_Package package;
        private List<String> packageArguments;

        private int choosenGame;

        public BMB()
        {
            InitializeComponent();
            /*this.Width = 1100;
            this.Height = 850;*/

        }

        private void BMB_Load(object sender, EventArgs e)
        {
            
            this.input = new BMB_Input();
            this.cornerPoint = new PointF(0, 0);

            //this.window = CreateGraphics();

            this.connector = new TCP_Connector();
            this.package = new Communication_Package();

            this.choosenGame = 0;

            this.mainLoopThread = new Thread(MainLoop);
            this.mainLoopThread.IsBackground = true;
            this.mainLoopThread.Start();

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            /*panelGry.Width = 750;
            panelGry.Height = 750;*/
            this.window = panelGry.CreateGraphics();

        }

        public void MainLoop()
        {
            bool playing = false;
            panelGry.Paint += new PaintEventHandler(panel1_Paint);
            while (true)
            {
                //TEST
                playing = true;
                this.game = new Game_Bomberman(this.panelGry.Width - 1, this.panelGry.Height - 1, 25, 25);
                if (this.choosenGame != 0)
                {
                    playing = true;

                    switch (this.choosenGame)
                    {
                        case 1:
                            //TODO stream do gry
                            this.game = new Game_Bomberman(this.panelGry.Width - 1, this.panelGry.Height - 1, 25, 25);
                            break;

                        default:
                            playing = false;
                            break;
                            
                    }


                }

                Thread.Sleep(100);
                while (playing)
                {
                    //TODO - 

                    //Serwer->recive()
                    this.game.process();/*TODO*/
                    //Server->send(Game->getPackets())
                    this.game.update(this.input.buttons, 10f/*TODO - deltaTime*/);
                    window.DrawImage(this.game.bitmap, cornerPoint);
                    
                }
            }
        }

        private void BMB_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
            if (Keyboard.IsKeyDown(Key.W))
            {
                input.buttons["W"] = true;
            }

            if (Keyboard.IsKeyDown(Key.S))
            {
                input.buttons["S"] = true;
            }

            if (Keyboard.IsKeyDown(Key.A))
            {
                input.buttons["A"] = true;
            }

            if (Keyboard.IsKeyDown(Key.D))
            {
                input.buttons["D"] = true;
            }
            //TODO - dodać inne przyciski
        }

        private void BMB_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Keyboard.IsKeyUp(Key.W))
            {
                input.buttons["W"] = false;
            }

            if (Keyboard.IsKeyUp(Key.S))
            {
                input.buttons["S"] = false;
            }

            if (Keyboard.IsKeyUp(Key.A))
            {
                input.buttons["A"] = false;
            }

            if (Keyboard.IsKeyUp(Key.D))
            {
                input.buttons["D"] = false;
            }
            //TODO - dodać inne przyciski
        }

        private void connectButton_Click(object sender, EventArgs e)
        {

            byte[] addressIP = new byte[4];
            addressIP[0] = (byte)short.Parse(this.textBoxIPI1.Text);
            addressIP[1] = (byte)short.Parse(this.textBoxIPI2.Text);
            addressIP[2] = (byte)short.Parse(this.textBoxIPI3.Text);
            addressIP[3] = (byte)short.Parse(this.textBoxIPI4.Text);
            this.serverPort = int.Parse(this.textBoxPortI.Text);
            this.serverIP = new IPAddress(addressIP);

            this.connectToServer();



        }

        private void connectToServer()
        {
            
            try
            {
                this.connector = new TCP_Connector(this.serverPort, this.serverIP);
                this.connector.Connect();
                this.panelConnected.Visible = true;
                this.panelConnect.Visible = false;
                this.panelLOrSU.Visible = true;

            }
            catch (Exception)
            {
                this.labelConnectingError.Visible = true;
            }
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String login = this.textBoxLogin.Text;
            String password = ComputeSha256Hash(this.textBoxPassword.Text);

            this.package.SetTypeLOGIN(login, password);
            this.connector.Send(this.package);

            //handle response 
            this.package=this.connector.ReceivePackage();
            this.packageArguments = this.package.getArguments();

            //if login successfull
            if (packageArguments[0] == "LOGIN_CONFIRM")
            {
                this.panelSetUp.Visible = false;
                this.populateGameMenu();
            }
            if (packageArguments[0] == "LOGIN_REFUSE")
            {
                this.labelLoginError.Visible = true;
                this.labelLoginError.Text = "Błąd logowania: " + this.packageArguments[1]; 
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            //TO DO-> get field values
            String login = this.textBoxLoginInSU.Text;
            String password = this.textBoxPasswordInSU.Text;
            String confpassword = this.textBoxPasswordAInSU.Text;

            if (password != confpassword) {
                //TO DO DISPLAY passwords don't match
                return;
            }

            //TO DO DISPLAY why password is wrong
            String illegalPassword= checkForIllegalPassword(password);
            if (illegalPassword != "")
            {
                //TO DO display failed login, illegalPassword holds reason
                return;
            }

            this.package.SetTypeSIGNUP(login, ComputeSha256Hash(password));
            this.connector.Send(this.package);

            //handle response 
            this.package = this.connector.ReceivePackage();
            this.packageArguments = this.package.getArguments();

            //if login successfull
            if (packageArguments[0] == "SIGNUP_CONFIRM")
            {
                //TODO launch sign in box
                this.panelSetUp.Visible = false;
            }
            if (packageArguments[0] == "SIGNUP_REFUSE")
            {
                //TO DO display failed login message packageArguments[1] holds string with reason
                this.labelSUError.Text = "Coś nie tak: " + this.packageArguments[1];
                this.labelSUError.Visible = true;
            }

        }

        //TO DO
        private void populateGameMenu()
        {
            //request list of available games
            this.package.SetTypeREQUEST_GAME_LIST();
            this.connector.Send(this.package);

            //server sends list package with all the avaiable games
            this.package = this.connector.ReceivePackage();
            this.packageArguments = this.package.getArguments();
            this.panelGames.Visible = true;
            if (packageArguments[0] == "LIST")
            {
                for(int i = 1; i < packageArguments.Count; i++)
                {
                    //DISPLAY THEM SOMEHOW
                    this.listBoxGames.Items.Add(packageArguments[i]);
                }
            }
        }

        private void listBoxGames_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (this.listBoxGames.SelectedItem.ToString().Equals("Bomberman"))
            {
                this.choosenGame = 1;
            }


        }

        private void buttonLIChoose_Click(object sender, EventArgs e)
        {
            this.panelSignUp.Visible = false;
            this.panelLogin.Visible = true;
        }

        private void buttonSUChoose_Click(object sender, EventArgs e)
        {
            this.panelLogin.Visible = false;
            this.panelSignUp.Visible = true;
        }

        /// <summary>
        /// Hashes a given string.
        /// Returns a hashed string.
        /// Taken from: https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/
        /// </summary>
        /// <param data to be encoded="rawData"></param>
        /// <returns>Returns a hashed string</returns>
        private static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private String checkForIllegalPassword(String pass)
        {
            bool upperLetterFlag = false;
            bool numberFlag = false;
            //contains at least one number and at least one uppercase letter
            foreach (char c in pass)
            {
                if (c > 64 && c < 91) { upperLetterFlag = true; }
                if (c > 47 && c < 57) { numberFlag = true; }
            }

            if (!upperLetterFlag) { return "Pasword must contain at least one upper case letter"; }
            if (!numberFlag) { return "Pasword must contain at least one number"; }
            return "";
        }
    }
}
