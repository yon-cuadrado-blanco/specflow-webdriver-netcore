namespace WebDriverHelper.Extensions
{
    using System.Drawing;

    /// <summary>
    /// The element extensions class.
    /// </summary>
    public static partial class ElementExtensions
    {
        /// <summary>
        /// Get the hex color value.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>hex color value.</returns>
        public static string GetHexColor(this Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }
    }
}
