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
    public class TennisPlayerController
    {
        private TennisPlayerRepository tennisPlayerRepository = new TennisPlayerRepository();
        private FixtureRepository fixtureRepository = new FixtureRepository();
        private RefereeRepository refereeRepository = new RefereeRepository();
        private UserRepository userRepository = new UserRepository();
        private TennisPlayer tennisPlayer;

        private int userId;
        public TennisPlayerController(int userId)
        {
            Console.WriteLine(userId + " in tennisplayer");

            this.userId = userId;
            this.tennisPlayer = new TennisPlayer();
            var tennisplayerEntity = tennisPlayerRepository.GetTennisPlayer(userId);
            PopulateFields(tennisplayerEntity);
            PopulateDataGridView();
            this.tennisPlayer.GetUpdateTennisPlayerButton().Click += new EventHandler(UpdateTennisPlayer);
            this.tennisPlayer.GetDeleteTennisPlayerButton().Click += new EventHandler(DeleteTennisPlayer);
            this.tennisPlayer.GetLogoutButton().Click += new EventHandler(LogoutUser);
        }

        public void LogoutUser(object sender, EventArgs e)
        {
            this.tennisPlayer.Hide();
            LoginController loginController = new LoginController();
            loginController.LoginControllerView().Show();
        }

        private void PopulateFields(TennisPlayerEntity tennisplayerEntity)
        {
            Console.WriteLine(tennisplayerEntity.Name + " " + tennisplayerEntity.Surname + " " + tennisplayerEntity.Nationality);
            this.tennisPlayer.GetTennisPlayerName().Text = tennisplayerEntity.Name;
            this.tennisPlayer.GetTennisPlayerSurName().Text = tennisplayerEntity.Surname;
            for (int i = 0; i < this.tennisPlayer.GetTennisPlayerNationality().Items.Count; i++)
            {
                if (this.tennisPlayer.GetTennisPlayerNationality().Items[i].Equals(tennisplayerEntity.Nationality))
                {
                    this.tennisPlayer.GetTennisPlayerNationality().SelectedIndex = i;
                    break;
                }
            }
        }

        public TennisPlayer ViewTennisPlayer()
        {
            return this.tennisPlayer;
        }

        public void UpdateTennisPlayer(object sender, EventArgs e)
        {
            if (tennisPlayerRepository.UpdateTennisPlayer(userId, this.tennisPlayer.GetTennisPlayerName().Text, this.tennisPlayer.GetTennisPlayerSurName().Text, this.tennisPlayer.GetTennisPlayerNationality().SelectedItem.ToString()))
            {
                MessageBox.Show("Tennis player updated successfully!");

            }
            else
            {
                MessageBox.Show("Failed to update tennis player.");
            }
        }

        public void DeleteTennisPlayer(object sender, EventArgs e)
        {
            var tennisPlayer = tennisPlayerRepository.GetTennisPlayer(userId);
            if (tennisPlayerRepository.DeleteTennisPlayer(userId))
            {
                userRepository.DeleteUserById(userId);
                fixtureRepository.DeleteFixtureWhereTennisPlayerIsFound(tennisPlayer.Id);
                MessageBox.Show("Tennis player deleted successfully!");
                this.tennisPlayer.Hide();
                LoginController loginController = new LoginController();
                loginController.LoginControllerView().Show();
            }
            else
            {
                MessageBox.Show("Failed to delete tennis player.");
            }
        }

        private void PopulateDataGridView()
        {
            var dataTable = GetFixtures();
            this.tennisPlayer.GetFixtureDataGridViewList().DataSource = dataTable;
        }

        public DataTable GetFixtures()
        {

            TennisPlayerEntity tennisPlayer = tennisPlayerRepository.GetTennisPlayer(userId);

            var matches = fixtureRepository.GetFixtures(tennisPlayer.Id);
            Console.WriteLine(matches.Count);
            var dataTable = new DataTable();
            dataTable.Columns.Add("startTime", typeof(string));
            dataTable.Columns.Add("Player", typeof(string));
            dataTable.Columns.Add("Opponent", typeof(string));
            dataTable.Columns.Add("Referee", typeof(string));
            dataTable.Columns.Add("Score", typeof(string));

            foreach (var match in matches)
            {
                var row = dataTable.NewRow();
                row["startTime"] = match.StartTime;
                row["Player"] = tennisPlayer.Name ?? "no name";
                if (match.SecondPlayerId.Equals(tennisPlayer.Id))
                {
                    row["Opponent"] = tennisPlayerRepository.GetTennisPlayerById(match.FirstPlayerId)?.Name ?? "no name";
                }
                else
                {
                    row["Opponent"] = tennisPlayerRepository.GetTennisPlayerById(match.SecondPlayerId)?.Name ?? "no name";
                }
                row["Referee"] = refereeRepository.GetRefereeById(match.RefereeId)?.Name ?? "no name";
                row["Score"] = match.Score;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
