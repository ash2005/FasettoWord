
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Fasetto.Word.Animation
{
    /// <summary>
    /// helpers to animate pages in specific ways
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            // create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            // Add fade animation
            sb.AddFadeIn(seconds);

            // start animating
            sb.Begin(page);

            // make the page visible
            page.Visibility = Visibility.Visible;

            // wait for it until finish
            await Task.Delay((int) (seconds * 1000));

        }

        /// <summary>
        /// Slides a page out to the left
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            // create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            // Add fade animation
            sb.AddFadeOut(seconds);

            // start animating
            sb.Begin(page);

            // make the page visible
            page.Visibility = Visibility.Visible;

            // wait for it until finish
            await Task.Delay((int)(seconds * 1000));

        }

    }


}
