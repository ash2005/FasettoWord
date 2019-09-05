

using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Fasetto.Word.Animation
{
    /// <summary>
    /// Animation helpers for <see cref="Storyboard"/>
    /// </summary>
    public static class StoreBoardHelpers
    {
        /// <summary>
        /// Adds a slide and fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The Storyboard to add the animation to</param>
        /// <param name="seconds">the time the animation will take</param>
        /// <param name="offset">the distance to the right to start from </param>
        /// <param name="decelerationRatio">the Rate of deceleration</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset,
            float decelerationRatio = 0.9f)
        {
            // create the margin animate from right
            var animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio,
            };
            //set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            // add this ot the storyboard
            storyboard.Children.Add(animation);

        }

        /// <summary>
        /// Adds a slide to Left animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The Storyboard to add the animation to</param>
        /// <param name="seconds">the time the animation will take</param>
        /// <param name="offset">the distance to the right to start from </param>
        /// <param name="decelerationRatio">the Rate of deceleration</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset,
            float decelerationRatio = 0.9f)
        {
            // create the margin animate from right
            var animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio,
            };
            //set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            // add this ot the storyboard
            storyboard.Children.Add(animation);

        }

        /// <summary>
        /// Adds fade in animation 
        /// </summary>
        /// <param name="storyboard">The Storyboard to add the animation to</param>
        /// <param name="seconds">the time the animation will take</param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            // create the margin animate from right
            var animation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
            };
            //set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // add this ot the storyboard
            storyboard.Children.Add(animation);

        }
        /// <summary>
        /// Adds fade out animation 
        /// </summary>
        /// <param name="storyboard">The Storyboard to add the animation to</param>
        /// <param name="seconds">the time the animation will take</param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            // create the margin animate from right
            var animation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };
            //set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // add this ot the storyboard
            storyboard.Children.Add(animation);

        }
    }
}
