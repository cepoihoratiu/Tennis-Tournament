using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TennisTournament.Model.Entities;
using TennisTournament.Model.Repository;
using TennisTournament.View;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TennisTournament.Controller
{
    public class LoginController
    {
        private UserRepository userRepository;
        private Login login;

        public LoginController()
        {
            this.login = new Login();
            this.userRepository = new UserRepository();
            this.login.GetChangeLanguageButton().Click += new EventHandler(ChangeLanguage);
            this.login.GetLoginButton().Click += new EventHandler(LoginApp);
            this.login.GetRegisterButton().Click += new EventHandler(Register);

        }

        public Login LoginControllerView()
        { 
            return this.login; 
        }

        public void ChangeLanguage(object sender, EventArgs e)
        {
            string selectedCulture = this.login.GetSelectedLanguage().SelectedItem.ToString();
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = new CultureInfo(selectedCulture);
            Properties.Settings.Default.Culture = selectedCulture;
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        public void LoginApp(object sender, EventArgs e)
        {
            KeyValuePair<string, int> userAuthentication = userRepository.AuthenticateUser(this.login.GetUsername().Text, this.login.GetPasasword().Text);

            if (userAuthentication.Key != null && userAuthentication.Value != 0)
            {
                RedirectToUserForm(userAuthentication.Key, userAuthentication.Value, this.login);
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        public void Register(object sender, EventArgs e)
        {
            string selectedType = this.login.GetUserType().SelectedItem.ToString();
            KeyValuePair<string, int> isRegisteredPair = userRepository.RegisterUser(this.login.GetUsername().Text, this.login.GetPasasword().Text, selectedType);

            if (isRegisteredPair.Key != null && isRegisteredPair.Value != 0)
            {
                RedirectToUserForm(isRegisteredPair.Key, isRegisteredPair.Value, this.login);
            }
            else
            {
                MessageBox.Show("Invalid username or password. Username already exists.");
            }
        }

        private void RedirectToUserForm(string userType, int userId, Form loginForm)
        {
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.Culture);

            switch (userType)
            {
                case "Tennis player":
                    TennisPlayerController tennisPlayerController = new TennisPlayerController(userId);
                    tennisPlayerController.ViewTennisPlayer().Show();
                    loginForm.Hide();
                    break;
                case "Referee":
                    RefereeController refereeController = new RefereeController(userId);
                    refereeController.ViewReferee().Show();
                    loginForm.Hide();
                    break;
                case "Organizer":
                    OrganizerController organizerController = new OrganizerController(userId);
                    organizerController.ViewOrganizer().Show();
                    loginForm.Hide();
                    break;
                case "Admin":
                    AdminController adminController = new AdminController();
                    adminController.ViewAdmin().Show();
                    loginForm.Hide();
                    break;
                default:
                    MessageBox.Show("Invalid user type!");
                    break;
            }
        }
    }
}
