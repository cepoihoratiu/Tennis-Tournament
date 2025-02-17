using System;
using System.Windows.Forms;


namespace TennisTournament.View
{
    public partial class Admin : Form
    {

        //private AdminController adminController = new AdminController(); // Create an instance of AdminController

        public Admin()
        {
            InitializeComponent();
            //adminController.LoadUsers(usersDataGridView);
        }

        public TextBox GetNewPasasword()
        {
            return this.updatedPasswordTxtBox;
        }
        public DataGridView GetUsersList()
        {
            return this.usersDataGridView;
        }

        public Button GetUpdateButton()
        {
            return this.updateUserPasswordBtn;
        }

        public Button GetDeleteButton()
        {
            return this.deleteUserBtn;
        }

        public Button GetLogoutButton()
        {
            return this.logoutBtn;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            //Login loginForm = new Login();
            //loginForm.Show();
            //this.Hide();
        }

        private void usersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //adminController.HandleSelectionChanged(usersDataGridView); // Call HandleSelectionChanged from AdminController
        }

        private void updateUserPasswordBtn_Click(object sender, EventArgs e)
        {
            //adminController.UpdateUserPassword(usersDataGridView, updatedPasswordTxtBox); // Call UpdateUserPassword from AdminController

        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            //adminController.DeleteUser(usersDataGridView); // Call DeleteUser from AdminController
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
