using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Collision2d
{
    public class CollisionParser
    {

        public Vector[,] ParseRectangle(Vector corner, float len)
        {
            Vector[] corners = new Vector[4];
            Vector[,] ret = new Vector[4, 2];
            corners[0] = corner;
            corners[1] = new Vector(corner.X + len, corner.Y);
            corners[2] = new Vector(corner.X + len, corner.Y + len);
            corners[3] = new Vector(corner.X, corner.Y + len);

            ret[0, 0] = corners[0]; ret[0, 1] = corners[1];
            ret[1, 0] = corners[1]; ret[1, 1] = corners[2];
            ret[2, 0] = corners[2]; ret[2, 1] = corners[3];
            ret[3, 0] = corners[3]; ret[3, 1] = corners[0];



            return ret;
        }

    }
}
