using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace BMB
{
    public partial class BMB : Form
    {
        Thread graphicsThread;
        Graphics fG;
        bool workign = true;

        BMB_Main game_BMB;
        BMB_Input input;


        public BMB()
        {
            InitializeComponent();
            this.Width = 770;
            this.Height = 790;
        }

        private void BMB_Load(object sender, EventArgs e)
        {
            input = new BMB_Input();
            game_BMB = new BMB_Main(750, 750, input, 25, 25);

            fG = CreateGraphics();
            graphicsThread = new Thread(game);
            graphicsThread.IsBackground = true;
            graphicsThread.Start();
        }

        public void game()
        {

            PointF img = new PointF(0, 0);
            int drawId = -1;


            while (workign)
            {


                if (drawId == game_BMB.drawingId)
                {

                    continue;
                }
                drawId = game_BMB.drawingId;

                game_BMB.nextToDraw();

                //Thread.Sleep(1000);
                fG.DrawImage(game_BMB.btmReady, img);


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
