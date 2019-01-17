using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace EasyAnimation.AttachAnimations
{
    /// <summary>
    /// 元素透明度附加动画
    /// </summary>
    public sealed class OpacityAttachAnimation : DependencyObject
    {
        static void OnStartValueChanged(DependencyObject obj,DependencyPropertyChangedEventArgs args)
        {
            DoubleAnimation aniOpacity = new DoubleAnimation();
            aniOpacity.From = GetFromDouble(obj);
            aniOpacity.To = GetToDouble(obj);
            aniOpacity.Duration = GetDuration(obj);
            aniOpacity.FillBehavior = GetFillBehavior(obj);
            aniOpacity.RepeatBehavior = GetRepeatBehavior(obj);
            aniOpacity.By = GetByDouble(obj);
            aniOpacity.IsAdditive = GetIsAdditive(obj);
            aniOpacity.EasingFunction = GetEasingFunction(obj);
            aniOpacity.Completed += (s, e) => { GetAnimationCompleted(obj)?.Execute(null); };
            (obj as UIElement)?.BeginAnimation(UIElement.OpacityProperty, aniOpacity); 
        }

        #region IsStart
        public static bool GetIsStart(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsStartProperty);
        }

        public static void SetIsStart(DependencyObject obj, bool value)
        {
            obj.SetValue(IsStartProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsStart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsStartProperty =
            DependencyProperty.RegisterAttached("IsStart", typeof(bool), typeof(OpacityAttachAnimation), new PropertyMetadata(false, (s, e) =>
            {
                OnStartValueChanged(s, e);
            }));
        #endregion

        #region 动画参数

        #region From.Double


        public static double? GetFromDouble(DependencyObject obj)
        {
            return (double?)obj.GetValue(FromDoubleProperty);
        }

        public static void SetFromDouble(DependencyObject obj, double? value)
        {
            obj.SetValue(FromDoubleProperty, value);
        }

        // Using a DependencyProperty as the backing store for FromDouble.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FromDoubleProperty =
            DependencyProperty.RegisterAttached("FromDouble", typeof(double?), typeof(OpacityAttachAnimation), new PropertyMetadata(null));


        #endregion

        #region To.Double 
        public static double? GetToDouble(DependencyObject obj)
        {
            return (double?)obj.GetValue(ToDoubleProperty);
        }

        public static void SetToDouble(DependencyObject obj, double? value)
        {
            obj.SetValue(ToDoubleProperty, value);
        }

        // Using a DependencyProperty as the backing store for ToDouble.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToDoubleProperty =
            DependencyProperty.RegisterAttached("ToDouble", typeof(double?), typeof(OpacityAttachAnimation), new PropertyMetadata(null));


        #endregion

        #region By.Double


        public static double? GetByDouble(DependencyObject obj)
        {
            return (double?)obj.GetValue(ByDoubleProperty);
        }

        public static void SetByDouble(DependencyObject obj, double? value)
        {
            obj.SetValue(ByDoubleProperty, value);
        }

        // Using a DependencyProperty as the backing store for ByDouble.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ByDoubleProperty =
            DependencyProperty.RegisterAttached("ByDouble", typeof(double?), typeof(OpacityAttachAnimation), new PropertyMetadata(null));


        #endregion
         
        public static bool GetIsAdditive(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsAdditiveProperty);
        }

        public static void SetIsAdditive(DependencyObject obj, bool value)
        {
            obj.SetValue(IsAdditiveProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsAdditive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAdditiveProperty =
            DependencyProperty.RegisterAttached("IsAdditive", typeof(bool), typeof(OpacityAttachAnimation), new PropertyMetadata(true));
         

        #region Duration 
        public static Duration GetDuration(DependencyObject obj)
        {
            return (Duration)obj.GetValue(DurationProperty);
        }

        public static void SetDuration(DependencyObject obj, Duration value)
        {
            obj.SetValue(DurationProperty, value);
        }

        // Using a DependencyProperty as the backing store for Duration.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.RegisterAttached("Duration", typeof(Duration), typeof(OpacityAttachAnimation), new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(300))));


        #endregion

        #region FillBehavior
         
        public static FillBehavior GetFillBehavior(DependencyObject obj)
        {
            return (FillBehavior)obj.GetValue(FillBehaviorProperty);
        }

        public static void SetFillBehavior(DependencyObject obj, FillBehavior value)
        {
            obj.SetValue(FillBehaviorProperty, value);
        }

        // Using a DependencyProperty as the backing store for FillBehavior.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillBehaviorProperty =
            DependencyProperty.RegisterAttached("FillBehavior", typeof(FillBehavior), typeof(OpacityAttachAnimation), new PropertyMetadata(FillBehavior.HoldEnd));


        #endregion

        #region RepeatBehavior

        public static RepeatBehavior GetRepeatBehavior(DependencyObject obj)
        {
            return (RepeatBehavior)obj.GetValue(RepeatBehaviorProperty);
        }

        public static void SetRepeatBehavior(DependencyObject obj, RepeatBehavior value)
        {
            obj.SetValue(RepeatBehaviorProperty, value);
        }

        // Using a DependencyProperty as the backing store for RepeatBehavior.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RepeatBehaviorProperty =
            DependencyProperty.RegisterAttached("RepeatBehavior", typeof(RepeatBehavior), typeof(OpacityAttachAnimation), new PropertyMetadata(new RepeatBehavior(1)));


        #endregion

        #region IEasingFunction
         
        public static IEasingFunction GetEasingFunction(DependencyObject obj)
        {
            return (IEasingFunction)obj.GetValue(EasingFunctionProperty);
        }

        public static void SetEasingFunction(DependencyObject obj, IEasingFunction value)
        {
            obj.SetValue(EasingFunctionProperty, value);
        }

        // Using a DependencyProperty as the backing store for EasingFunction.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EasingFunctionProperty =
            DependencyProperty.RegisterAttached("EasingFunction", typeof(IEasingFunction), typeof(OpacityAttachAnimation), new PropertyMetadata(new QuarticEase() { EasingMode = EasingMode.EaseOut }));


        #endregion
        #endregion

        #region 动画完成命令
        public static ICommand GetAnimationCompleted(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(AnimationCompletedProperty);
        }

        public static void SetAnimationCompleted(DependencyObject obj, ICommand value)
        {
            obj.SetValue(AnimationCompletedProperty, value);
        }

        // Using a DependencyProperty as the backing store for AnimationCompleted.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnimationCompletedProperty =
            DependencyProperty.RegisterAttached("AnimationCompleted", typeof(ICommand), typeof(OpacityAttachAnimation), new PropertyMetadata(null));

        #endregion

    }
}
