using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabber_Goals.Component.Goal_Component
{
    public interface IGoalComponent
    {
        int GoalId { get; set; }
        string GoalTitle { get; set; }
        int GoalProgress { get; set; }
        DateTime GoalTargetDate { get; set; }
    }
}
