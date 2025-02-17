using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTournament.Model.Entities
{
    public class OrganizerEntity
    {
        private string name;
        private string surname;
        private string nationality;

        public OrganizerEntity()
        {
            this.name = "Dan";
            this.surname = "Ionescu";
            this.nationality = "British";
        }

        public OrganizerEntity(string name, string surname, string nationality)
        {
            this.name = name;
            this.surname = surname;
            this.nationality = nationality;
        }

        public OrganizerEntity(OrganizerEntity organizerEntity)
        {
            this.name = organizerEntity.name;
            this.surname = organizerEntity.surname;
            this.nationality = organizerEntity.nationality;
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
            string s = "Player name: " + this.name;
            s += " surname: " + this.surname;
            s += ", and nationality = " + this.nationality;
            return s;
        }
    }
}
