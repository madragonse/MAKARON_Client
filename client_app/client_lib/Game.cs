using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client_lib
{
    abstract class Game
    {
        public Bitmap bitmap;
        protected Graphics grafika;
        protected Pen pen;


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
        }

        private NetworkStream stream;
        public abstract void update(Dictionary<string, bool> buttons);


    }
}
