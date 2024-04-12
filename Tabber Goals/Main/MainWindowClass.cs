using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tabber_Goals.Component;
using Tabber_Goals.Component.Goal_Component;
using Tabber_Goals.Database;
using Tabber_Goals.Global;

namespace Tabber_Goals.Main
{
    public class MainWindowClass
    {
        #region Classes
        DatabaseLogicClass DatabaseLogicClass = new DatabaseLogicClass();
        #endregion

        #region Methods

        #region Version
        public void LoadVersion(Window mainWindow)
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

        #region Toolbar

        #region Delete All Goals
        public void DeleteAllGoals(WrapPanel GoalArea)
        {
            DatabaseLogicClass.DeleteAllGoals(GoalArea);
        }
        #endregion

        #region Create Goal
        public void CreateGoal(WrapPanel GoalArea)
        {
            DatabaseLogicClass.CreateGoal(GoalArea);
        }
        #endregion

        #endregion

        #region Goal Area

        #region Load
        public void LoadAllGoals(WrapPanel GoalArea)
        {
            DatabaseLogicClass.LoadAllGoals(GoalArea);
        }
        #endregion

        #region Size Changed
        public void GoalArea_SizeChanged(WrapPanel GoalArea)
        {
            foreach(GoalControl goalControl in GoalArea.Children)
            {
                //Add Goal Control Sizing
                GlobalClass.GoalSizes(GoalArea, goalControl);
            }
        }
        #endregion

        #endregion

        #endregion

        #region OLD CODE

        #region Delete All Goals Button Mouse Events
        public void DeleteAllGoalButtonMouseEvents(Button DeleteAllGoalsButton)
        {
            DeleteAllGoalsButton.MouseEnter += (sender, e) =>
            {

            };

            DeleteAllGoalsButton.MouseEnter -= (sender, e) =>
            {

            };
        }
        #endregion

        #endregion
    }
}
