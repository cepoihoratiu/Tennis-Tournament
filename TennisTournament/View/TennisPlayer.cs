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

    public partial class TennisPlayer : Form
    {
        public TennisPlayer()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        public TextBox GetTennisPlayerName()
        {
            return this.nameTxtBox;
        }

        public TextBox GetTennisPlayerSurName()
        {
            return this.surnameTxtBox;
        }

        public ComboBox GetTennisPlayerNationality()
        {
            return this.nationalityComboBox;
        }

        public Button GetUpdateTennisPlayerButton()
        {
            return this.updateTennisPlayerBtn;
        }

        public Button GetDeleteTennisPlayerButton()
        {
            return this.deleteBtn;
        }
        public Button GetLogoutButton()
        {
            return this.logoutBtn;
        }

        public DataGridView GetFixtureDataGridViewList()
        {
            return this.dataGridViewFixture;
        }

        private void PopulateComboBox()
        {
            nationalityComboBox.Items.Clear();
            nationalityComboBox.Items.AddRange(new object[] { "Albanian", "Romanian", "British" });
            nationalityComboBox.SelectedIndex = 0;
        }



        private void logoutBtn_Click(object sender, EventArgs e)
        {
            //Login loginForm = new Login();
            //loginForm.Show();
            //this.Hide();
        }

        private void updateTennisPlayerBtn_Click(object sender, EventArgs e)
        {
            //string name = nameTxtBox.Text;
            //string surname = surnameTxtBox.Text;
            //string nationality = nationalityComboBox.SelectedItem.ToString();
            //tennisPlayerController.UpdateTennisPlayer(userId, name, surname, nationality);
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //string message = tennisPlayerController.DeleteTennisPlayer(userId);
            //MessageBox.Show(message);
            //if (message.StartsWith("Tennis player deleted"))
            //{
            //    Login loginForm = new Login();
            //    loginForm.Show();
            //    this.Hide();
            //}
        }

        private void PopulateFields(TennisPlayerEntity tennisPlayer)
        {
            //    Console.WriteLine(tennisPlayer.Name + " " + tennisPlayer.Surname + " " + tennisPlayer.Nationality);
            //    nameTxtBox.Text = tennisPlayer.Name;
            //    surnameTxtBox.Text = tennisPlayer.Surname;
            //    for (int i = 0; i < nationalityComboBox.Items.Count; i++)
            //    {
            //        if (nationalityComboBox.Items[i].Equals(tennisPlayer.Nationality))
            //        {
            //            nationalityComboBox.SelectedIndex = i;
            //            break;
            //        }
            //    }
        }
        private void PopulateDataGridView(int userId)
        {
            //var dataTable = tennisPlayerController.GetFixtures(userId);
            //dataGridViewFixture.DataSource = dataTable;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void nationalityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void surnameTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewFixture_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
