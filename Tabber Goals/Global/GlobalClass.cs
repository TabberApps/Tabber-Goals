using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tabber_Goals.Component;
using Tabber_Goals.Database;
using Tabber_Goals.TabberUI.Controls;

namespace Tabber_Goals.Global
{
    public static class GlobalClass
    {
        //This class contains methods that
        //don't fit in other classes or event
        //classes eg. GoalControlEventsClass.cs
        //or are needing to be used by multiple classes.

        #region Classes
        static DatabaseAccessClass DatabaseAccessClass = new DatabaseAccessClass();
        #endregion

        #region Goal Sizes
        public static void GoalSizes(TabberWrapPanel GoalArea, GoalControl GoalControl)
        {
            GoalControl.Width = GoalArea.ActualWidth / 5 - 20;
            GoalControl.Height = 200;
            GoalControl.Margin = new Thickness(10);

            GoalControl.MinWidth = 200;
            GoalControl.MinHeight = 200;
        }
        #endregion

        #region Goal Count
        public static int MaximumGoalCount()
        {
            return 15;
        }

        public static string GoalCountLabelText(TextBlock GoalCountLabel)
        {
            return GoalCountLabel.Text = $"Goals Created {DatabaseAccessClass.GoalCount()}/{MaximumGoalCount()}";
        }
        #endregion

        #region Version
        public static void Version(Window mainWindow)
        {
            try
            {
                mainWindow.Title = $"Tabber Goals : {ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()}";
            }
            catch
            {
                mainWindow.Title = $"Tabber Goals : Developer Mode";
            }
        }
        #endregion
    }
}
