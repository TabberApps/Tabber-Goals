using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tabber_Goals.Component;

namespace Tabber_Goals.Global
{
    public static class GlobalClass
    {
        public static void GoalSizes(WrapPanel GoalArea, GoalControl GoalControl)
        {
            GoalControl.Width = GoalArea.ActualWidth / 5 - 20;
            GoalControl.Height = 200;
            GoalControl.Margin = new Thickness(10);

            GoalControl.MinWidth = 200;
            GoalControl.MinHeight = 200;
        }
    }
}
