using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karpenko3
{
    class Connection
    {
        private List<Person> Accounts = new List<Person>();
        public Person AuthorizedAcc;
        public Connection()
        {
            Accounts.Add(new Person("admin", 0) { Power = 15});
        }
        public bool Register(string login, string password)
        {
            var newPerson = new Person(login, Encrypt(password));
            if (FindByName(login) == null)
            {
                Accounts.Add(newPerson);
                AuthorizedAcc = newPerson;
                return true;
            }
            return false;

        }

        public bool Auth(string login, string password)
        {
            var encryptedPassword = Encrypt(password);
            Person currentAcc;
            if (FindByName(login) == null)
            {
                return false;
            }
            else
            {
                currentAcc = FindByName(login);
                if (currentAcc.Password == encryptedPassword)
                {
                    AuthorizedAcc = currentAcc;
                    return true;
                }
            }
            return false;

        }

        private int Encrypt(string password)
        {
            var encryptedPassword = 0;
            foreach (var item in password)
            {
                encryptedPassword += int.Parse(item.ToString());
            }
            return encryptedPassword;
        }

        private Person FindByName(string login)
        {
            foreach (var acc in Accounts)
            {
                if (acc.Login == login)
                {
                    return acc;
                }
            }
            return null;
        }

        public bool Delete(string login)
        {
            if (AuthorizedAcc.Power > 10 && FindByName(login) != AuthorizedAcc)
            {
                Accounts.Remove(FindByName(login));
                return true;
            }
            return false;
        }

        public bool SetLevel(string login, string power)
        {
            int toPower = 0;
            if (int.TryParse(power, out toPower) && toPower >= 0)
            {
                FindByName(login).Power = toPower;
                return true;
            }
            return false;

        }

        public Dictionary<string, int> ShowAccounts()
        {
            if (AuthorizedAcc.Power > 5)
            {
                var dict = new Dictionary<string, int>();
                foreach (var acc in Accounts)
                {
                    dict.Add(acc.Login, acc.Password);
                }
                return dict;
            }
            return null;
        }

    }
}
