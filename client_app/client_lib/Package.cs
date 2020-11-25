using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_lib
{
    public abstract class Package
    {
        public String XML;

        #region ctors
        public Package(byte[] data)
        {
            this.XML = BitConverter.ToString(data);
        }

        public Package() { }
        #endregion
        public byte[] ToByteArray()
        {
            byte[] result = Encoding.ASCII.GetBytes(XML);
            return result;
        }

        public String toString()
        {
            return XML;
        }

        public List<String> getArguments()
        {
            if (XML != null)
            {
                List<String> arguments = new List<String>();
                //parse into datatable
                DataTable dataTable = parseXMLIntoDataTable(XML);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        arguments.Add((string)item);
                    }
                }
                //delete type from arguments list
                return arguments;
            }
            else return new List<String>();
        }

        private DataTable parseXMLIntoDataTable(string xML)
        {
            throw new NotImplementedException();
        }
    }
}
