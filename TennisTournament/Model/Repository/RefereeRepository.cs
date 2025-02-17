using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournament.Model.Entities;

namespace TennisTournament.Model.Repository
{
    public class RefereeRepository
    {
        private Repository repository= new Repository();

        private RefereeEntity refereeEntity;

        private MySqlConnection connection;


        public RefereeRepository()
        {
            connection = repository.GetConnection();
        }

        public bool AddReferee(int userId)
        {
            bool isRegistered = false;
            try
            {

                string addQuery = "INSERT INTO referee (userId) VALUES (@userId)";
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

        public RefereeEntity GetReferee(int userId)
        {
            try
            {
                string query = "SELECT id, name, surname, nationality FROM referee WHERE userId = @userId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                Console.WriteLine("enter with " + userId);

                // Execute the command and retrieve the user type and user ID

                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (!reader.IsDBNull(1) && !reader.IsDBNull(2) && !reader.IsDBNull(3))
                {
                    int id = reader.GetInt32(0); 
                    string name = reader.GetString(1);
                    string surname = reader.GetString(2);
                    string nationality = reader.GetString(3);
                    refereeEntity = new RefereeEntity(id, name, surname, nationality);
                }
                else
                {
                    refereeEntity = new RefereeEntity(reader.GetInt32(0), "", "", "");
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);

            }
            return refereeEntity;
        }

        public RefereeEntity GetRefereeById(int id)
        {
            try
            {
                string query = "SELECT id, name, surname, nationality FROM referee WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                Console.WriteLine("enter with " + id);

                // Execute the command and retrieve the user type and user ID

                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (!reader.IsDBNull(1) && !reader.IsDBNull(2) && !reader.IsDBNull(3))
                {
                    int refid = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string surname = reader.GetString(2);
                    string nationality = reader.GetString(3);
                    refereeEntity = new RefereeEntity(refid, name, surname, nationality);
                }
                else
                {
                    refereeEntity = new RefereeEntity(reader.GetInt32(0), "", "", "");
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);

            }
            return refereeEntity;
        }

        public bool UpdateReferee(int userId, string name, string surname, string nationality)
        {
            bool isUpdated = false;
            try
            {
                string updateQuery = "UPDATE referee SET name = @name, surname = @surname, nationality = @nationality WHERE userId = @userId";
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

        public bool DeleteReferee(int userId)
        {
            bool isDeleted = false;
            try
            {
                string deleteQuery = "DELETE FROM referee WHERE userId = @userId";
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
