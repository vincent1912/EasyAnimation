using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace EasyAnimation.Behaviors
{
    public class TimelinesBehavior : AnimationBehaviorBase
    { 
        public ObservableCollection<Timeline> Timelines
        {
            get { return (System.Collections.ObjectModel.ObservableCollection<Timeline>)GetValue(TimelinesProperty); }
            set { SetValue(TimelinesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Timelines.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimelinesProperty =
            DependencyProperty.Register("Timelines", typeof(System.Collections.ObjectModel.ObservableCollection<Timeline>), typeof(TimelinesBehavior), new PropertyMetadata(new ObservableCollection<Timeline>()));

        protected override void Start()
        {
            if (Timelines == null || !Timelines.Any()) return;
            Storyboard sb = new Storyboard();
            sb.RepeatBehavior = this.RepeatBehavior;
            sb.FillBehavior = this.FillBehavior;
            sb.Completed += (s, e) => 
            {
                AnimationCompleted?.Execute(null);
            };
            foreach (var item in Timelines)
            {
                if (Storyboard.GetTargetName(item) == null && Storyboard.GetTarget(item)==null)
                {
                    Storyboard.SetTarget(item, this.AssociatedObject);
                } 
                sb.Children.Add(item);
            }
            sb.Begin();
        }
    }
}
