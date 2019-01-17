using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace EasyAnimation.Behaviors
{
    /// <summary>
    /// 透明度动画行为
    /// </summary>
    public class OpacityAnimationBehavior : DoubleAnimationBehaviorBase
    {
        protected override void OnAttached()
        {
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        protected override void Start()
        {
            if (AssociatedObject == null) return;
            DoubleAnimation aniOpacity = new DoubleAnimation();
            aniOpacity.From = From;
            aniOpacity.To = To;
            aniOpacity.FillBehavior = FillBehavior;
            aniOpacity.RepeatBehavior = RepeatBehavior;
            aniOpacity.Duration = Duration;
            aniOpacity.EasingFunction = EasingFunction;
            aniOpacity.Completed += (s, e) => { this.AnimationCompleted?.Execute(null); };
            (this.AssociatedObject as UIElement)?.BeginAnimation(UIElement.OpacityProperty, aniOpacity);
        }

    }
}
