using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTournament.Model.Entities
{
    public class FixtureEntity
    {
        private int id;
        private string startTime;
        private int firstPlayerId;
        private int secondPlayerId;
        private int refereeId;
        private string score;
        public FixtureEntity()
        {
            this.id = 0;
            this.startTime = "";
            this.firstPlayerId = 0;
            this.secondPlayerId = 0;
            this.refereeId = 0;
            this.score = "";
        }

        public FixtureEntity(int id, string startTime, int firstPlayerId, int secondPlayerId, int refereeId, string score)
        {
            this.id = id;
            this.startTime = startTime;
            this.firstPlayerId = firstPlayerId;
            this.secondPlayerId = secondPlayerId;
            this.refereeId = refereeId;
            this.score = score;
        }

        public FixtureEntity(FixtureEntity fixture)
        {
            this.id= fixture.id;
            this.startTime = fixture.startTime;
            this.firstPlayerId = fixture.firstPlayerId;
            this.secondPlayerId = fixture.secondPlayerId;
            this.refereeId = fixture.refereeId;
            this.score = fixture.score;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string StartTime
        {
            get { return this.startTime; }
            set { this.startTime = value; }
        }

        public int FirstPlayerId
        {
            get { return this.firstPlayerId; }
            set { this.firstPlayerId = value; }
        }

        public int SecondPlayerId
        {
            get { return this.secondPlayerId; }
            set { this.secondPlayerId = value; }
        }

        public int RefereeId
        {
            get { return this.refereeId; }
            set { this.refereeId = value; }
        }

        public string Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        public override string ToString()
        {
            string s = "Start time: " + this.startTime;
            s += ", first player id: " + this.firstPlayerId;
            s += ", second player id: " + this.secondPlayerId;
            s += ", referee id: " + this.refereeId;
            s += ", score: " + this.score;
            return s;
        }
    }
}
