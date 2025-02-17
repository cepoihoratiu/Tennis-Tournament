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
    public class RefereeController
    {
        private RefereeRepository refereeRepository = new RefereeRepository();
        private FixtureRepository fixtureRepository = new FixtureRepository();
        private TennisPlayerRepository tennisPlayerRepository = new TennisPlayerRepository();
        private UserRepository userRepository = new UserRepository();
        private Referee referee;

        private int userId;
        public RefereeController(int userId)
        {
            Console.WriteLine(userId + " in referee");
            this.userId = userId;
            this.referee = new Referee();
            var refereeEntity = refereeRepository.GetReferee(userId);
            PopulateFields(refereeEntity);
            PopulateDataGridView();
            this.referee.GetUpdateRefereeButton().Click += new EventHandler(UpdateReferee);
            this.referee.GetDeleteRefereeButton().Click += new EventHandler(DeleteReferee);
            this.referee.GetLogoutButton().Click += new EventHandler(LogoutUser);
        }

        private void PopulateFields(RefereeEntity refereeEntity)
        {
            Console.WriteLine(refereeEntity.Name + " " + refereeEntity.Surname + " " + refereeEntity.Nationality);
            this.referee.GetRefereeName().Text = refereeEntity.Name;
            this.referee.GetRefereeSurName().Text = refereeEntity.Surname;
            for (int i = 0; i < this.referee.GetRefereeNationality().Items.Count; i++)
            {
                if (this.referee.GetRefereeNationality().Items[i].Equals(refereeEntity.Nationality))
                {
                    this.referee.GetRefereeNationality().SelectedIndex = i;
                    break;
                }
            }
        }

        public Referee ViewReferee()
        {
            return this.referee;
        }

        public void LogoutUser(object sender, EventArgs e)
        {
            this.referee.Hide();
            LoginController loginController = new LoginController();
            loginController.LoginControllerView().Show();
        }

        public void UpdateReferee(object sender, EventArgs e)
        {
            if (refereeRepository.UpdateReferee(userId, this.referee.GetRefereeName().Text, this.referee.GetRefereeSurName().Text, this.referee.GetRefereeNationality().SelectedItem.ToString()))
            {
                MessageBox.Show("Referee updated successfully!");
            }
            else
            {
                MessageBox.Show("Failed to update referee.");
            }
        }

        public void DeleteReferee(object sender, EventArgs e)
        {
            var referee = refereeRepository.GetReferee(userId);

            if (refereeRepository.DeleteReferee(userId))
            {
                userRepository.DeleteUserById(userId);
                fixtureRepository.DeleteFixtureWhereRefereeIsFound(referee.Id);
                MessageBox.Show("Referee deleted successfully!");
                this.referee.Hide();
                LoginController loginController = new LoginController();
                loginController.LoginControllerView().Show();
            }
            else
            {
                MessageBox.Show("Failed to delete referee.");
            }
        }

        private void PopulateDataGridView()
        {
            var dataTable = GetFixturesAsReferee();
            this.referee.GetFixtureDataGridViewList().DataSource = dataTable;
        }

        public DataTable GetFixturesAsReferee()
        {
            RefereeEntity referee = refereeRepository.GetReferee(userId);
            var matches = fixtureRepository.GetFixturesAsReferee(referee.Id);

            var dataTable = new DataTable();
            dataTable.Columns.Add("startTime", typeof(string));
            dataTable.Columns.Add("Player1", typeof(string));
            dataTable.Columns.Add("Player2", typeof(string));
            dataTable.Columns.Add("Referee", typeof(string));
            dataTable.Columns.Add("Score", typeof(string));

            foreach (var match in matches)
            {
                var row = dataTable.NewRow();
                row["startTime"] = match.StartTime;
                row["Player1"] = tennisPlayerRepository.GetTennisPlayerById(match.FirstPlayerId)?.Name ?? "no name";
                row["Player2"] = tennisPlayerRepository.GetTennisPlayerById(match.SecondPlayerId)?.Name ?? "no name";
                row["Referee"] = referee.Name ?? "no name";
                row["Score"] = match.Score;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
