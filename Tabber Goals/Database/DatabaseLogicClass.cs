using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Tabber_Goals.Component;
using System.Windows.Controls;
using System.Windows;
using Tabber_Goals.Component.Goal_Component;
using Tabber_Goals.Global;

namespace Tabber_Goals.Database
{
    public class DatabaseLogicClass
    {
        #region Classes
        DatabaseAccessClass DatabaseAccessClass = new DatabaseAccessClass();
        #endregion

        #region Methods

        #region Create Goal
        /// <summary>
        /// Create goal details in database and display goal control in goal area
        /// </summary>
        /// <param name="GoalArea"></param>
        public void CreateGoal(WrapPanel GoalArea)
        {
            try
            {
                // Create goal control
                GoalControl goalControl = new GoalControl();
                goalControl.GoalTargetDate = DateTime.Today;
                goalControl.GoalTitle = $"Goal Title {GoalArea.Children.Count}";
                goalControl.GoalProgress = 0;

                //Add Goal Control Sizing
                GlobalClass.GoalSizes(GoalArea, goalControl);

                // Add goal control details to database
                goalControl.GoalId = DatabaseAccessClass.CreateGoal(goalControl.GoalTitle, goalControl.GoalProgress, goalControl.GoalTargetDate);

                // Display goal control in goal area
                GoalArea.Children.Add(goalControl);
            }
            catch { throw; }
        }
        #endregion

        #region Update Goal 
        /// <summary>
        /// Update goal details in database and display goal control changes in goal area 
        /// </summary>
        /// <param name="goalId"></param>
        /// <param name="goalTitle"></param>
        /// <param name="goalProgress"></param>
        /// <param name="goalTargetDate"></param>
        public void UpdateGoal(int goalId, string goalTitle, int goalProgress, DateTime goalTargetDate)
        {
            try
            {
                // Update goal control details in database
                DatabaseAccessClass.UpdateGoal(goalId, goalTitle, goalProgress, goalTargetDate);
            }
            catch { throw; }
        }
        #endregion

        #region Delete Goal 
        /// <summary>
        /// Delete goal details from database and remove goal control from goal area
        /// </summary>
        /// <param name="GoalArea"></param>
        /// <param name="goalControl"></param>
        /// <param name="goalId"></param>
        public void DeleteGoal(WrapPanel GoalArea, GoalControl goalControl, int goalId)
        {
            try
            {
                // User confirmation to delete goal control
                string message = $"Are you sure you want to delete goal {goalId}. This can't undo this action.";
                string title = "Delete Goals";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                MessageBoxResult result = MessageBox.Show(message, title, buttons, MessageBoxImage.Question);
            
                if (result == MessageBoxResult.Yes)
                {
                    // Delete goal details from database
                    DatabaseAccessClass.DeleteGoal(goalId);

                    // Remove goal control from goal area
                    GoalArea.Children.Remove(goalControl);
                }
            }
            catch { throw; }
        }

        #endregion

        #region Delete All Goals
        /// <summary>
        /// Delete all goal details from database and remove all goal controls from goal area
        /// </summary>
        /// <param name="GoalArea"></param>
        public void DeleteAllGoals(WrapPanel GoalArea)
        {
            try
            {
                // User confirmation to delete all goal controls
                string message = $"Are you sure you want to delete all goals. This can't undo this action.";
                string title = "Delete All Goals";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                MessageBoxResult result = MessageBox.Show(message, title, buttons, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Delete all goal details from database
                    DatabaseAccessClass.DeleteAllGoals();

                    // Remove all goal controls from goal area
                    GoalArea.Children.Clear();
                }
            }
            catch { throw; }
        }

        #endregion

        #region Load All Goals
        /// <summary>
        /// Get all goal details from database and display all goal controls in goal area 
        /// </summary>
        /// <param name="GoalArea"></param>
        public void LoadAllGoals(WrapPanel GoalArea)
        {
            try
            {
                DataTable dataTable = new DataTable();

                // Get all goal details from database
                dataTable = DatabaseAccessClass.LoadAllGoals();

                foreach (DataRow row in dataTable.Rows)
                {
                    // Create a new gaol control
                    GoalControl goalControl = new GoalControl();
                    goalControl.GoalTargetDate = DateTime.Parse(row["GoalTargetDate"].ToString());
                    goalControl.GoalId = int.Parse(row["GoalId"].ToString());
                    goalControl.GoalTitle = row["GoalTitle"].ToString();
                    goalControl.GoalProgress = int.Parse(row["GoalProgress"].ToString());

                    //Add Goal Control Sizing
                    GlobalClass.GoalSizes(GoalArea, goalControl);

                    // Display goal control in goal area
                    GoalArea.Children.Add(goalControl);
                }
            }
            catch { throw; }
        } 
        
        #endregion

        #endregion
    }
}
