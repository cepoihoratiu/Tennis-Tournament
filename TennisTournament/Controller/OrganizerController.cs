using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TennisTournament.Model.Entities;
using TennisTournament.Model.Repository;
using TennisTournament.View;

namespace TennisTournament.Controller
{
    public class OrganizerController
    {
        private OrganizerRepository organizerRepository = new OrganizerRepository();
        private RefereeRepository refereeRepository = new RefereeRepository();
        private FixtureRepository fixtureRepository = new FixtureRepository();
        private UserRepository userRepository = new UserRepository();
        private TennisPlayerRepository tennisPlayerRepository = new TennisPlayerRepository();
        private Organizer organizer;
        private int userId;
        private int fixtureId;

        public OrganizerController(int userId)
        {
            this.userId = userId;
            this.organizer = new Organizer();
            var organizerEntity = organizerRepository.GetOrganizer(userId);
            PopulateFields(organizerEntity);
            PopulateDataGridView();
            this.organizer.GetUpdateOrganizerButton().Click += new EventHandler(UpdateOrganizer);
            this.organizer.GetDeleteOrganizerButton().Click += new EventHandler(DeleteOrganizer);
            this.organizer.GetLogoutButton().Click += new EventHandler(LogoutUser);

            this.organizer.GetUpdateFixtureButton().Click += new EventHandler(UpdateFixture);
            this.organizer.GetDeleteFixtureButton().Click += new EventHandler(DeleteFixture);
            this.organizer.GetAddFixtureButton().Click += new EventHandler(AddFixture);

            this.organizer.GetFixtureDataGridViewList().CellDoubleClick += new DataGridViewCellEventHandler(SelectedMatch);
        }
        private void PopulateFields(OrganizerEntity organizerEntity)
        {
            Console.WriteLine(organizerEntity.Name + " " + organizerEntity.Surname + " " + organizerEntity.Nationality);
            this.organizer.GetOrganizerName().Text = organizerEntity.Name;
            this.organizer.GetOrganizerSurName().Text = organizerEntity.Surname;
            for (int i = 0; i < this.organizer.GetOrganizerNationality().Items.Count; i++)
            {
                if (this.organizer.GetOrganizerNationality().Items[i].Equals(organizerEntity.Nationality))
                {
                    this.organizer.GetOrganizerNationality().SelectedIndex = i;
                    break;
                }
            }
        }

        public Organizer ViewOrganizer()
        {
            return this.organizer;
        }

        public void LogoutUser(object sender, EventArgs e)
        {
            this.organizer.Hide();
            LoginController loginController = new LoginController();
            loginController.LoginControllerView().Show();
        }

        public void UpdateOrganizer(object sender, EventArgs e)
        {
            if (organizerRepository.UpdateOrganizer(userId, this.organizer.GetOrganizerName().Text, this.organizer.GetOrganizerSurName().Text, this.organizer.GetOrganizerNationality().SelectedItem.ToString()))
            {
                MessageBox.Show("Organizer updated successfully!");
            }
            else
            {
                MessageBox.Show("Failed to update organizer.");
            }
        }

        public void DeleteOrganizer(object sender, EventArgs e)
        {
            if (organizerRepository.DeleteOrganizer(userId))
            {
                userRepository.DeleteUserById(userId);
                MessageBox.Show("Organizer deleted successfully!");
                this.organizer.Hide();
                LoginController loginController = new LoginController();
                loginController.LoginControllerView().Show();
            }
            else
            {
                MessageBox.Show("Failed to delete organizer.");
            }
        }

        private void PopulateDataGridView()
        {
            var dataTable = GetAllFixtures();
            this.organizer.GetFixtureDataGridViewList().DataSource = dataTable;
        }
        public DataTable GetAllFixtures()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("fixtureId", typeof(int));
            dataTable.Columns.Add("startTime", typeof(string));
            dataTable.Columns.Add("Player1", typeof(string));
            dataTable.Columns.Add("Player1_ID", typeof(int));
            dataTable.Columns.Add("Player2", typeof(string));
            dataTable.Columns.Add("Player2_ID", typeof(int));
            dataTable.Columns.Add("Referee", typeof(string));
            dataTable.Columns.Add("Referee_ID", typeof(int));
            dataTable.Columns.Add("Score", typeof(string));

            var matches = fixtureRepository.GetAllFixtures();

            foreach (var match in matches)
            {
                var row = dataTable.NewRow();
                row["fixtureId"] = match.Id;
                row["startTime"] = match.StartTime;
                row["Player1"] = GetPlayerName(match.FirstPlayerId);
                row["Player1_ID"] = match.FirstPlayerId;
                row["Player2"] = GetPlayerName(match.SecondPlayerId);
                row["Player2_ID"] = match.SecondPlayerId;
                row["Referee"] = GetRefereeName(match.RefereeId);
                row["Referee_ID"] = match.RefereeId;
                row["Score"] = match.Score;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private string GetPlayerName(int playerId)
        {
            var player = tennisPlayerRepository.GetTennisPlayerById(playerId);
            return player != null ? player.Name : "no name";
        }

        private string GetRefereeName(int refereeId)
        {
            var referee = refereeRepository.GetRefereeById(refereeId);
            return referee != null ? referee.Name : "no name";
        }

        private void SelectedMatch(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.organizer.GetFixtureDataGridViewList().Rows[e.RowIndex];
                fixtureId = Convert.ToInt32(row.Cells["fixtureId"].Value);
                this.organizer.GetTime().Text = row.Cells["startTime"].Value.ToString();
                this.organizer.GetPlayerOneId().Text = row.Cells["Player1_ID"].Value.ToString();
                this.organizer.GetPlayerTwoId().Text = row.Cells["Player2_ID"].Value.ToString();
                this.organizer.GetRefereeId().Text = row.Cells["Referee_ID"].Value.ToString();
                this.organizer.GetScore().Text = row.Cells["Score"].Value.ToString();
            }
        }

        public void AddFixture(object sender, EventArgs e)
        {
            if (fixtureRepository.AddFixture(this.organizer.GetTime().Text, int.Parse(this.organizer.GetPlayerOneId().Text), int.Parse(this.organizer.GetPlayerTwoId().Text), int.Parse(this.organizer.GetRefereeId().Text), this.organizer.GetScore().Text))
            {
                PopulateDataGridView();
                MessageBox.Show("Match added successfully!");
            }
            else
            {
                MessageBox.Show("Failed to add match.");
            }
        }

        public void UpdateFixture(object sender, EventArgs e)
        {
            if (fixtureRepository.UpdateFixture(fixtureId, this.organizer.GetTime().Text, int.Parse(this.organizer.GetPlayerOneId().Text), int.Parse(this.organizer.GetPlayerTwoId().Text), int.Parse(this.organizer.GetRefereeId().Text), this.organizer.GetScore().Text))
            {
                PopulateDataGridView();
                MessageBox.Show("Match updated successfully!");
            }
            else
            {
                MessageBox.Show("Failed to update match.");
            }
        }

        public void DeleteFixture(object sender, EventArgs e)
        {
            if (fixtureRepository.DeleteFixture(fixtureId))
            {
                PopulateDataGridView();
                MessageBox.Show("Match deleted successfully!");
            }
            else
            {
                MessageBox.Show("Failed to delete match.");
            }
        }
    }
}
