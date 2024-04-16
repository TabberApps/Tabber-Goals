using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Tabber_Goals.TabberUI.Controls
{
    public partial class TabberWrapPanel : WrapPanel
    {
        // Event raised when a child control is added
        public event EventHandler<ChildChangedEventArgs> ChildAdded;

        // Event raised when a child control is removed
        public event EventHandler<ChildChangedEventArgs> ChildRemoved;

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);

            if (visualAdded != null)
            {
                // Raise the ChildAdded event
                ChildAdded?.Invoke(this, new ChildChangedEventArgs((UIElement)visualAdded, ChangeType.Added));
            }

            if (visualRemoved != null)
            {
                // Raise the ChildRemoved event
                ChildRemoved?.Invoke(this, new ChildChangedEventArgs((UIElement)visualRemoved, ChangeType.Removed));
            }
        }
    }

    public enum ChangeType
    {
        Added,
        Removed
    }

    public class ChildChangedEventArgs : EventArgs
    {
        public UIElement Child { get; }
        public ChangeType ChangeType { get; }

        public ChildChangedEventArgs(UIElement child, ChangeType changeType)
        {
            Child = child;
            ChangeType = changeType;
        }
    }
}
