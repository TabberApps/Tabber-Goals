using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tabber_Goals.Component;
using Tabber_Goals.Database;
using Tabber_Goals.Global;

namespace Tabber_Goals.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Classes
        MainWindowEventsClass MainWindowEventsClass = new MainWindowEventsClass();
        #endregion


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowEventsClass.LoadAllGoals(GoalArea);
            GlobalClass.Version(this);
        }

        private void AddGoalButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowEventsClass.CreateGoal(GoalArea);
        }

        private void DeleteAllGoalsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowEventsClass.DeleteAllGoals(GoalArea);
        }

        private void GoalArea_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainWindowEventsClass.GoalArea_SizeChanged(GoalArea);
        }
    }
}
