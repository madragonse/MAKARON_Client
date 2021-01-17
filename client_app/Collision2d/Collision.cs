using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Collision2d
{
    

    public class Collision
    {
        public struct Section
        {
            public Section(Vector start, Vector end)
            {
                this.a = start;
                this.b = end;

            }

            public double[] toLine()
            {
                double[] ret = new double[3];
                ret[0] = this.a.Y - this.b.Y;
                ret[1] = this.b.X - this.a.X;
                ret[2] = this.a.X * this.b.Y - this.b.X * this.a.Y;

                return ret;
            }

            public Vector toRatio()
            {
                Vector ret = new Vector();
                ret.X = this.b.X - this.a.X;
                ret.Y = this.b.Y - this.a.Y;
                return ret;
            }


            public Vector a;
            public Vector b;

        }

        public struct Group
        {


            public Group(String name, Vector[,] lines)
            {
                this.name = name;

                this.sections = new List<Section>();
                for (int i = 0; i < lines.Length/2; i++)
                {
                    this.sections.Add(new Section(lines[i, 0], lines[i, 1]));
                }

            }

            public Group(String name, Vector[] points)
            {
                this.name = name;

                this.sections = new List<Section>();
                this.sections.Add(new Section(points[points.Length - 1], points[0]));
                for (int i = 0; i < points.Length-1; i++)
                {
                    this.sections.Add(new Section(points[i], points[i+1]));
                }

            }

            public Vector linesIntersection(double[] a, double[] b)
            {
                Vector ret = new Vector();

                double mul = a[0] / b[0] * -1;

                b[0] *= mul; b[1] *= mul; b[2] *= mul;

                a[1] += b[1]; a[2] += b[2];

                ret.Y = a[2] / a[1] * -1;

                ret.X = ((b[1] * ret.Y) + b[2]) / b[0] * -1;

                return ret;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="check"></param>
            /// <returns>Returns Vector(0, 0) if do not intersects</returns>
            public Vector intersection(Section a, Section b)
            {
                double[] pa = a.toLine();
                double[] pb = b.toLine();

                Vector inte = this.linesIntersection(pa, pb);

                Vector ra = a.toRatio();
                Vector rb = b.toRatio();

                Vector rap = inte - a.a;
                Vector rbp = inte - b.a;

                if ((Math.Abs(rap.X) > Math.Abs(ra.X)) || (Math.Abs(rap.Y) > Math.Abs(ra.Y)) || (Math.Abs(rbp.X) > Math.Abs(rb.X)) || (Math.Abs(rbp.Y) > Math.Abs(rb.Y)))
                {
                    //Console.Out.WriteLine("Nie przecina się");
                    return new Vector(0, 0);
                }
                else
                {
                    //Console.Out.WriteLine("Przecina się");
                    return inte;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="check"></param>
            /// <returns>Returns Vector(0, 0) if fails in searching</returns>
            public Vector[] checkCollision(Section check)
            {
                Vector[] ret = new Vector[3];
                ret[0] = new Vector();
                ret[1] = new Vector();
                ret[2] = new Vector();

                foreach (Section section in this.sections)
                {
                    ret[0] = this.intersection(check, section);
                    if (ret[0].X != 0 && ret[0].Y != 0)
                    {
                        ret[1] = section.a;
                        ret[2] = section.b;
                        break;
                    }
                }

                return ret;
            }

            public String name;
            public List<Section> sections;

        }

        List<Group> groups;

        public Collision()
        {
            this.groups = new List<Group>();
        }

        public bool addGroup(String name, Vector[,] lines)
        {
            foreach (Group group in this.groups)
            {
                if (group.name == name)
                {
                    return false;
                }
            }
            this.groups.Add(new Group(name, lines));

            return true;
        }

        public bool addToGroup(String name, Vector[,] lines)
        {
            for (int i = 0; i < this.groups.Count; i++)
            {
                if (this.groups[i].name == name)
                {
                    for (int j = 0; j < lines.Length/2; j++)
                    {
                        this.groups[i].sections.Add(new Section(lines[i, 0], lines[i, 1]));
                    }
                    
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="check"></param>
        /// <returns>Returns Vector(0, 0) if fails in searching</returns>
        public Vector[] checkCollision(Section check)
        {
            Vector[] ret = new Vector[3];
            ret[0] = new Vector();
            ret[1] = new Vector();
            ret[2] = new Vector();

            foreach(Group group in this.groups)
            {
                ret = group.checkCollision(check);
                if (ret[0].X != 0 && ret[0].Y != 0)
                {
                    break;
                }

            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="check"></param>
        /// <param name="name">Return in this name of group with collision</param>
        /// <returns>Returns Vector(0, 0) if fails in searching</returns>
        public Vector[] checkCollision(Section check, String name)
        {
            Vector[] ret = new Vector[3];
            ret[0] = new Vector();
            ret[1] = new Vector();
            ret[2] = new Vector();

            foreach (Group group in this.groups)
            {
                ret = group.checkCollision(check);
                if (ret[0].X != 0 && ret[0].Y != 0)
                {
                    name = group.name;
                    break;
                }

            }

            return ret;
        }


        public Vector checkCollisionPosition(Vector moveA, Vector moveB)
        {
            Section move = new Section(moveA, moveB);
            Vector[] cross = this.checkCollision(move);
            if (cross[0].X == 0 && cross[0].Y == 0)
            {
                return moveB;
            }

            Vector q = moveB - moveA;
            Vector p = cross[2] - cross[1];
            Vector r = moveB - cross[0];
            Vector z = cross[2] - cross[0];
            Vector d = new Vector();
            double cosA = (Vector.Multiply(p, q)) / (p.Length * q.Length);

            d = r.Length * cosA * (z / z.Length);

            return this.checkCollisionPosition(cross[0], cross[0] + d);
        }

        public Vector[] checkCollisionAll(Vector moveA, Vector moveB, Vector acceleration, Vector speed)
        {
            Vector[] ret = new Vector[3];

            if (moveA == moveB)
            {
                ret[0] = moveB;

                ret[1] = acceleration;

                ret[2] = speed;

                return ret;
            }
            Section move = new Section(moveA, moveB);
            Vector[] cross = this.checkCollision(move);
            if (cross[0].X == 0 && cross[0].Y == 0)
            {
                return new Vector[3];
            }

            Vector q = moveB - moveA;
            Vector p = cross[2] - cross[1];
            Vector r = moveB - cross[0];
            Vector z = cross[2] - cross[0];
            Vector d = new Vector();
            double cosA = (Vector.Multiply(p, q)) / (p.Length * q.Length);

            d = r.Length * cosA * (z / z.Length);

            

            ret[0] = this.checkCollisionPosition(cross[0], cross[0] + d);

            ret[1] = acceleration.Length * cosA * (z / z.Length);

            ret[2] = speed.Length * cosA * (z / z.Length);

            return ret;
        }




    }
}
