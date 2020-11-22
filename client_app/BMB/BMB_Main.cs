using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BMB
{
    class BMB_Main
    {
        private Graphics g;
        private Graphics gReady;
        private Bitmap btm;
        public Bitmap btmReady;
        private RectangleF area;
        private Pen pen;

        public int drawingId = 0;
        private int toDrawId = 0;
        public bool drawing = true;
        public bool processing = true;

        private int height;
        private int width;
        private Thread drawingThread;
        private Thread processingThread;

        public BMB_Input input;

        public int mapSizeX;
        public int mapSizeY;
        private float fieldSizeX;
        private float fieldSizeY;
        public byte[,] map;


        public BMB_Main(int width, int height, BMB_Input pointerToInput)
        {
            this.height = height;
            this.width = width;

            this.input = pointerToInput;

            this.btm = new Bitmap(width, height);
            this.btmReady = new Bitmap(width, height);
            this.g = Graphics.FromImage(btm);
            this.gReady = Graphics.FromImage(btmReady);
            this.pen = new Pen(Color.White, 1.0f);

            drawingThread = new Thread(this.draw);
            drawingThread.IsBackground = true;
            drawingThread.Start();

            /*processingThread = new Thread(this.process);
            processingThread.IsBackground = true;
            processingThread.Start();*/


        }

        public BMB_Main(int height, int width, BMB_Input pointerToInput, int mapSizeX, int mapSizeY) : this(height, width, pointerToInput)
        {
            this.mapSizeX = mapSizeX;
            this.mapSizeY = mapSizeY;

            this.fieldSizeX = (float)this.width / (float)this.mapSizeX; 
            this.fieldSizeY = (float)this.height / (float)this.mapSizeY;


            this.area = new RectangleF(0, 0, (int)this.fieldSizeX, (int)this.fieldSizeY);

            this.map = new byte[mapSizeX, mapSizeY];


            //TEST
            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    map[j, i] = 0;
                }
            }
        }


        /// <summary>
        /// Metoda rysująca wszystkie obiekty na bitmapie [btm]. 
        /// Jest wywoływana tylko jeżeli jest coś nowego do rysowania [toDrawIdThread, toDrawId] 
        /// (zapobiega obciążaniu procesora niepotrzebnie)(patrz zastosowanie w Form1.cs)
        /// 
        /// Tutaj łączą się bitmapy z różnych obiektów odpowiadających za różne rzeczy w grze.
        /// Pracuje na oddzeilnym wątku.
        /// </summary>
        private void draw()
        {
            int toDrawIdThread = 0;






            RectangleF areaTocopy;
            areaTocopy = new RectangleF(0, 0, this.height, this.width);


            while (this.drawing)
            {

                if (toDrawIdThread == this.toDrawId)
                {
                    Thread.Sleep(1);
                    continue;
                }
                toDrawIdThread = this.toDrawId;

                this.g.Clear(Color.Black);

                this.generateMap();
                //this.generateTest();

                this.gReady.DrawImage(this.btm, areaTocopy);

                this.nextDrawing();





            }


        }

        public void nextDrawing()
        {
            this.drawingId++;
            if (this.drawingId > 2000000000)
            {
                this.drawingId = 0;
            }
        }

        public void nextToDraw()
        {
            this.toDrawId++;
            if (this.toDrawId > 2000000000)
            {
                this.toDrawId = 0;
            }
        }

        private void process()
        {
            Thread.Sleep(500);

            while (processing == true)
            {

            }
        }


        private void generateMap()
        {

            for(int i = 0; i < this.mapSizeY; i++)
            {
                this.area.Y = i*this.fieldSizeY;

                for (int j = 0; j < this.mapSizeX; j++)
                {
                    this.area.X = j * this.fieldSizeX;

                    this.g.DrawEllipse(this.pen, this.area);
                }
            }



        }
    }
}
