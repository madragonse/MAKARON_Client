using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        private byte[] data;

        public void SetTypePING()
        {
            this.type = Communication_Package.Types.PING;
        }

        public void SetTypeQUIT_SERVER()
        {
            this.type = Communication_Package.Types.QUIT_SERVER;
        }

        public void SetTypeQUIT_LOBBY()
        {
            this.type = Communication_Package.Types.QUIT_LOBBY;
        }

        public void SetTypeQUIT_GAME()
        {
            this.type = Communication_Package.Types.QUIT_GAME;
        }


        public byte[] ToByteArray()
        {
            List<Byte> data = new List<byte>();
            byte[] vs = BitConverter.GetBytes((ushort)this.type);

            data.AddRange(vs);
            byte[] result = data.ToArray();
            return result;
        }
        public static void interpet(byte[] data)
        {
            String stringData = Encoding.UTF8.GetString(data, 0, data.Length);
            String packageType = "";
            List<String> arguments = new List<String>();

            //parse into datatable
            DataTable dataTable = parseXMLIntoDataTable(stringData);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    arguments.Add((string)item);
                }
            }
            packageType = arguments[0];
            //delete type from arguments table
            arguments.RemoveAt(0);

            switch (packageType)
            {
                case "":
                    break;
                default:
                    break;
            }

        }

        private static DataTable parseXMLIntoDataTable(String dataString)
        {
            StringReader xmlStream = new StringReader(dataString);
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlStream);

            return dataSet.Tables[0];
        }
    }
}
