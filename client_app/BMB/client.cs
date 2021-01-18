using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using client_lib;
using packages;

namespace BMB
{
    public partial class client : Form
    {
        private Thread mainLoopThread;
        private Thread reciveThread;
        private Graphics window;
        private PointF cornerPoint;
        public delegate void update(String arg);
        public update updateFormDelegate;

        private Game game;
        private Input input;
        SoundPlayer audio;

        private int serverPort;
        private IPAddress serverIP;
        private TCP_Connector connector;
        private Communication_Package cpackage;
        private Communication_Package pingPackage;
        private Package package;
        private List<String> packageArguments;
        private Queue gamePackages;
        private Queue wrapperGamePackages;
        

        private int choosenGame;
        ScreenSaver screenSaver;

        //TEST
        Stopwatch sww;


        public client()
        {
            InitializeComponent();

        }

        private void BMB_Load(object sender, EventArgs e)
        {
            
            this.input = new Input();
            this.cornerPoint = new PointF(0, 0);
            this.buttonReady.Visible = false;
            //this.window = CreateGraphics();

            this.connector = new TCP_Connector();
            this.package = new Package();
            this.cpackage = new Communication_Package();
            this.pingPackage = new Communication_Package();
            pingPackage.SetTypePING();
            this.gamePackages = new Queue();

            this.choosenGame = 0;

            this.mainLoopThread = new Thread(MainLoop);
            this.mainLoopThread.IsBackground = true;
            this.mainLoopThread.Start();

            audio = new SoundPlayer(BMB.Properties.Resources.gnome);


            //TEST
            sww = Stopwatch.StartNew();
            this.updateFormDelegate = new update(updateForm);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.window = panelGry.CreateGraphics();
        }

        public void MainLoop()
        {
            panelGry.Paint += new PaintEventHandler(panel1_Paint);
            Thread.Sleep(1000);

            Stopwatch sw = Stopwatch.StartNew();
            bool playing = false;
            

            screenSaver = new ScreenSaver(this.panelGry.Width, this.panelGry.Height, 15, 15);

            while (true)
            {
                //this.Invoke(this.updateFormDelegate, "test test !!!");
                //TEST
                /*playing = true;
                this.game = new Game_Bomberman(this.panelGry.Width - 1, this.panelGry.Height - 1, 25, 25);*/
                //choosenGame = 1;
                if (this.choosenGame != 0)
                {
                    playing = true;

                    switch (this.choosenGame)
                    {
                        case 1:
                            //TODO stream do gry
                            this.game = new Game_Bomberman(this.panelGry.Width - 1, this.panelGry.Height - 1, 15, 15);
                            break;

                        default:
                            playing = false;
                            break;
                            
                    }


                }

                screenSaver.generateBmp(sw.ElapsedMilliseconds/4);
                sw.Restart();
                sw.Start();
                try
                {
                    this.window.DrawImage(screenSaver.bitmap, cornerPoint);
                }
                catch(System.InvalidOperationException) { 
                    
                }
                

                while (playing)
                {
                    //TODO - 

                    
                    this.game.process(this.wrapperGamePackages);
                    List<Package> packagesToSend = this.game.getPackages();
                    this.connector.Send(packagesToSend);

                    sw.Stop();
                    this.game.update(this.input.buttons, sw.ElapsedMilliseconds);
                 
                    sw.Restart();
                    sw.Start();

                    this.window.DrawImage(this.game.bitmap, cornerPoint);
                    this.Invoke(this.updateFormDelegate, "test test !!!");

                    Thread.Sleep(100);
                }
            }
        }

        public void updateForm(String arg)
        {
            sww.Stop();
            this.labelTest.Text = "FPS: " + (float)(1000.0 / sww.ElapsedMilliseconds);
            //this.labelTest.Text = arg;
            sww.Restart();
            sww.Start();
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

            if (Keyboard.IsKeyDown(Key.LeftAlt))
            {
                input.buttons["Space"] = true;
            }

            if (Keyboard.IsKeyDown(Key.G))
            {
                this.audio.Play();
                Thread.Sleep(600);
                this.panelGnome.Visible = true;
                Thread.Sleep(70);
                this.panelGnome.Visible = false;

            }

     
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

            if (Keyboard.IsKeyUp(Key.LeftAlt))
            {
                input.buttons["Space"] = false;
            }
            //TODO - dodać inne przyciski


        }

        private void connectButton_Click(object sender, EventArgs e)
        {

            byte[] addressIP = new byte[4];
            if (this.textBoxIPI1.Text.Equals(""))
                return;
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
                this.KeepConnectionAlive();
                this.panelConnected.Visible = true;
                this.panelConnect.Visible = false;
                this.panelLOrSU.Visible = true;

            }
            catch (Exception)
            {
                this.labelConnectingError.Visible = true;
            }
        }

        private void KeepConnectionAlive()
        {
            new Thread(() =>
            {
                while (true)
                {
                    this.connector.Send(this.pingPackage);
                    Thread.Sleep(4500);
                }

            }).Start();
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String login = this.textBoxLogin.Text;
            String password = ComputeSha256Hash(this.textBoxPassword.Text);
            LogIn(login, password);
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            //TO DO-> get field values
            String login = this.textBoxLoginInSU.Text;
            String password = this.textBoxPasswordInSU.Text;
            String confpassword = this.textBoxPasswordAInSU.Text;

            if (password != confpassword) {
                this.labelSUError.Text = "Hasła nie zgadzają się!";
                this.labelSUError.Visible = true;
                return;
            }

            String illegalPassword= checkForIllegalPassword(password);
            if (illegalPassword != "")
            {
                this.labelSUError.Text = "Niedozwolone hasło: " + illegalPassword;
                this.labelSUError.Visible = true;
                return;
            }

            this.cpackage.SetTypeSIGNUP(login, ComputeSha256Hash(password));
            this.connector.Send(this.cpackage);

            //handle response 
            this.package =  this.connector.ReceivePackage();
            this.packageArguments = this.package.getArguments();

            //if login successfull
            if (packageArguments[0] == "SIGNUP_CONFIRM")
            {
                LogIn(login, ComputeSha256Hash(password));
            }
            if (packageArguments[0] == "SIGNUP_REFUSE")
            {
                this.labelSUError.Text = "Coś nie tak: " + this.packageArguments[2];
                this.labelSUError.Visible = true;
            }

        }

        private void populateLobbyMenu()
        {
            //request list of available games
            this.cpackage.SetTypeREQUEST_LOBBY_LIST();
            this.connector.Send(this.cpackage);

            //server sends list package with all the avaiable games
            this.package =  this.connector.ReceivePackage();
            this.packageArguments = this.package.getArguments();
            this.panelGamesList.Visible = true;
            if (packageArguments[0] == "LIST")
            {
                for(int i = 1; i < packageArguments.Count; i++)
                {
                    //DISPLAY THEM SOMEHOW
                    this.listBoxGames.Items.Add(packageArguments[i]);
                }
            }
        }

        //Populate lobby 
        private void populateLobbyMenu(String gameName)
        {
            //request list of available games
            this.cpackage.SetTypeREQUEST_LOBBY_LIST_ARG(gameName);
            this.connector.Send(this.cpackage);

            //server sends list package with all the avaiable games
            this.package =  this.connector.ReceivePackage();
            this.packageArguments = this.package.getArguments();
            this.panelGamesList.Visible = true;
            if (packageArguments[0] == "LIST")
            {
                for (int i = 1; i < packageArguments.Count; i++)
                {
                    //DISPLAY THEM SOMEHOW
                    this.listBoxGames.Items.Add(packageArguments[i]);
                }
            }
        }

        private void listBoxGames_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.panelGamesList.Visible = true;
            //catch null value error
            if (this.listBoxGames.SelectedItem == null) { return; }

            String[] spl = this.listBoxGames.SelectedItem.ToString().Split('\n');
            String chosenGame = spl[2];
            String chosenLobbyName = spl[1];

            //try to join chosen lobby
            this.cpackage.SetTypeJOIN_LOBBY(spl[1]);
            this.connector.Send(this.cpackage);

            //handle response 
            this.package =  this.connector.ReceivePackage();
            this.packageArguments = this.package.getArguments();

            //if joined successfully
            if (packageArguments[0] == "JOIN_LOBBY_CONFIRM")
            {
                this.panelGamesList.Visible = false;
                this.buttonReady.Visible = true;
                //TODO SHOW LOBBY MENU

                if (chosenGame.Equals("BOMBERMAN"))
                {
                    this.choosenGame = 1;
                }

                this.reciveThread = new Thread(recive);
                this.reciveThread.IsBackground = true;
                this.reciveThread.Start();
            }

              
            if (packageArguments[0] == "JOIN_LOBBY_REFUSE")
            {
                //TODO SHOW ERROR JOINING LOBBY
                populateLobbyMenu(); //refresh lobby list
            }

        }


        private void recive()
        { 
            this.wrapperGamePackages = Queue.Synchronized(this.gamePackages);

            this.wrapperGamePackages.Enqueue(new Bomberman_Package());

            while (true)
            {
                Package temPac = this.connector.ReceivePackage();
                this.wrapperGamePackages.Enqueue(temPac);
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

        private void panelGry_Resize(object sender, EventArgs e)
        {
            /*if (this.screenSaver != null)
            {
                if (this.panelGry.Width < this.panelGry.Height)
                {
                    this.screenSaver.scale((int)(this.panelGry.Width * 1.175), (int)(this.panelGry.Width * 1.175));
                }
                else
                {
                    this.screenSaver.scale((int)(this.panelGry.Height * 1.175), (int)(this.panelGry.Height * 1.175));
                }
            }*/

            //this.labelTest.Text = this.Height + " " + this.Width;

            if (this.screenSaver != null)
                this.screenSaver.scale((int)(this.Height*1.175), (int)(this.Height * 1.175));

            if (this.game != null)
                this.game.scale((int)(this.Height * 1.175), (int)(this.Height * 1.175));


        }

        private void panelGry_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void buttonReady_Click(object sender, EventArgs e)
        {
            this.cpackage.SetTypeLOBBY_READY();
            this.connector.Send(this.cpackage);
        }

        private void LogIn(String login,String hashed_password)
        {
          
            this.cpackage.SetTypeLOGIN(login, hashed_password);
            this.connector.Send(this.cpackage);

            //handle response 
            this.package = this.connector.ReceivePackage();
            this.packageArguments = this.package.getArguments();

            //if login successfull
            if (packageArguments[0] == "LOGIN_CONFIRM")
            {
                this.panelSetUp.Visible = false;
                populateLobbyMenu();
            }
            if (packageArguments[0] == "LOGIN_REFUSE")
            {
                this.labelLoginError.Visible = true;
                this.labelLoginError.Text = "Błąd logowania: " + this.packageArguments[2];
            }

        }


        //guest logIN
        private void button1_Click(object sender, EventArgs e)
        {
            LogIn("Kret", "e2f0c2aafca651a80fe70ca7159ad93a2915e9a99cf34b1eebd0412aec2e3dac");
        }
    }
}

