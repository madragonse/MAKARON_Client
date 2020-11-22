using client_lib;
using System.Net.Sockets;

namespace client_lib
{
    class Game_Bomberman : Game
    {
        byte[][] map;

        public Game_Bomberman(NetworkStream stream) : base(stream)
        {
             
        }

        public override void Run()
        {

        }
    }
}
