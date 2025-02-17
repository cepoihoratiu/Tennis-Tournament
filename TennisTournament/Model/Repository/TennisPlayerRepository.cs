using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TennisTournament.Model.Entities;

namespace TennisTournament.Model.Repository
{
    public class TennisPlayerRepository
    {
        private Repository repository;

        private TennisPlayerEntity tennisPlayerEntity;

        private MySqlConnection connection;


        public TennisPlayerRepository()
        {
            this.repository = new Repository();
            connection = repository.GetConnection();
        }

        public bool AddTennisPlayer(int userId)
        {
            bool isRegistered = false;
            // If username doesn't exist, proceed with user registration
            try{
                    
                    string addQuery = "INSERT INTO tennisPlayer (userId) VALUES (@userId)";
                    MySqlCommand addCommand = new MySqlCommand(addQuery, connection);
                    addCommand.Parameters.AddWithValue("@userId", userId);

                    int rowsAffected = addCommand.ExecuteNonQuery();

                    // If rowsAffected > 0,  is successful
                    if (rowsAffected > 0)
                    {
                        isRegistered = true;
                    } else {
                        isRegistered = false;
                     }
            } catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);
            }

            return isRegistered;
        }

        public TennisPlayerEntity GetTennisPlayer(int userId)
        {
            try
            {
                string query = "SELECT id, name, surname, nationality FROM tennisplayer WHERE userId = @userId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                Console.WriteLine("enter with " + userId);

                // Execute the command and retrieve the user type and user ID

                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (!reader.IsDBNull(1) && !reader.IsDBNull(2) && !reader.IsDBNull(3))
                {
                    Console.WriteLine("entered good");
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string surname = reader.GetString(2);
                    string nationality = reader.GetString(3);
                    tennisPlayerEntity = new TennisPlayerEntity(id, name, surname, nationality);
                }
                else
                {
                    tennisPlayerEntity = new TennisPlayerEntity(reader.GetInt32(0), "", "", "");
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);

            }
            return tennisPlayerEntity;
        }

        public TennisPlayerEntity GetTennisPlayerById(int id)
        {
            try
            {
                string query = "SELECT id, name, surname, nationality FROM tennisplayer WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                // Execute the command and retrieve the user type and user ID

                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (!reader.IsDBNull(1) && !reader.IsDBNull(2) && !reader.IsDBNull(3))
                {
                    int idtennis = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string surname = reader.GetString(2);
                    string nationality = reader.GetString(3);
                    tennisPlayerEntity = new TennisPlayerEntity(idtennis, name, surname, nationality);
                }
                else
                {
                    tennisPlayerEntity = new TennisPlayerEntity(0, "", "", "");
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);

            }
            return tennisPlayerEntity;
        }

        public bool UpdateTennisPlayer(int userId, string name, string surname, string nationality)
        {
            bool isUpdated = false;
            try
            {
                string updateQuery = "UPDATE tennisPlayer SET name = @name, surname = @surname, nationality = @nationality WHERE userId = @userId";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@userId", userId);
                updateCommand.Parameters.AddWithValue("@name", name);
                updateCommand.Parameters.AddWithValue("@surname", surname);
                updateCommand.Parameters.AddWithValue("@nationality", nationality);

                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    isUpdated = true;
                }
                else
                {
                    isUpdated = false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);
            }

            return isUpdated;
        }

        public bool DeleteTennisPlayer(int userId)
        {
            bool isDeleted = false;
            try
            {
                string deleteQuery = "DELETE FROM tennisPlayer WHERE userId = @userId";
                MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@userId", userId);

                int rowsAffected = deleteCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    isDeleted = true;
                }
                else
                {
                    isDeleted = false;
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
