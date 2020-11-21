using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client_lib
{
    abstract class Game
    {
        public Game(NetworkStream stream)
        {
            this.stream = stream;
        }

        private NetworkStream stream;
        public abstract void Run();


    }
}
