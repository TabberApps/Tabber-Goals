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
using Tabber_Goals.Component.Goal_Component;

namespace Tabber_Goals.Component
{
    /// <summary>
    /// Interaction logic for GoalControl.xaml
    /// </summary>
    public partial class GoalControl : UserControl, IGoalComponent
    {
        public GoalControl()
        {
            InitializeComponent();
        }

        #region Properties
        public int GoalId { get; set; }
        public string GoalTitle 
        {
            get { return GoalTitle_TextBox.Text; }
            set {  GoalTitle_TextBox.Text = value;}
        }
        public int GoalProgress 
        {
            get { return (int)GoalProgress_ProgressBar.Value; }

            set 
            {
                GoalProgress_ProgressBar.Value = value; 
                GoalProgressValue_TextBox.Text = $"{GoalProgress}%"; 
            }
        }
        public DateTime GoalTargetDate
        { 
            get { return (DateTime)GoalTargetDate_DatePicker.SelectedDate; }
            set { GoalTargetDate_DatePicker.SelectedDate = value;}
        }
        #endregion

        #region Classes
        GoalControlEventsClass GoalControlEventsClass = new GoalControlEventsClass();

        #endregion

        private void GoalProgressValue_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            GoalControlEventsClass.GoalProgressValueTextBox_GotFocus(GoalProgressValue_TextBox);
        }

        private void GoalProgressValue_TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            GoalControlEventsClass.GoalProgressValueTextBox_LostFocus(GoalProgressValue_TextBox, GoalProgress_ProgressBar);
        }

        private void GoalProgressValue_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            GoalControlEventsClass.GoalProgressValueTextBox_KeyDown(e);
        }

        private void GoalProgress_ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GoalControlEventsClass.GoalProgressBar_ValueChanged(GoalProgress_ProgressBar);
        }

        private void GoalTargetDate_DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            GoalControlEventsClass.UpdateGoal(GoalId, GoalTitle, GoalProgress, GoalTargetDate);
        }

        private void GoalTitle_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GoalControlEventsClass.UpdateGoal(GoalId, GoalTitle, GoalProgress, GoalTargetDate);
        }

        private void GoalProgressValue_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GoalControlEventsClass.UpdateGoal(GoalId, GoalTitle, GoalProgress, GoalTargetDate);
        }

        private void DeleteGoal_Button_Click(object sender, RoutedEventArgs e)
        {
            GoalControlEventsClass.DeleteGoal((WrapPanel)this.Parent, this, GoalId);
        }
    }
}
