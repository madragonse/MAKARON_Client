using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace client_lib
{
    class Blow_Up
    {
        public float x;
        public float y;
        public float range;
        public DateTime lifetime;
        public List<Tuple<float, float>> affected_fields;

        public Blow_Up(float x, float y, float range)
        {
            this.x = x;
            this.y = y;
            this.range = range;
            this.lifetime = DateTime.Now.AddMilliseconds(1500);
            this.calculate_affected_fields();
        }
        private void calculate_affected_fields()
        {
            this.affected_fields = new List<Tuple<float, float>>();

            for(int i = (int)(this.x - this.range); i <= (this.x + this.range); i++)
            {
                if (i < 1 || i > 13) continue;
                this.affected_fields.Add(new Tuple<float,float>(i,this.y));
            }
            for(int i = (int)(this.y - this.range); i <= (this.y+this.range);i++)
            {
                if (i < 1 || i > 13) continue;
                if (i == this.y) continue;
                this.affected_fields.Add(new Tuple<float, float>(this.x, i));
            }
        }

        public List<Tuple<float,float>> GetTuples()
        {
            return this.affected_fields;
        }

        public Boolean ready_to_die()
        {
            if (DateTime.Now.CompareTo(this.lifetime) >= 0) return true;
            else return false;
        }
    }
}
