using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace client_lib
{
    class Communication_Package
    {
        private enum Types : ushort
        {
            PING,
            QUIT_SERVER,
            QUIT_LOBBY,
            QUIT_GAME
        }
        Types type;
        public byte[] ToByteArray()
        {
            List<Byte> data = new List<byte>();
            byte[] vs = BitConverter.GetBytes((ushort)this.type);
            data.AddRange(vs);
            return new byte[1];
        }
    }
}
