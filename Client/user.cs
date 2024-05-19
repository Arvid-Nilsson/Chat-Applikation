using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class user
    {
        private string _username;
        private string _pronouns;

        public string pronouns
        {
            get { return _pronouns; }
            set { _pronouns = value; }
        }
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string formatMessage(string message)
        {
            return $"({username} ({pronouns})) {message}";
        }
    }
}
 