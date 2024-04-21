using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Tabber_Goals.Database;
using Tabber_Goals.TabberUI.Controls;


namespace Tabber_Goals.Component.Goal_Component
{
    public class GoalControlEventsClass
    {
        #region Classes
        DatabaseLogicClass DatabaseLogicClass = new DatabaseLogicClass();
        #endregion

        #region Goal Progress 

        #region Goal Progress Value Text Box

        #region Focus
        public void GoalProgressValueTextBox_GotFocus(TextBox GoalProgressValueTextBox)
        {
            if (GoalProgressValueTextBox.Text.Contains("%"))
            {
                // Remove all occurrences of %
                GoalProgressValueTextBox.Text = GoalProgressValueTextBox.Text.Trim('%');
            }
        }

        public void GoalProgressValueTextBox_LostFocus(TextBox GoalProgressValueTextBox, ProgressBar GoalProgressBar)
        {
            // Check if gaol progress value text box is null or does not contain %
            if(GoalProgressValueTextBox.Text != "" && GoalProgressValueTextBox.Text.Contains("%") == false) 
            { 
                // Set goal progress bar value to goal progress value text box value
                GoalProgressBar.Value = int.Parse(GoalProgressValueTextBox.Text);

                // Change goal progress text box value to goal progress bar value with % added at the end
                GoalProgressValueTextBox.Text = $"{GoalProgressBar.Value.ToString()}%";
            }
            else
            {
                // Set goal progress to 0% for all controls 
                GoalProgressValueTextBox.Text = "0%";
                GoalProgressBar.Value = 0;
            }
        }
        #endregion

        #region Key Down
        public void GoalProgressValueTextBox_KeyDown(KeyEventArgs e)
        {
            // If the pressed key is not a digit or a control prevent it from being pressed
            if (!char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) && !char.IsControl((char)KeyInterop.VirtualKeyFromKey(e.Key)))
            {
                e.Handled = true;
            }
            else
            {
                // Check if Shift key is being pressed along with other keys
                if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                {
                    // If Shift key is pressed along with other keys, don't allow it
                    e.Handled = true;
                }
                else
                {
                    // Mark the event as not handled to allow input
                    e.Handled = false;
                }
            }
        }
        #endregion

        #endregion

        #region Goal Progress Bar
        public void GoalProgressBar_ValueChanged(ProgressBar GoalProgressBar)
        {
            if(GoalProgressBar.Value <= 25)
            {
                GoalProgressBar.Foreground = new SolidColorBrush(Color.FromRgb(252, 206, 211)); //Red
            }
            else if (GoalProgressBar.Value > 25 && GoalProgressBar.Value < 75)
            {
                GoalProgressBar.Foreground = new SolidColorBrush(Color.FromRgb(251, 224, 165)); //Yellow
            }
            else if (GoalProgressBar.Value >= 75)
            {
                GoalProgressBar.Foreground = new SolidColorBrush(Color.FromRgb(196, 241, 201)); //Green
            }
        }
        #endregion

        #endregion

        #region Update Goal
        public void UpdateGoal(int goalId, string goalTitle, int goalProgress, DateTime goalTargetDate)
        {
            DatabaseLogicClass.UpdateGoal(goalId, goalTitle, goalProgress, goalTargetDate);
        }
        #endregion

        #region Delete Goal
        public void DeleteGoal(TabberWrapPanel GoalArea, GoalControl goalControl, int goalId)
        {
            DatabaseLogicClass.DeleteGoal(GoalArea, goalControl, goalId);
        }
        #endregion
    }
}
