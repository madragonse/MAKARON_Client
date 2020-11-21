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

        public int drawingId = 0;
        private int toDrawId = 0;
        public bool drawing = true;
        public bool processing = true;

        private int height = 750;
        private int width = 750;
        private Thread drawingThread;
        private Thread processingThread;

        public BMB_Input input;

        //Lista obiektów generująca bitmapy do narysowania
        private Example_Orbiting exampleObjectWithSomethingToDraw;


        public bool pressE = false;


        public BMB_Main(int height, int width, BMB_Input pointerToInput)
        {
            this.height = height;
            this.width = width;

            this.input = pointerToInput;

            this.btm = new Bitmap(height, width);
            this.btmReady = new Bitmap(height, width);
            this.g = Graphics.FromImage(btm);
            this.gReady = Graphics.FromImage(btmReady);

            drawingThread = new Thread(this.draw);
            drawingThread.IsBackground = true;
            drawingThread.Start();

            processingThread = new Thread(this.process);
            processingThread.IsBackground = true;
            processingThread.Start();


            exampleObjectWithSomethingToDraw = new Example_Orbiting();

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






            RectangleF areaToSytuatePictureOnBitmap;
            areaToSytuatePictureOnBitmap = new RectangleF(0, 0, this.height, this.width);


            while (this.drawing)
            {

                if (toDrawIdThread == this.toDrawId)
                {
                    Thread.Sleep(1);
                    continue;
                }
                toDrawIdThread = this.toDrawId;

                this.g.Clear(Color.Black);

                this.g.DrawImage(exampleObjectWithSomethingToDraw.generate(), areaToSytuatePictureOnBitmap);

                this.gReady.DrawImage(this.btm, areaToSytuatePictureOnBitmap);
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
                exampleObjectWithSomethingToDraw.process(this.input);

            }
        }
    }
}
