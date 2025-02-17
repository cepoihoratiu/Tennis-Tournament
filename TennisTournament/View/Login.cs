using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace TennisTournament
{
    public partial class Login : Form
    {
        //UserRepository userRepository = new UserRepository();
       // private LoginController loginController = new LoginController(); // Create an instance of LoginController
        public Login()
        {
            InitializeComponent();
            PopulateComboBox();
            PopulateComboBoxLng();
        }
        public TextBox GetUsername()
        {
            return this.usernameTxtBox;
        }

        public TextBox GetPasasword()
        {
            return this.passwordTxtBox;
        }

        public ComboBox GetUserType()
        {
            return this.userTypeComboBox;
        } 

        public Button GetLoginButton()
        {
            return this.loginBtn;
        }

        public Button GetRegisterButton()
        {
            return this.registerBtn;
        }

        public Button GetChangeLanguageButton()
        {
            return this.changeLngBtn;
        }

        public ComboBox GetSelectedLanguage()
        {
            return this.comboBoxLng;
        }


        private void PopulateComboBox()
        {
            userTypeComboBox.Items.Clear();
            userTypeComboBox.Items.AddRange(new object[] { "Tennis player", "Referee", "Organizer" });
            userTypeComboBox.SelectedIndex = 0;
        }

        private void PopulateComboBoxLng()
        {
            comboBoxLng.Items.Clear();
            comboBoxLng.Items.AddRange(new object[] { "en-US", "ro", "de-DE" });
            string currentCulture = Properties.Settings.Default.Culture;
            for (int i = 0; i < comboBoxLng.Items.Count; i++)
            {
                string culture = comboBoxLng.Items[i].ToString();
                if (culture == currentCulture)
                {
                    comboBoxLng.SelectedIndex = i;
                    break;
                }
            }
        }


        private void changeLngBtn_Click(object sender, EventArgs e)
        {
            //string selectedCulture = comboBoxLng.SelectedItem.ToString();
            //Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = new CultureInfo(selectedCulture);
            //Properties.Settings.Default.Culture = selectedCulture;
            //Properties.Settings.Default.Save();
            //Application.Restart();
        }



        private void loginBtn_Click(object sender, EventArgs e)
        {
            //loginController.AuthenticateUser(usernameTxtBox.Text, passwordTxtBox.Text, userTypeComboBox, this);
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            //loginController.RegisterUser(usernameTxtBox.Text, passwordTxtBox.Text, userTypeComboBox.Text, userTypeComboBox, this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void usernameTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxLng_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void userTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
