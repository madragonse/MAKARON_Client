using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_lib
{
    class Bomberman_Bomb
    {
        public int id;
        public int x;
        public int y;
        public int range;
        public DateTime detonationTime;

        public Bomberman_Bomb(int id,int x, int y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
        }
    }
}
