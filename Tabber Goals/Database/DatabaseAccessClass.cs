using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tabber_Goals.Database
{
    public class DatabaseAccessClass
    {
        #region Connection String
        public SqlConnection ConnectionString = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database\\TabberGoalsDatabase.mdf;Integrated Security=True");
        #endregion

        #region Methods

        #region Create Goal
        /// <summary>
        /// Create goal details in database 
        /// </summary>
        /// <param name="goalTitle"></param>
        /// <param name="goalProgress"></param>
        /// <param name="goalTargetDate"></param>
        /// <returns></returns>
        public int CreateGoal(string goalTitle, int goalProgress, DateTime goalTargetDate)
        {
            if(ConnectionString.State == ConnectionState.Closed)
            {
                ConnectionString.Open();
            }

            try
            {
                // Create goal stored procedure
                using(SqlCommand command = new SqlCommand("CreateGoal", ConnectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GoalTitle", goalTitle);
                    command.Parameters.AddWithValue("@GoalProgress", goalProgress);
                    command.Parameters.AddWithValue("@GoalTargetDate", goalTargetDate);

                    // Get next goal id in goal table 
                    int nextId = (int)command.ExecuteScalar();
                    ConnectionString.Close();

                    return nextId;
                }
            }
            catch { ConnectionString.Close(); throw;  }
        }
        #endregion

        #region Update Goal 
        /// <summary>
        /// Update goal details in database 
        /// </summary>
        /// <param name="goalId"></param>
        /// <param name="goalTitle"></param>
        /// <param name="goalProgress"></param>
        /// <param name="goalTargetDate"></param>
        public void UpdateGoal(int goalId, string goalTitle, int goalProgress, DateTime goalTargetDate)
        {
            if (ConnectionString.State == ConnectionState.Closed)
            {
                ConnectionString.Open();
            }

            try
            {
                // Update goal stored procedure
                using (SqlCommand command = new SqlCommand("UpdateGoal", ConnectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GoalId", goalId);
                    command.Parameters.AddWithValue("@GoalTitle", goalTitle);
                    command.Parameters.AddWithValue("@GoalProgress", goalProgress);
                    command.Parameters.AddWithValue("@GoalTargetDate", goalTargetDate);
                    
                    command.ExecuteNonQuery();
                    ConnectionString.Close();
                }
            }
            catch { ConnectionString.Close(); throw; }
        }
        #endregion

        #region Delete Goal 
        /// <summary>
        /// Delete goal details from database 
        /// </summary>
        /// <param name="goalId"></param>
        public void DeleteGoal(int goalId)
        {
            if (ConnectionString.State == ConnectionState.Closed)
            {
                ConnectionString.Open();
            }

            try
            {
                // Delete goal stored procedure
                using (SqlCommand command = new SqlCommand("DeleteGoal", ConnectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GoalId", goalId);

                    command.ExecuteNonQuery();
                    ConnectionString.Close();
                }
            }
            catch { ConnectionString.Close(); throw; }
        }

        #endregion

        #region Delete All Goals
        /// <summary>
        /// Delete all goal details from database 
        /// </summary>
        public void DeleteAllGoals()
        {
            if (ConnectionString.State == ConnectionState.Closed)
            {
                ConnectionString.Open();
            }

            try
            {
                // Delete all goals stored procedure 
                using (SqlCommand command = new SqlCommand("DeleteAllGoals", ConnectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.ExecuteNonQuery();
                    ConnectionString.Close();
                }
            }
            catch { ConnectionString.Close(); throw; }
        }

        #endregion

        #region Load All Goals
        /// <summary>
        /// Load all goal details from database 
        /// </summary>
        /// <returns></returns>
        public DataTable LoadAllGoals()
        {
            if (ConnectionString.State == ConnectionState.Closed)
            {
                ConnectionString.Open();
            }

            try
            {
                //Load all goals stored procedure
                using (SqlCommand command = new SqlCommand("LoadAllGoals", ConnectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    
                    using(SqlDataAdapter adapter = new SqlDataAdapter(command)) 
                    { 
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        ConnectionString.Close();

                        return table;
                    }
                }
            }
            catch { ConnectionString.Close(); throw; }
        }

        #endregion

        #region Goal Count
        /// <summary>
        /// Create goal details in database 
        /// </summary>
        /// <param name="goalTitle"></param>
        /// <param name="goalProgress"></param>
        /// <param name="goalTargetDate"></param>
        /// <returns></returns>
        public int GoalCount()
        {
            if (ConnectionString.State == ConnectionState.Closed)
            {
                ConnectionString.Open();
            }

            try
            {
                // Create goal stored procedure
                using (SqlCommand command = new SqlCommand("GoalCount", ConnectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Get goal count in goal table 
                    int goalCount = (int)command.ExecuteScalar();
                    ConnectionString.Close();

                    return goalCount;
                }
            }
            catch { ConnectionString.Close(); throw; }
        }
        #endregion

        #endregion
    }
}
