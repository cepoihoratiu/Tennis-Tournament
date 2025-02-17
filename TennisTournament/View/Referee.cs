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
    public partial class Referee : Form
    {
        public Referee()
        {
            InitializeComponent();
            PopulateComboBox();
        }


        public TextBox GetRefereeName()
        {
            return this.nameTxtBox;
        }

        public TextBox GetRefereeSurName()
        {
            return this.surnameTxtBox;
        }

        public ComboBox GetRefereeNationality()
        {
            return this.nationalityComboBox;
        }

        public Button GetUpdateRefereeButton()
        {
            return this.updateRefereeBtn;
        }

        public Button GetDeleteRefereeButton()
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

        private void updateRefereeBtn_Click(object sender, EventArgs e)
        {
            //string name = nameTxtBox.Text;
            //string surname = surnameTxtBox.Text;
            //string nationality = nationalityComboBox.SelectedItem.ToString();
            //refereeController.UpdateReferee(userId, name, surname, nationality);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //string message = refereeController.DeleteReferee(userId);
            //MessageBox.Show(message);
            //if (message.StartsWith("Referee deleted"))
            //{
            //    Login loginForm = new Login();
            //    loginForm.Show();
            //    this.Hide();
            //}
        }

        private void PopulateFields(RefereeEntity refereeEntity)
        {
            //Console.WriteLine(refereeEntity.Name + " " + refereeEntity.Surname + " " + refereeEntity.Nationality);
            //nameTxtBox.Text = refereeEntity.Name;
            //surnameTxtBox.Text = refereeEntity.Surname;
            //for (int i = 0; i < nationalityComboBox.Items.Count; i++)
            //{
            //    if (nationalityComboBox.Items[i].Equals(refereeEntity.Nationality))
            //    {
            //        nationalityComboBox.SelectedIndex = i;
            //        break;
            //    }
            //}
        }

        private void PopulateDataGridView(int userId)
        {
            //var dataTable = refereeController.GetFixturesAsReferee(userId);
            //dataGridViewFixture.DataSource = dataTable;
        }

    }
}
