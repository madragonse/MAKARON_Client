using client_lib;
using System;
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

        private PointF playerPosition = new PointF(0, 0);

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

            //TEST

            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    this.map[j, i] = 0;
                }
            }

        }

        //TEST
        public Game_Bomberman(int width, int height, int mapSizeX, int mapSizeY) : base(width, height)
        {
            this.mapSizeX = mapSizeX;
            this.mapSizeY = mapSizeY;

            this.fieldWidth = (float)this.width / (float)this.mapSizeX;
            this.fieldHeight = (float)this.height / (float)this.mapSizeY;

            this.field = new RectangleF(0, 0, (int)this.fieldWidth, (int)this.fieldHeight);

            this.map = new byte[mapSizeX, mapSizeY];

            //TEST
        }

        /// <summary>
        /// przyjmuje inputy i aktualizuje działanie gry
        /// </summary>
        public override void update(Dictionary<string, bool> buttons, float deltatime)
        {
            Random rand = new Random();
            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    if ((i + j)%2 == 0) map[j, i] = 2;
                    else map[j, i] = 1;
                }
            }

            if(buttons["W"] == true)
            {
                this.playerPosition.Y -= 0.01f*deltatime;
            }
            if (buttons["S"] == true)
            {
                this.playerPosition.Y += 0.01f * deltatime;
            }
            if (buttons["A"] == true)
            {
                this.playerPosition.X -= 0.01f * deltatime;
            }
            if (buttons["D"] == true)
            {
                this.playerPosition.X += 0.01f * deltatime;
            }

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

                    switch(map[j,i])
                    {
                        case 0:
                            this.brush.Color = Color.Yellow;
                            break;
                        case 1:
                            this.brush.Color = Color.White;
                            break;
                        case 2:
                            this.brush.Color = Color.Red;
                            break;
                        default:
                            this.brush.Color = Color.Yellow;
                            break;
                    }

                    this.grafika.FillRectangle(this.brush, this.field);                    
                }
            }
            this.brush.Color = Color.Black;
            this.field.X = playerPosition.X * this.fieldWidth;
            this.field.Y = playerPosition.Y * this.fieldHeight;
            this.grafika.FillRectangle(this.brush, this.field);
        }

    }
}
