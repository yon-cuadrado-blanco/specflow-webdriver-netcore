namespace WebDriverHelper.Extensions
{
    using System.Linq;

    /// <summary>
    /// The element Extensions class.
    /// </summary>
    public static partial class ElementExtensions
    {
        /// <summary>
        /// The To color extension.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>The color in Color type.</returns>
        public static System.Drawing.Color ToColor(this string color)
        {
            var arrColorFragments = color?.Split(',').Select(sFragment =>
            {
                int.TryParse(sFragment, out int fragment);
                return fragment;
            }).ToArray();

            return arrColorFragments?.Length switch
            {
                3 => System.Drawing.Color.FromArgb(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2]),
                4 => System.Drawing.Color.FromArgb(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2], arrColorFragments[3]),
                _ => System.Drawing.Color.Transparent,
            };
        }
    }
}
