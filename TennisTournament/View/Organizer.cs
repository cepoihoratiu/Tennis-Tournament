using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TennisTournament.Controller;
using TennisTournament.Model.Entities;
using TennisTournament.Model.Repository;

namespace TennisTournament.View
{
    public partial class Organizer : Form
    {

        public Organizer()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        //private void InitializeForm()
        //{
        //    PopulateComboBox();
        //    var organizerEntity = organizerController.GetOrganizer(userId);
        //    if (organizerEntity != null)
        //    {
        //        PopulateFields(organizerEntity);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Organizer is empty");
        //    }
        //    PopulateDataGridView();
        //}
        public TextBox GetOrganizerName()
        {
            return this.nameTxtBox;
        }

        public TextBox GetOrganizerSurName()
        {
            return this.surnameTxtBox;
        }

        public ComboBox GetOrganizerNationality()
        {
            return this.nationalityComboBox;
        }

        public Button GetUpdateOrganizerButton()
        {
            return this.updateOrganizerBtn;
        }

        public Button GetDeleteOrganizerButton()
        {
            return this.deleteBtn;
        }
        public Button GetLogoutButton()
        {
            return this.logoutBtn;
        }
        /// <summary>
        ///  fixtures
        public DataGridView GetFixtureDataGridViewList()
        {
            return this.dataGridViewFixture;
        }

        public Button GetUpdateFixtureButton()
        {
            return this.updateFixtureBtn;
        }

        public Button GetDeleteFixtureButton()
        {
            return this.deleteFixtureBtn;
        }

        public Button GetAddFixtureButton()
        {
            return this.addFixtureBtn;
        }

        public TextBox GetTime()
        {
            return this.startTimeTxtBox;
        }

        public TextBox GetPlayerOneId()
        {
            return this.player1TxtBox;
        }

        public TextBox GetPlayerTwoId()
        {
            return this.player2TxtBox;
        }

        public TextBox GetRefereeId()
        {
            return this.refereeIdTxtBox;
        }

        public TextBox GetScore()
        {
            return this.scoreTxtBox;
        }

        //
        private void PopulateComboBox()
        {
            nationalityComboBox.Items.Clear();
            nationalityComboBox.Items.AddRange(new object[] { "Albanian", "Romanian", "British" });
            nationalityComboBox.SelectedIndex = 0;
        }
        private void PopulateFields(OrganizerEntity organizerEntity)
        {
            Console.WriteLine(organizerEntity.Name + " " + organizerEntity.Surname + " " + organizerEntity.Nationality);
            nameTxtBox.Text = organizerEntity.Name;
            surnameTxtBox.Text = organizerEntity.Surname;
            for (int i = 0; i < nationalityComboBox.Items.Count; i++)
            {
                if (nationalityComboBox.Items[i].Equals(organizerEntity.Nationality))
                {
                    nationalityComboBox.SelectedIndex = i;
                    break;
                }
            }
        }











        private void logoutBtn_Click(object sender, EventArgs e)
        {
            //Login loginForm = new Login();
            //loginForm.Show();
            //this.Hide();
        }

        private void updateOrganizerBtn_Click(object sender, EventArgs e)
        {
            //string name = nameTxtBox.Text;
            //string surname = surnameTxtBox.Text;
            //string nationality = nationalityComboBox.SelectedItem.ToString();

            //organizerController.UpdateOrganizer(userId, name, surname, nationality);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //organizerController.DeleteOrganizer(userId);
            //Login loginForm = new Login();
            //loginForm.Show();
            //this.Hide();
        }

        private void PopulateDataGridView()
        {
            //var dataTable = organizerController.GetAllFixtures();
            //dataGridViewFixture.DataSource = dataTable;
        }

        private void dataGridViewFixture_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dataGridViewFixture.Rows[e.RowIndex];
            //    fixtureIdSelected = Convert.ToInt32(row.Cells["fixtureId"].Value);
            //    startTimeTxtBox.Text = row.Cells["startTime"].Value.ToString();
            //    player1TxtBox.Text = row.Cells["Player1_ID"].Value.ToString();
            //    player2TxtBox.Text = row.Cells["Player2_ID"].Value.ToString();
            //    refereeIdTxtBox.Text = row.Cells["Referee_ID"].Value.ToString();
            //    scoreTxtBox.Text = row.Cells["Score"].Value.ToString();
            //}
        }

        private void addFixtureBtn_Click(object sender, EventArgs e)
        {
            //string startTime = startTimeTxtBox.Text;
            //int firstPlayerId = int.Parse(player1TxtBox.Text);
            //int secondPlayerId = int.Parse(player2TxtBox.Text);
            //int refereeId = int.Parse(refereeIdTxtBox.Text);
            //string score = scoreTxtBox.Text;

            // organizerController.AddFixtureAndGetMessage(startTime, firstPlayerId, secondPlayerId, refereeId, score);
        }

        private void updateFixtureBtn_Click(object sender, EventArgs e)
        {
        //    string startTime = startTimeTxtBox.Text;
        //    int firstPlayerId = int.Parse(player1TxtBox.Text);
        //    int secondPlayerId = int.Parse(player2TxtBox.Text);
        //    int refereeId = int.Parse(refereeIdTxtBox.Text);
        //    string score = scoreTxtBox.Text;

        //    organizerController.UpdateFixtureAndGetMessage(fixtureIdSelected, startTime, firstPlayerId, secondPlayerId, refereeId, score);
        //
        }

        private void deleteFixtureBtn_Click(object sender, EventArgs e)
        {
            //organizerController.DeleteFixtureAndGetMessage(fixtureIdSelected);
            //PopulateDataGridView();

        }

        private void startTimeTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void player1TxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void player2TxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void scoreTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
