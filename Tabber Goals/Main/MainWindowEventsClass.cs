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
using Tabber_Goals.TabberUI.Controls;

namespace Tabber_Goals.Main
{
    public class MainWindowEventsClass
    {
        #region Classes
        DatabaseLogicClass DatabaseLogicClass = new DatabaseLogicClass();
        #endregion

        #region Methods

        #region Toolbar

        #region Delete All Goals
        public void DeleteAllGoals(TabberWrapPanel GoalArea)
        {
            DatabaseLogicClass.DeleteAllGoals(GoalArea);
        }
        #endregion

        #region Create Goal
        public void CreateGoal(TabberWrapPanel GoalArea)
        {
            DatabaseLogicClass.CreateGoal(GoalArea);
        }
        #endregion

        #endregion

        #region Goal Area

        #region Load
        public void LoadAllGoals(TabberWrapPanel GoalArea)
        {
            DatabaseLogicClass.LoadAllGoals(GoalArea);
        }
        #endregion

        #region Size Changed
        public void GoalArea_SizeChanged(TabberWrapPanel GoalArea)
        {
            foreach(GoalControl goalControl in GoalArea.Children)
            {
                //Add Goal Control Sizing
                GlobalClass.GoalSizes(GoalArea, goalControl);
            }
        }
        #endregion

        #region Child Added/Removed
        public void GoalArea_ChildAdded(TextBlock GoalCountLabel)
        {
           GlobalClass.GoalCountLabelText(GoalCountLabel);
        }
        public void GoalArea_ChildRemoved(TextBlock GoalCountLabel)
        {
            GlobalClass.GoalCountLabelText(GoalCountLabel);
        }
        #endregion

        #endregion

        #endregion
    }
}
