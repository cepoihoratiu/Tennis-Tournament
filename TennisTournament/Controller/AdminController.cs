using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TennisTournament.Model.Entities;
using TennisTournament.Model.Repository;
using TennisTournament.Properties;
using TennisTournament.View;

namespace TennisTournament.Controller
{
    public class AdminController
    {
        private UserRepository userRepository;
        private UserEntity userEntity = new UserEntity();
        private Admin admin;
        public AdminController()
        {
            this.admin = new Admin();
            this.userRepository = new UserRepository();
            LoadUsers();
            this.admin.GetUpdateButton().Click += new EventHandler(UpdatePassword);
            this.admin.GetDeleteButton().Click += new EventHandler(DeleteUser);
            this.admin.GetLogoutButton().Click += new EventHandler(LogoutUser);
        }

        public Admin ViewAdmin()
        {
            return this.admin;
        }

        public void LoadUsers()
        {
            this.admin.GetUsersList().Rows.Clear();
            List<UserEntity> userList = userRepository.getAllUsers();
            foreach (UserEntity user in userList)
            {
                this.admin.GetUsersList().Rows.Add(user.Id, user.UserType, user.Username);
            }
        }

        public void UpdatePassword(object sender, EventArgs e)
        {
            string updatedPassword = this.admin.GetNewPasasword().Text;
            if ((this.admin.GetUsersList().SelectedRows.Count > 0))
            {
                DataGridViewRow row = (this.admin.GetUsersList().SelectedRows[0]);
                string username = row.Cells["username"].Value.ToString();
                string userType = row.Cells["userType"].Value.ToString();
                int id = Convert.ToInt32(row.Cells["id"].Value);
                userEntity = new UserEntity(username, userType, id);
                Console.WriteLine("Selected user: " + username + " (" + userType + "), ID: " + id);
            }
            if (!string.IsNullOrEmpty(updatedPassword))
            {
                UserRepository userRepository = new UserRepository();
                if (userRepository.UpdateUserPassword(userEntity.Id, updatedPassword))
                {
                    MessageBox.Show("User password updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update user password.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a new password.");
            }
        }

        public void DeleteUser(object sender, EventArgs e)
        {
            if (this.admin.GetUsersList().SelectedRows.Count == 0)
            {
                MessageBox.Show("no selected user");
            }
            else
            {
                int id = Convert.ToInt32(this.admin.GetUsersList().SelectedRows[0].Cells[0].Value);
                if (this.userRepository.DeleteUserById(id))
                {
                    MessageBox.Show("Success!");
                    LoadUsers();
                }
                else
                    MessageBox.Show("Error!");
            }
        }

        public void LogoutUser(object sender, EventArgs e)
        {
            this.admin.Hide();
            LoginController loginController = new LoginController();
            loginController.LoginControllerView().Show();
        }

    }
        //public void LoadUsers(DataGridView usersDataGridView)
        //    {
        //       usersDataGridView.Rows.Clear();
        //        List<UserEntity> userList = userRepository.getAllUsers();
        //       foreach (UserEntity user in userList)
        //        {
        //            usersDataGridView.Rows.Add(user.Id, user.UserType, user.Username);
        //       }
        //    }


        //public void HandleSelectionChanged(DataGridView usersDataGridView)
        //{
        //    if (usersDataGridView.SelectedRows.Count > 0)
        //    {
        //        DataGridViewRow row = usersDataGridView.SelectedRows[0];
        //        string username = row.Cells["username"].Value.ToString();
        //        string userType = row.Cells["userType"].Value.ToString();
        //        int id = Convert.ToInt32(row.Cells["id"].Value);
        //        userEntity = new UserEntity(username, userType, id);
        //        // Do something with the selected user data
        //        Console.WriteLine("Selected user: " + username + " (" + userType + "), ID: " + id);
        //    }
        //}

        //public void UpdateUserPassword(DataGridView usersDataGridView, TextBox updatedPasswordTxtBox)
        //    {
        //        string updatedPassword = updatedPasswordTxtBox.Text;
        //        if (usersDataGridView.SelectedRows.Count > 0)
        //        {
        //            DataGridViewRow row = usersDataGridView.SelectedRows[0];
        //            string username = row.Cells["username"].Value.ToString();
        //            string userType = row.Cells["userType"].Value.ToString();
        //            int id = Convert.ToInt32(row.Cells["id"].Value);
        //            userEntity = new UserEntity(username, userType, id);
        //            // Do something with the selected user data
        //            Console.WriteLine("Selected user: " + username + " (" + userType + "), ID: " + id);
        //        }
        //        if (!string.IsNullOrEmpty(updatedPassword))
        //        {
        //            UserRepository userRepository = new UserRepository();
        //            if (userRepository.UpdateUserPassword(userEntity.Id, updatedPassword))
        //            {
        //                MessageBox.Show("User password updated successfully.");
        //                LoadUsers(usersDataGridView);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Failed to update user password.");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please enter a new password.");
        //        }
        //    }

        //public void DeleteUser(DataGridView usersDataGridView)
        //    {
        //        if (usersDataGridView.SelectedRows.Count > 0)
        //        {
        //            DataGridViewRow row = usersDataGridView.SelectedRows[0];
        //            string username = row.Cells["username"].Value.ToString();
        //            string userType = row.Cells["userType"].Value.ToString();
        //            int id = Convert.ToInt32(row.Cells["id"].Value);
        //            userEntity = new UserEntity(username, userType, id);
        //            // Do something with the selected user data
        //            Console.WriteLine("Selected user: " + username + " (" + userType + "), ID: " + id);
        //        }
        //        if (MessageBox.Show("Are you sure you want to delete this user?", "Delete User", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //        {
        //            UserRepository userRepository = new UserRepository();
        //            if (userRepository.DeleteUserById(userEntity.Id))
        //            {
        //                MessageBox.Show("User deleted successfully.");
        //                LoadUsers(usersDataGridView);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Failed to delete user.");
        //            }
        //        }
        //    }
        //}
    }
