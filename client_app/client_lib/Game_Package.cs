using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_lib
{
    public class Game_Package : Package
    {
        /// <summary>
        /// Wysyłane przez serwer, informuje o zwycięstwie
        /// </summary>
        public void SetTypeVICTORY()
        {
            this.XML = "<PACKAGE>";
            this.XML += "<type>VICTORY</type>";
            this.XML += "</PACKAGE>";
        }
        /// <summary>
        /// Wysyłane przez serwer, informuje o przegranej
        /// </summary>
        public void SetTypeDEFEAT()
        {
            this.XML = "<PACKAGE>";
            this.XML += "<type>DEFEAT</type>";
            this.XML += "</PACKAGE>";
        }
        /// <summary>
        /// Wysyłane przez serwer, informuje o odłączeniu gracza
        /// </summary>
        /// <param name="id">id gracza</param>
        /// <param name="name">nick gracza</param>
        public void SetTypePLAYER_LEFT(int id, String name)
        {
            this.XML = "<PACKAGE>";
            this.XML += "<type>PLAYER_LEFT</type>";
            this.XML += "<arg1>" + id + "</arg1>";
            this.XML += "<arg2>" + name + "</arg2>";
            this.XML += "</PACKAGE>";
        }
    }
}
