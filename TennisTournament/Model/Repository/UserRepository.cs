using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TennisTournament.Model.Entities;
using TennisTournament.View;

namespace TennisTournament.Model.Repository
{
    public class UserRepository
    {
        private Repository repository;

        private TennisPlayerRepository tennisPlayerRepository;

        private RefereeRepository refereeRepository;

        private OrganizerRepository organizerRepository;

        public UserRepository()
        {
            this.repository = new Repository();
            this.tennisPlayerRepository = new TennisPlayerRepository();
            this.refereeRepository = new RefereeRepository();
            this.organizerRepository = new OrganizerRepository();
        }

        public KeyValuePair<string, int> AuthenticateUser(string username, string password)
        {
            MySqlConnection connection = repository.GetConnection();
            KeyValuePair<string, int> authResult = new KeyValuePair<string, int>(null, 0);
            try
            {
                // Prepare the SQL command to check user credentials
                string query = "SELECT id, userType FROM user WHERE username = @username AND password = @password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                // Execute the command and retrieve the user type and user ID
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int userId = reader.GetInt32(0); // Assuming the user ID is at index 0
                    string userType = reader.GetString(1); // Assuming the user type is at index 1
                    authResult = new KeyValuePair<string, int>(userType, userId);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);
            }
            return authResult;
        }

        public KeyValuePair<string, int> RegisterUser(string username, string password, string userType)
        {
            MySqlConnection connection = repository.GetConnection();
            KeyValuePair<string, int> registrationResult = new KeyValuePair<string, int>();

            try
            {
                // Check if the username already exists
                string checkQuery = "SELECT COUNT(*) FROM user WHERE username = @username";
                MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@username", username);

                int existingUserCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (existingUserCount == 0)
                {
                    // If username doesn't exist, proceed with user registration
                    string registerQuery = "INSERT INTO user (username, password, userType) VALUES (@username, @password, @userType)";
                    MySqlCommand registerCommand = new MySqlCommand(registerQuery, connection);
                    registerCommand.Parameters.AddWithValue("@username", username);
                    registerCommand.Parameters.AddWithValue("@password", password);
                    registerCommand.Parameters.AddWithValue("@userType", userType);
                    registerCommand.ExecuteNonQuery();
                    int id = (int) registerCommand.LastInsertedId;
                    // If rowsAffected > 0, user registration is successful
                    if (id != 0)
                    {
                        switch (userType)
                        {
                            case "Tennis player":
                                if(tennisPlayerRepository.AddTennisPlayer(id)){
                                   registrationResult = new KeyValuePair<string, int>(userType, id);
                                }
                                break;
                            case "Referee":
                                if (refereeRepository.AddReferee(id))
                                {
                                   registrationResult = new KeyValuePair<string, int>(userType, id);
                                }
                                break;
                            case "Organizer":
                                if (organizerRepository.AddOrganizer(id))
                                {
                                    registrationResult = new KeyValuePair<string, int>(userType, id);
                                }
                                break;
                            default:
                                // Handle invalid user type
                                MessageBox.Show("Invalid user type!");
                                break;
                        }
                    }
                }
                else
                {
                    // Username already exists, set isRegistered to false
                    registrationResult = new KeyValuePair<string, int>(null, 0);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);
            }

            return registrationResult;
        }

        public List<UserEntity> getAllUsers()
        {
            MySqlConnection connection = repository.GetConnection();
            List<UserEntity> userList = new List<UserEntity>();

            try
            {
                // Prepare the SQL command to retrieve all users
                string query = "SELECT id, username, userType FROM user";
                MySqlCommand command = new MySqlCommand(query, connection);

                // Execute the command and retrieve the user data
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0); // Assuming the user ID is at index 0
                    string username = reader.GetString(1); // Assuming the username is at index 1
                    string userType = reader.GetString(2); // Assuming the user type is at index 2
                    UserEntity userEntity = new UserEntity(username, userType, id);
                    userList.Add(userEntity);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);
            }

            return userList;
        }

        public bool UpdateUserPassword(int id, string newPassword)
        {
            MySqlConnection connection = repository.GetConnection();
            bool isUpdated = false;

            try
            {
                // Prepare the SQL command to update the user's password
                string query = "UPDATE user SET password = @password WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@password", newPassword);

                // Execute the command and check if the update was successful
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    isUpdated = true;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);
            }

            return isUpdated;
        }

        public bool DeleteUserById(int id)
        {
            MySqlConnection connection = repository.GetConnection();
            bool isDeleted = false;

            try
            {
                // Prepare the SQL command to delete the user
                string query = "DELETE FROM user WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                // Execute the command and check if the deletion was successful
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    isDeleted = true;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);
            }

            return isDeleted;
        }
    }
}
