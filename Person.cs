using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karpenko3
{
    public class Person
    {
        public string Login;
        public bool AuthStatus = false;
        public int Password;
        public int Power = 0;
        public Person(string Login, int Password)
        {
            this.Login = Login;
            this.Password = Password;
        }
    }
}
