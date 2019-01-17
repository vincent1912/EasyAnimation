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
    /// 平移变换行为
    /// </summary>
    public class TranslateTransformBehavior : DoubleAnimationBehaviorBase
    {
        public double? X
        {
            get { return (double?)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OffsetX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double?), typeof(TranslateTransformBehavior), new PropertyMetadata(null));



        public double? Y
        {
            get { return (double?)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OffsetY.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double?), typeof(TranslateTransformBehavior), new PropertyMetadata(null));
                

        protected override void Start()
        {
            if (AssociatedObject == null) return; 
            
            DoubleAnimation aniX = new DoubleAnimation(); 
            aniX.To = this.X;
            aniX.Duration = this.Duration;
            aniX.FillBehavior = this.FillBehavior;
            aniX.RepeatBehavior = this.RepeatBehavior; 
            aniX.EasingFunction = this.EasingFunction;
            DoubleAnimation aniY = new DoubleAnimation();
            aniY.To = this.Y;
            aniY.Duration = this.Duration;
            aniY.FillBehavior = this.FillBehavior;
            aniY.RepeatBehavior = this.RepeatBehavior;
            aniY.EasingFunction = this.EasingFunction;
            aniY.Completed += (s, e) => { AnimationCompleted?.Execute(null); };
            (AssociatedObject as TranslateTransform).BeginAnimation(TranslateTransform.XProperty, aniX);
            (AssociatedObject as TranslateTransform).BeginAnimation(TranslateTransform.YProperty, aniY);
        }
    }
}
