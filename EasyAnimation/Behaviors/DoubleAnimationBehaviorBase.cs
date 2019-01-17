using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyAnimation.Behaviors
{
    public abstract class DoubleAnimationBehaviorBase : AnimationBehaviorBase
    { 
        public double? From
        {
            get => (double?)GetValue(FromProperty);
            set => SetValue(FromProperty, value);
        }

        // Using a DependencyProperty as the backing store for From.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FromProperty =
            DependencyProperty.Register("From", typeof(double?), typeof(DoubleAnimationBehaviorBase), new PropertyMetadata(null));


        public double? To
        {
            get { return (double?)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        // Using a DependencyProperty as the backing store for From.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToProperty =
            DependencyProperty.Register("To", typeof(double?), typeof(DoubleAnimationBehaviorBase), new PropertyMetadata(null));
    }
}
