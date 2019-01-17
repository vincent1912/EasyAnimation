using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace EasyAnimation.Behaviors
{
    /// <summary>
    /// 动画行为基类
    /// </summary>
    public abstract class AnimationBehaviorBase : Behavior<DependencyObject>
    {
        /// <summary>
        /// 设为true以启动动画
        /// </summary>
        public bool IsStart
        {
            get { return (bool)GetValue(IsStartProperty); }
            set { SetValue(IsStartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsStart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsStartProperty =
            DependencyProperty.Register("IsStart", typeof(bool), typeof(AnimationBehaviorBase), new PropertyMetadata(false, (s, e) =>
            {
                AnimationBehaviorBase anib = s as AnimationBehaviorBase;
                if (anib.IsStart)
                {
                    anib.Start();
                }
            }));

        /// <summary>
        /// 获取或设置动画时长
        /// </summary> 
        public Duration Duration
        {
            get { return (Duration)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Duration.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(Duration), typeof(AnimationBehaviorBase), new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(800))));
         
        public FillBehavior FillBehavior
        {
            get { return (FillBehavior)GetValue(FillBehaviorProperty); }
            set { SetValue(FillBehaviorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FillBehavior.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillBehaviorProperty =
            DependencyProperty.Register("FillBehavior", typeof(FillBehavior), typeof(AnimationBehaviorBase), new PropertyMetadata(FillBehavior.HoldEnd));
         

        public RepeatBehavior RepeatBehavior
        {
            get { return (RepeatBehavior)GetValue(RepeatBehaviorProperty); }
            set { SetValue(RepeatBehaviorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RepeatBehavior.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RepeatBehaviorProperty =
            DependencyProperty.Register("RepeatBehavior", typeof(RepeatBehavior), typeof(AnimationBehaviorBase), new PropertyMetadata(new RepeatBehavior(1)));



        public IEasingFunction EasingFunction
        {
            get { return (IEasingFunction)GetValue(EasingFunctionProperty); }
            set { SetValue(EasingFunctionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EasingFunction.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EasingFunctionProperty =
            DependencyProperty.Register("EasingFunction", typeof(IEasingFunction), typeof(AnimationBehaviorBase), new PropertyMetadata(new QuarticEase() { EasingMode = EasingMode.EaseOut }));



        public ICommand AnimationCompleted
        {
            get { return (ICommand)GetValue(AnimationCompletedProperty); }
            set { SetValue(AnimationCompletedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AnimationCompleted.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnimationCompletedProperty =
            DependencyProperty.Register("AnimationCompleted", typeof(ICommand), typeof(AnimationBehaviorBase), new PropertyMetadata(null));



        /// <summary>
        /// 启动动画
        /// </summary>
        protected abstract void Start();
    }
}
