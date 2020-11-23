using client_lib;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;

namespace client_lib
{
    /// <summary>
    /// // TODO
    /// dodać nowe id
    /// 
    /// </summary>
    public class Game_Bomberman : Game
    {
        

        /// <summary>
        /// wybieranie pola na mapie
        /// </summary>
        private RectangleF field;

        /// <summary>
        /// Wymiary w pixelach
        /// </summary>
        private float fieldWidth;
        private float fieldHeight;
        

        public int mapSizeX;
        public int mapSizeY;
        
        public byte[,] map;
        

        public Game_Bomberman(NetworkStream stream, int width, int height, int mapSizeX, int mapSizeY) : base(stream, width, height)
        {
            this.mapSizeX = mapSizeX;
            this.mapSizeY = mapSizeY;

            this.fieldWidth = (float)this.width / (float)this.mapSizeX;
            this.fieldHeight = (float)this.height / (float)this.mapSizeY;


            this.field = new RectangleF(0, 0, (int)this.fieldWidth, (int)this.fieldHeight);

            this.map = new byte[mapSizeX, mapSizeY];

        }

        /// <summary>
        /// przyjmuje inputy i aktualizuje działanie gry
        /// </summary>
        public override void update(Dictionary<string, bool> buttons, float deltatime)
        {
            this.generateBitmap();

        }


        /// <summary>
        /// przetwarza pakiety z serwera
        /// </summary>
        public override void process()
        { 
            
        }

        /// <summary>
        /// Generowanie bitmapy na podstawie mapy gry [map]
        /// </summary>
        private void generateBitmap()
        {
            for (int i = 0; i < this.mapSizeY; i++)
            {
                this.field.Y = i * this.fieldHeight;

                for (int j = 0; j < this.mapSizeX; j++)
                {
                    this.field.X = j * this.fieldWidth;


                    if (this.map[j, i] == 0)
                    {
                        this.pen.Color = Color.Yellow;

                    }
                    else if(this.map[j, i] == 1)
                    {

                        this.pen.Color = Color.White;

                    }
                    else if (this.map[j, i] == 2)
                    {

                        this.pen.Color = Color.Red;

                    }

                    this.g.DrawEllipse(this.pen, this.field);


                }
            }

        }

    }
}
