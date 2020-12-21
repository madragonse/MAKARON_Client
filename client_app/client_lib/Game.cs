using packages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client_lib
{
    public abstract class Game
    {
        public Bitmap bitmap;
        protected Graphics grafika;
        protected Pen pen;
        protected SolidBrush brush;


        /// <summary>
        /// Wymiary w pixelach
        /// </summary>
        protected int height;
        protected int width;

        public Game(NetworkStream stream, int width, int height)
        {
            this.stream = stream;

            this.width = width;
            this.height = height;

            this.pen = new Pen(Color.White, 1.0f);
            this.brush = new SolidBrush(Color.White);

            this.bitmap = new Bitmap(this.width, this.height);
            this.grafika = Graphics.FromImage(bitmap);
        }
    //TEST
        public Game(int width, int height)
        {

            this.width = width;
            this.height = height;

            this.pen = new Pen(Color.White, 1.0f);
            this.brush = new SolidBrush(Color.White);

            this.bitmap = new Bitmap(this.width, this.height);
            this.grafika = Graphics.FromImage(bitmap);
        }

        private NetworkStream stream;
        public abstract void update(Dictionary<string, bool> buttons, float deltatime);
        public abstract void process(Queue q);

        public abstract List<Package> getPackages();

        //skaluje rozmiar generowanej bitmapy do nowego rozmiaty 
        public abstract void scale(int x, int y);


    }
}
