using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournament.Model.Entities;
using TennisTournament.View;

namespace TennisTournament.Model.Repository
{
    public class FixtureRepository
    {
        private Repository repository;

        private FixtureEntity fixtureEntity;

        private MySqlConnection connection;


        public FixtureRepository()
        {
            this.repository = new Repository();
            connection = repository.GetConnection();
        }

        public bool AddFixture(string startTime, int firstPlayerId, int secondPlayerId, int refereeId, string score)
        {
            bool isAdded = false;
            try
            {
                string addQuery = "INSERT INTO Fixtures (startTime, firstPlayerId, secondPlayerId, refereeId, score) VALUES (@startTime, @firstPlayerId, @secondPlayerId, @refereeId, @score)";
                MySqlCommand addCommand = new MySqlCommand(addQuery, connection);
                addCommand.Parameters.AddWithValue("@startTime", startTime);
                addCommand.Parameters.AddWithValue("@firstPlayerId", firstPlayerId);
                addCommand.Parameters.AddWithValue("@secondPlayerId", secondPlayerId);
                addCommand.Parameters.AddWithValue("@refereeId", refereeId);
                addCommand.Parameters.AddWithValue("@score", score);

                int rowsAffected = addCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    isAdded = true;
                }
                else
                {
                    isAdded = false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);
            }

            return isAdded;
        }

        public FixtureEntity GetFixture(int firstPlayerId)
        {
            try
            {
                string query = "SELECT startTime, firstPlayerId, secondPlayerId, refereeId, score FROM Fixtures WHERE firstPlayerId = @firstPlayerId OR secondPlayerId = @firstPlayerId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@firstPlayerId", firstPlayerId);

                Console.WriteLine("enter with " + firstPlayerId);

                // Execute the command and retrieve the user type and user ID

                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (!reader.IsDBNull(0) && !reader.IsDBNull(2) && !reader.IsDBNull(3) && !reader.IsDBNull(4))
                {
                    string startTime = reader.GetString(0);
                    int secondPlayerId = reader.GetInt32(2);
                    int refereeId = reader.GetInt32(3);
                    string score = reader.GetString(4);
                    fixtureEntity = new FixtureEntity(0, startTime, firstPlayerId, secondPlayerId, refereeId, score);
                }
                else
                {
                    fixtureEntity = new FixtureEntity(0,"",0,0,0,"0-0");
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);

            }
            return fixtureEntity;
        }

        public List<FixtureEntity> GetAllFixtures()
        {
            List<FixtureEntity> fixtures = new List<FixtureEntity>();
            try
            {
                string query = "SELECT id, startTime, firstPlayerId, secondPlayerId, refereeId, score FROM Fixtures";
                MySqlCommand command = new MySqlCommand(query, connection);

                // Execute the command and retrieve the user type and user ID

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string startTime = reader.GetString(1);
                    int firstPlayerId = reader.GetInt32(2);
                    int secondPlayerId = reader.GetInt32(3);
                    int refereeId = reader.GetInt32(4);
                    string score = reader.GetString(5);

                    FixtureEntity fixture = new FixtureEntity(id, startTime, firstPlayerId, secondPlayerId, refereeId, score);
                    fixtures.Add(fixture);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);

            }
            return fixtures;
        }

        public List<FixtureEntity> GetFixtures(int playerId)
        {
            List<FixtureEntity> fixtures = new List<FixtureEntity>();
            try
            {
                string query = "SELECT startTime, firstPlayerId, secondPlayerId, refereeId, score FROM Fixtures WHERE firstPlayerId = @playerId OR secondPlayerId = @playerId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@playerId", playerId);

                Console.WriteLine("enter with " + playerId);

                // Execute the command and retrieve the user type and user ID

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string startTime = reader.GetString(0);
                    int firstPlayerId = reader.GetInt32(1);
                    int secondPlayerId = reader.GetInt32(2);
                    int refereeId = reader.GetInt32(3);
                    string score = reader.GetString(4);

                    FixtureEntity fixture = new FixtureEntity(0, startTime, firstPlayerId, secondPlayerId, refereeId, score);
                    fixtures.Add(fixture);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);

            }
            return fixtures;
        }

        public List<FixtureEntity> GetFixturesAsReferee(int refereeId)
        {
            List<FixtureEntity> fixtures = new List<FixtureEntity>();
            try
            {
                string query = "SELECT startTime, firstPlayerId, secondPlayerId, refereeId, score FROM Fixtures WHERE refereeId = @refereeId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@refereeId", refereeId);

                Console.WriteLine("enter with " + refereeId);

                // Execute the command and retrieve the user type and user ID

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string startTime = reader.GetString(0);
                    int firstPlayerId = reader.GetInt32(1);
                    int secondPlayerId = reader.GetInt32(2);
                    string score = reader.GetString(4);

                    FixtureEntity fixture = new FixtureEntity(0, startTime, firstPlayerId, secondPlayerId, refereeId, score);
                    fixtures.Add(fixture);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display error)
                Console.WriteLine("Error: " + ex.Message);

            }
            return fixtures;
        }

        public bool UpdateFixture(int fixtureId, string startTime,int firstPlayerId, int secondPlayerId, int refereeId, string score)
        {
            bool isUpdated = false;
            try
            {
                string updateQuery = "UPDATE Fixtures SET startTime = @startTime, firstPlayerId = @firstPlayerId, secondPlayerId = @secondPlayerId, refereeId = @refereeId, score = @score WHERE id = @fixtureId";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@startTime", startTime);
                updateCommand.Parameters.AddWithValue("@fixtureId", fixtureId);
                updateCommand.Parameters.AddWithValue("@firstPlayerId", firstPlayerId);
                updateCommand.Parameters.AddWithValue("@secondPlayerId", secondPlayerId);
                updateCommand.Parameters.AddWithValue("@refereeId", refereeId);
                updateCommand.Parameters.AddWithValue("@score", score);

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

        public bool DeleteFixture(int fixtureId)
        {
            bool isDeleted = false;
            try
            {
                string deleteQuery = "DELETE FROM Fixtures WHERE id = @fixtureId";
                MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@fixtureId", fixtureId);

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

        public bool DeleteFixtureWhereTennisPlayerIsFound(int tennisPlayerId)
            {
                bool isDeleted = false;
                try
                {
                    string deleteQuery = "DELETE FROM Fixtures WHERE firstPlayerId = @tennisPlayerId OR secondPlayerId = @tennisPlayerId";
                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@tennisPlayerId", tennisPlayerId);

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


        public bool DeleteFixtureWhereRefereeIsFound(int refereeId)
        {
            bool isDeleted = false;
            try
            {
                string deleteQuery = "DELETE FROM Fixtures WHERE refereeId = @refereeId";
                MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@refereeId", refereeId);

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
