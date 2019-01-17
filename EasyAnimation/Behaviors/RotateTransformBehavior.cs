using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace EasyAnimation.Behaviors
{
    /// <summary>
    /// 旋转变换行为
    /// </summary>
    public class RotateTransformBehavior : DoubleAnimationBehaviorBase
    { 
        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(RotateTransformBehavior), new PropertyMetadata(0.0));
 
        protected override void Start()
        {
            if (AssociatedObject == null) return; 
            
            DoubleAnimation ani = new DoubleAnimation();
            ani.To = this.Angle;
            ani.Duration = this.Duration;
            ani.FillBehavior = this.FillBehavior;
            ani.RepeatBehavior = this.RepeatBehavior;
            ani.EasingFunction = this.EasingFunction;
            
            ani.Completed += (s, e) => { AnimationCompleted?.Execute(null); };
            (AssociatedObject as RotateTransform).BeginAnimation(RotateTransform.AngleProperty, ani); 
        }
    }
}
