using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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


        public BMB()
        {
            InitializeComponent();
            this.Width = 770;
            this.Height = 790;
        }

        private void BMB_Load(object sender, EventArgs e)
        {
            this.input = new BMB_Input();
            this.cornerPoint = new PointF(0, 0);

            this.window = CreateGraphics();
            this.mainLoopThread = new Thread(MainLoop);
            this.mainLoopThread.IsBackground = true;
            this.mainLoopThread.Start();
        }


        public void MainLoop()
        {
            


            while (true)
            {

                //TODO - menu

                this.game = new Game_Bomberman(/*TODO - stream*//*new NetworkStream(new Socket(new SocketType(), new ProtocolType())),*/ 750, 750, 25, 25);

                while (true)
                {




                    //TODO - 

                    //Serwer->recive()
                    this.game.process();/*TODO*/
                    //Server->send(Game->getPackets())
                    this.game.update(this.input.buttons, 10/*TODO - deltaTime*/);
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


        }
    }
}
