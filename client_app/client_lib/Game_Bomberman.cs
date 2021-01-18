using client_lib;
using packages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using Collision2d;
using System.Windows;
using System.Runtime.InteropServices;
using System.Diagnostics;

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
        private List<Bomberman_Bomb> bombs;
        private List<Blow_Up> blow_Ups;

        private Collision collisionCollection;
        private CollisionParser colisionParser;

        //tests
        public Vector[,] colSects;
        

        public Game_Bomberman(NetworkStream stream, int width, int height, int mapSizeX, int mapSizeY) : base(stream, width, height)
        {
            this.mapSizeX = mapSizeX;
            this.mapSizeY = mapSizeY;
            this.outQueue = new List<Package>();

            this.fieldWidth = (float)this.width / (float)this.mapSizeX;
            this.fieldHeight = (float)this.height / (float)this.mapSizeY;


            this.field = new RectangleF(0, 0, (int)this.fieldWidth, (int)this.fieldHeight);

            this.map = new byte[mapSizeX, mapSizeY];
            this.InitializeCollisionAssets();

            this.bombs = new List<Bomberman_Bomb>();
            this.blow_Ups = new List<Blow_Up>();

        }

        private void InitializeCollisionAssets()
        {
            this.collisionCollection = new Collision();

            this.colisionParser = new CollisionParser();
            //TEST

            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    this.map[j, i] = 0;
                }
            }
            Vector temPosition = new Vector();

            for (int i = 0; i < mapSizeY; i++)
            {
                this.map[0, i] = 1;
                this.map[i, 0] = 1;
                this.map[mapSizeX-1, i] = 1;
                this.map[i, mapSizeY-1] = 1;

            }

            for (int i = 2; i < mapSizeY-2; i++)
            {
                temPosition.Y = i;
                for (int j = 2; j < mapSizeX-2; j++)
                {
                    temPosition.X = j ;

                    if ((i % 2 == 0) && (j % 2 == 0))
                    {
                        this.map[i, j] = 2;
                    }

                    

                }
            }


            for (int i = 0; i < mapSizeY; i++)
            {
                temPosition.Y = i;
                for (int j = 0; j < mapSizeX; j++)
                {
                    temPosition.X = j;
                    
                    if (map[j, i] == 2 || map[j, i] == 1)
                        collisionCollection.addGroup("blokX:" + j + "Y:" + i, this.colisionParser.ParseRectangle(temPosition, 1));

                }
            }

            this.colSects = this.collisionCollection.giveMeSections();



        }

        //TEST
        public Game_Bomberman(int width, int height, int mapSizeX, int mapSizeY) : base(width, height)
        {
            this.mapSizeX = mapSizeX;
            this.mapSizeY = mapSizeY;
            this.outQueue = new List<Package>();

            this.fieldWidth = (float)this.width / (float)this.mapSizeX;
            this.fieldHeight = (float)this.height / (float)this.mapSizeY;

            this.field = new RectangleF(0, 0, (int)this.fieldWidth, (int)this.fieldHeight);

            this.map = new byte[mapSizeX, mapSizeY];
            this.players = new List<Player_Bomberman>();
            this.players.Add(new Player_Bomberman(1.5f, 1.5f));

            this.InitializeCollisionAssets();
            //TEST
        }

        /// <summary>
        /// przyjmuje inputy i aktualizuje działanie gry
        /// </summary>
        public override void update(Dictionary<string, bool> buttons, float deltatime)
        {
            if (!this.gameStarted) return;
            

            players[0].update(deltatime/1000, buttons, collisionCollection);

            if (buttons["Space"])
            {
                if(players[0].ready_to_place_bomb())
                {
                    //place bomb
                    Bomberman_Package package = new Bomberman_Package();
                    package.SetTypePLACE_BOMB((int)players[0].posX, (int)players[0].posY, 4000);
                    this.outQueue.Add(package);
                }
            }



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
                    this.setBomb(id, x, y);
                }
                else if (packageType == "BOMB_EXPLOSION")
                {
                    int id = Int32.Parse(args[1]);
                    int x = Int32.Parse(args[2]);
                    int y = Int32.Parse(args[3]);
                    int range = Int32.Parse(args[4]);
                    this.detonate(id,x,y,range);
                }
                /*else if (packageType == "DESTROY_WALL")
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
                }*/
                else if (packageType == "DEAD")
                {
                    int id = Int32.Parse(args[1]);
                    this.killPlayer(id);
                }
                else
                {
                    Console.WriteLine("---ERROR--- GOT PACKAGE " + packageType);
                }

                for(int i =0;i<this.blow_Ups.Count;i++)
                {
                    if(blow_Ups[i].ready_to_die())
                    {
                        this.blow_Ups.RemoveAt(i);
                        break;
                    }
                }
            }
           

        }

        void setBomb(int id, int x, int y)
        {
            this.bombs.Add(new Bomberman_Bomb(id, x, y));
        }

        void detonate(int bomb_id,int x, int y, int range)
        {
            this.bombs.RemoveAll(i => i.id == bomb_id);
            this.blow_Ups.Add(new Blow_Up((float)x, (float)y, (float)range));
        }

        void setPlayerPosition(int id, float x, float y)
        {
            Player_Bomberman p = this.players.Find(player => player.id == id);
            if (p == null) { return; }

            if (p.alive == true)
            { 
                this.players.Find(player => player.id == id).SetPosition(x, y); 
            }
            else 
            { 
                this.players.Find(player => player.id == id).SetPosition(-10000, -10000); 
            }
        }

        public override List<Package> getPackages()
        {
            List<Package> package_list = new List<Package>();
            foreach (Package p in this.outQueue)
            {
                package_list.Add(p);
            }
            this.outQueue = new List<Package>();


            Bomberman_Package temp = new Bomberman_Package();
            temp.SetTypePLAYER_POSITION(this.playerId,players[0].posX, players[0].posY);

            //Debug.WriteLine(players[0].posX.ToString() + " " + players[0].posY.ToString());

            package_list.Add(temp.asPackage());
            return package_list;
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
                            this.brush.Color = Color.Blue;
                            break;
                        case 1:
                            this.brush.Color = Color.Black;
                            break;
                        case 2:
                            this.brush.Color = Color.Green;
                            break;
                        default:
                            this.brush.Color = Color.Blue;
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
            this.pen.Color = Color.White;
            this.pen.Width = 3;
            for (int i = 0; i < this.colSects.Length/2; i++)
            {
                this.grafika.DrawLine(this.pen, new PointF((float)(this.colSects[i, 0].X*this.fieldWidth), (float)(this.colSects[i, 0].Y * this.fieldWidth)), 
                    new PointF((float)(this.colSects[i, 1].X * this.fieldWidth), (float)(this.colSects[i, 1].Y * this.fieldWidth)));
            }

            this.brush.Color = Color.Yellow;
            foreach (Blow_Up blow in this.blow_Ups)
            {
                this.grafika.FillEllipse(this.brush, blow.x * this.fieldWidth, blow.y * this.fieldWidth, this.fieldWidth, this.fieldWidth);
            }

            this.brush.Color = Color.Black;
            foreach (Bomberman_Bomb bomb in this.bombs)
            {
                this.grafika.FillEllipse(this.brush, (bomb.x + 0.2f) * this.fieldWidth, (bomb.y + 0.2f) * this.fieldWidth, this.fieldWidth*0.6f, this.fieldWidth * 0.6f);
            }







            //this.grafika.DrawLine(this.pen, new PointF(0, 0), new PointF(100, 100));

        }

        public override string ToString()
        {
            return "Player: " + this.players[0].ToString();
        }

        public void killPlayer(int id)
        {

        }
    }
}
