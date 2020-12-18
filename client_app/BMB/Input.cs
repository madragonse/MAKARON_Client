using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMB
{
    public class Input
    {

        public Dictionary<string, bool> buttons = new Dictionary<string, bool>();



        public Input()
        {
            this.buttons.Add("W", false);
            this.buttons.Add("S", false);
            this.buttons.Add("A", false);
            this.buttons.Add("D", false);



        }

        public Input(Input toCopy)
        {
            foreach (var button in toCopy.buttons)
            {
                this.buttons.Add(button.Key, button.Value);
            }
        }




    }
}
