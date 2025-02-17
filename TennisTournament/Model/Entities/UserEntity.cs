using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTournament.Model.Entities
{
    public class UserEntity
    {
        private string username;
        private string userType;
        private int id;

        public UserEntity()
        {
            this.username = "test";
            this.userType = "test";
            this.id = 1;
        }

        public UserEntity(string username, string userType, int id)
        {
            this.username = username;
            this.userType = userType;
            this.id = id;
        }

        public UserEntity(UserEntity userEntity)
        {
            this.username = userEntity.username;
            this.userType = userEntity.userType;
            this.id = userEntity.id;
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string UserType
        {
            get { return this.userType; }
            set { this.userType = value; }
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public override string ToString()
        {
            string s = "Name: " + this.username;
            s += " surname: " + this.userType;
            s += ", and id = " + this.id;
            return s;
        }
    }
}
