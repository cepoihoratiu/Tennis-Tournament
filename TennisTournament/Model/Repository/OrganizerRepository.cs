using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournament.Model.Entities;

namespace TennisTournament.Model.Repository
{
    public class OrganizerRepository
    {
        private Repository repository;

        private OrganizerEntity organizerEntity;

        private MySqlConnection connection;


        public OrganizerRepository()
        {
            this.repository = new Repository();
            connection = repository.GetConnection();
        }

        public bool AddOrganizer(int userId)
        {
            bool isRegistered = false;
            try
            {

                string addQuery = "INSERT INTO organizer (userId) VALUES (@userId)";
                MySqlCommand addCommand = new MySqlCommand(addQuery, connection);
                addCommand.Parameters.AddWithValue("@userId", userId);

                int rowsAffected = addCommand.ExecuteNonQuery();

                // If rowsAffected > 0,  is successful
                if (rowsAffected > 0)
                {
                    isRegistered = true;
                }
                else
                {
                    isRegistered = false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);
            }

            return isRegistered;
        }

        public OrganizerEntity GetOrganizer(int userId)
        {
            try
            {
                string query = "SELECT name, surname, nationality FROM organizer WHERE userId = @userId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                Console.WriteLine("enter with " + userId);

                // Execute the command and retrieve the user type and user ID

                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (!reader.IsDBNull(0) && !reader.IsDBNull(1) && !reader.IsDBNull(2))
                {
                    string name = reader.GetString(0);
                    string surname = reader.GetString(1);
                    string nationality = reader.GetString(2);
                    organizerEntity = new OrganizerEntity(name, surname, nationality);
                }
                else
                {
                    organizerEntity = new OrganizerEntity("", "", "");
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);

            }
            return organizerEntity;
        }

        public bool UpdateOrganizer(int userId, string name, string surname, string nationality)
        {
            bool isUpdated = false;
            try
            {
                string updateQuery = "UPDATE organizer SET name = @name, surname = @surname, nationality = @nationality WHERE userId = @userId";
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

        public bool DeleteOrganizer(int userId)
        {
            bool isDeleted = false;
            try
            {
                string deleteQuery = "DELETE FROM organizer WHERE userId = @userId";
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
