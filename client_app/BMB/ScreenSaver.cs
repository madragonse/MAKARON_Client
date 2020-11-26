using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMB
{
    public class ScreenSaver
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

        private RectangleF field;
        private float fieldWidth;
        private float fieldHeight;

        public int mapSizeX;
        public int mapSizeY;

        public float[,,] map;

        Random rand;

        public ScreenSaver(int width, int height, int mapSizeX, int mapSizeY)
        {
            this.rand = new Random();

            this.width = width;
            this.height = height;

            this.pen = new Pen(Color.White, 1.0f);
            this.brush = new SolidBrush(Color.White);

            this.bitmap = new Bitmap(this.width, this.height);
            this.grafika = Graphics.FromImage(bitmap);


            this.mapSizeX = mapSizeX;
            this.mapSizeY = mapSizeY;

            this.fieldWidth = (float)this.width / (float)this.mapSizeX;
            this.fieldHeight = (float)this.height / (float)this.mapSizeY;


            this.field = new RectangleF(0, 0, (int)this.fieldWidth, (int)this.fieldHeight);

            this.map = new float[mapSizeX, mapSizeY, 3];


            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {

                    this.map[j, i, 0] = (byte)(this.rand.Next() % 255);
                    this.map[j, i, 1] = (byte)(this.rand.Next() % 255);
                    this.map[j, i, 2] = (byte)(this.rand.Next() % 255);
                }
            }
        }

        public void generateBmp(float deltatime)
        {
            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {

                    this.map[j, i, 0] += (float)(deltatime * (float)(this.rand.Next() % 3));
                    this.map[j, i, 1] += (float)(deltatime * (float)(this.rand.Next() % 5));
                    this.map[j, i, 2] += (float)(deltatime * (float)(this.rand.Next() % 4));
                }
            }


            for (int i = 0; i < this.mapSizeY; i++)
            {
                this.field.Y = i * this.fieldHeight;

                for (int j = 0; j < this.mapSizeX; j++)
                {
                    this.field.X = j * this.fieldWidth;
                    
                    this.brush.Color = Color.FromArgb((byte)(((this.map[j, i, 0] % 255) - (((int)this.map[j, i, 0] / 255) % 2)*(this.map[j, i, 0] % 255)) + (255 - (this.map[j, i, 0] % 255))*(((int)this.map[j, i, 0] / 255) % 2)),
                        (byte)(((this.map[j, i, 1] % 255) - (((int)this.map[j, i, 1] / 255) % 2) * (this.map[j, i, 1] % 255)) + (255 - (this.map[j, i, 1] % 255)) * (((int)this.map[j, i, 1] / 255) % 2)),
                        (byte)(((this.map[j, i, 2] % 255) - (((int)this.map[j, i, 2] / 255) % 2) * (this.map[j, i, 2] % 255)) + (255 - (this.map[j, i, 2] % 255)) * (((int)this.map[j, i, 2] / 255) % 2)));
                        
                    this.grafika.FillRectangle(this.brush, this.field);
                }
            }

        }



    }
}
