using client_lib;
using packages;
using System;
using System.Collections;
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
        //private PointF playerPosition = new PointF(10f, 10f);

        /// <summary>
        /// Wymiary w pixelach
        /// </summary>
        private float fieldWidth;
        private float fieldHeight;
        private List<Package> outQueue;
        private int playerId=0;
        private bool gameStarted = false;

        public int mapSizeX;
        public int mapSizeY;
        
        public byte[,] map;

        private List<Player_Bomberman> players;
        

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
            this.players = new List<Player_Bomberman>();
            this.players.Add(new Player_Bomberman(10f, 10f));

            //TEST
        }

        /// <summary>
        /// przyjmuje inputy i aktualizuje działanie gry
        /// </summary>
        public override void update(Dictionary<string, bool> buttons, float deltatime)
        {
            if (!this.gameStarted) return;
            Random rand = new Random();
            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    if ((i + j)%2 == 0) map[j, i] = 2;
                    else map[j, i] = 1;
                }
            }

            players[0].update(deltatime/1000, buttons);



            /*if (buttons["W"] == true)
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
            }*/

            this.generateBitmap();
        }


        /// <summary>
        /// przetwarza pakiety z serwera
        /// </summary>
        public override void process(Queue q)
        {
            String packageType = "";

            while(q.Count >0)
            {
                
                Package p = (Package) q.Dequeue();
                List<String> args = p.getArguments();
                if (args.Count == 0) continue;                    
                packageType = args[0];
                if (packageType == "START")
                {
                    this.gameStarted = true;
                }
                else if (packageType == "MAP_ID")
                {
                    int mapId = Int32.Parse(args[1]);
                    //this.changeMap(id)
                }
                else if (packageType == "SET_PLAYER_ID")
                {
                    int id = Int32.Parse(args[1]);
                    String name = args[2];
                    this.players.Add(new Player_Bomberman(id,name));
                }
                else if (packageType == "ASSIGN_ID")//gracz dostaje swoje nowe id
                {
                    players[0].id = Int32.Parse(args[1]);
                }
                else if (packageType == "PLAYER_POSITION")
                {
                    int id = Int32.Parse(args[1]);
                    float x = float.Parse(args[2]);
                    float y = float.Parse(args[3]);
                    this.setPlayerPosition(id, x, y);
                }
                else if (packageType == "BOMB_POSITION")
                {
                    int id = Int32.Parse(args[1]);
                    int x = Int32.Parse(args[2]);
                    int y = Int32.Parse(args[3]);
                    //this.setBomb(id,x,y)
                }
                else if (packageType == "DESTROY_WALL")
                {
                    int x = Int32.Parse(args[1]);
                    int y = Int32.Parse(args[2]);
                    //this.destroyWall(x,y)
                }
                else if (packageType == "DAMAGE_WALL")
                {
                    int x = Int32.Parse(args[1]);
                    int y = Int32.Parse(args[2]);
                    int hpLeft = Int32.Parse(args[3]);
                    //this.damageWall(x,y,hpLeft)
                }
                else if (packageType == "DEAD")
                {
                    int id = Int32.Parse(args[1]);
                    //this.killPlayer(id)
                }
                else
                {
                    Console.WriteLine("---ERROR--- GOT PACKAGE " + packageType);
                }
            }
           

        }

        void setPlayerPosition(int id, float x, float y)
        {
            this.players.Find(player => player.id == id).SetPosition(x, y);
        }

        public override List<Package> getPackages()
        {
            Bomberman_Package temp = new Bomberman_Package();
            temp.SetTypePLAYER_POSITION(this.playerId,players[0].posX, players[0].posY);
            return this.outQueue;
        }

        public override void scale(int width, int height)
        {
            this.width = width;
            this.height = height;

            this.bitmap = new Bitmap(this.width, this.height);
            this.grafika = Graphics.FromImage(bitmap);

            this.fieldWidth = (float)this.width / (float)this.mapSizeX;
            this.fieldHeight = (float)this.height / (float)this.mapSizeY;

            this.field = new RectangleF(0, 0, (int)this.fieldWidth, (int)this.fieldHeight);

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
            foreach (Player_Bomberman player in players)
            {
                this.field.X = player.posX * this.fieldWidth;
                this.field.Y = player.posY * this.fieldHeight;
                this.grafika.FillRectangle(this.brush, this.field);
            }

            
            
        }

        public override string ToString()
        {
            return "Player: " + this.players[0].ToString();
        }
    }
}
