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
        MainWindowClass MainWindowClass = new MainWindowClass();
        #endregion


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowClass.LoadAllGoals(GoalArea);
            MainWindowClass.LoadVersion(this);
        }

        private void AddGoalButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowClass.CreateGoal(GoalArea);
        }

        private void DeleteAllGoalsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowClass.DeleteAllGoals(GoalArea);
        }

        private void GoalArea_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainWindowClass.GoalArea_SizeChanged(GoalArea);
        }
    }
}
