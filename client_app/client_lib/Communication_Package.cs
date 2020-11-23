using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace client_lib
{
    class Communication_Package
    {/*
            PING,
            CHOOSE,
            LOGIN,
            LOGIN_CONFIRM,
            LOGIN_REFUSE,
            SIGNUP,
            SIGNUP_CONFIRM,
            SIGNUP_REFUSE,
            GLOBAL_MESSAGE,
            QUIT_SERVER,
            QUIT_LOBBY,
            QUIT_GAME*/

        public String dataString;
        public byte[] data;

        #region constructors
        public Communication_Package(byte[] data)
        {
           this.data = data;
           this.dataString = BitConverter.ToString(this.data);
        }
        #endregion
        #region noargs
        public void SetTypePING()
        {
            this.dataString = "<type>PING</type>";
        }

        public void SetTypeQUIT_SERVER()
        {
            this.dataString = "<type>QUIT_SERVER</type>";
        }

        public void SetTypeQUIT_LOBBY()
        {
            this.dataString = "<type>QUIT_LOBBY</type>";
        }

        public void SetTypeQUIT_GAME()
        {
            this.dataString = "<type>QUIT_GAME</type>";
        }
        #endregion
        #region multipleargs
        public void SetTypeCHOOSE(int id)
        {
            this.dataString = "<type>CHOOSE</type><arg1>"+ id.ToString() +"</arg1>";
        }

        public void SetTypeLOGIN(String username, String password)
        {
            this.dataString = "<type>LOGIN</type><arg1>" + username + "</arg1><arg2>" + password + "</arg2>";
        }

        public void SetTypeLOGIN_CONFIRM(String username)
        {
            this.dataString = "<type>LOGIN_CONFIRM</type><arg1>"+ username +"</arg1>";
        }

        public void SetTypeLOGIN_REFUSE(String username, String reason)
        {
            this.dataString = "<type>LOGIN_REFUSE</type><arg1>"+ username +"</arg1><arg2>"+ reason +"</arg2>";
        }

        public void SetTypeSIGNUP(String username, String password)
        {
            this.dataString = "<type>SIGNUP</type><arg1>"+ username + "</arg1><arg2>"+ password +"</arg2>";
        }

        public void SetTypeSIGNUP_CONFIRM(String username)
        {
            this.dataString = "<type>SIGNUP_CONFIRM</type><arg1>"+ username +"</arg1>";
        }
        public void SetTypeSIGNUP_REFUSE(String username, String reason)
        {
            this.dataString = "<type>SIGNUP_REFUSE</type><arg1>"+ username +"</arg1><arg2>"+ reason +"</arg2>";
        }
        public void SetTypeGLOBAL_MESSAGE(int senderId, String senderUsername, String message)
        {
            this.dataString = "<type>GLOBAL_MESSAGE</type><arg1>"+ senderId.ToString() + "</arg1><arg2>" + senderUsername + "</arg2><arg3>" + message + "</arg3>";
        }
        #endregion
        public byte[] ToByteArray()
        {
            byte[] result = Encoding.ASCII.GetBytes(dataString);
            this.data = result;
            return result;
        }

        public String toString()
        {
            String result = BitConverter.ToString(data);
            return result;
        }
    }
}
