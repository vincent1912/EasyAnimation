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
    /// 缩放变换行为
    /// </summary>
    public class ScaleTransformBehavior : DoubleAnimationBehaviorBase
    { 
        public double ScaleX
        {
            get { return (double)GetValue(ScaleXProperty); }
            set { SetValue(ScaleXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScaleX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScaleXProperty =
            DependencyProperty.Register("ScaleX", typeof(double), typeof(ScaleTransformBehavior), new PropertyMetadata(1.0));
         
        public double ScaleY
        {
            get { return (double)GetValue(ScaleYProperty); }
            set { SetValue(ScaleYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScaleY.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScaleYProperty =
            DependencyProperty.Register("ScaleY", typeof(double), typeof(ScaleTransformBehavior), new PropertyMetadata(1.0));
         
        protected override void Start()
        {
            if (AssociatedObject == null) return; 
            
            DoubleAnimation aniX = new DoubleAnimation(); 
            aniX.To = this.ScaleX;
            aniX.Duration = this.Duration;
            aniX.FillBehavior = this.FillBehavior;
            aniX.RepeatBehavior = this.RepeatBehavior; 
            aniX.EasingFunction = this.EasingFunction;

            DoubleAnimation aniY = new DoubleAnimation();
            aniY.To = this.ScaleY;
            aniY.Duration = this.Duration;
            aniY.FillBehavior = this.FillBehavior;
            aniY.RepeatBehavior = this.RepeatBehavior;
            aniY.EasingFunction = this.EasingFunction;
            aniY.Completed += (s, e) => { AnimationCompleted?.Execute(null); };
            (AssociatedObject as ScaleTransform).BeginAnimation(ScaleTransform.ScaleXProperty, aniX);
            (AssociatedObject as ScaleTransform).BeginAnimation(ScaleTransform.ScaleYProperty, aniY);
        }
    }
}
