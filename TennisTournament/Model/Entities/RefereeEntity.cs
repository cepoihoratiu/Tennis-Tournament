using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTournament.Model.Entities
{
    public class RefereeEntity
    {
        private int id;
        private string name;
        private string surname;
        private string nationality;

        public RefereeEntity()
        {
            this.id = 0;
            this.name = "Dan";
            this.surname = "Ionescu";
            this.nationality = "British";
        }

        public RefereeEntity(int id, string name, string surname, string nationality)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.nationality = nationality;
        }

        public RefereeEntity(RefereeEntity refereeEntity)
        {
            this.id = refereeEntity.id;
            this.name = refereeEntity.name;
            this.surname = refereeEntity.surname;
            this.nationality = refereeEntity.nationality;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Surname
        {
            get { return this.surname; }
            set { this.surname = value; }
        }

        public string Nationality
        {
            get { return this.nationality; }
            set { this.nationality = value; }
        }

        public override string ToString()
        {
            string s = "Id: " + this.id;
            s += " Name: " + this.name;
            s += " surname: " + this.surname;
            s += ", and nationality = " + this.nationality;
            return s;
        }
    }
}
