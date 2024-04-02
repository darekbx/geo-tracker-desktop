using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop.utils
{
    internal static class SpeedToColor
    {
        public static Color toColor(double speed)
        {
            const double maxSpeed = 10.0;

            // Ensure speed is within the valid range (0 to maxSpeed)
            speed = Math.Max(0, Math.Min(speed, maxSpeed));

            // Map speed to the range 0 to 1
            double normalizedSpeed = speed / maxSpeed;

            // Map normalized speed to a color gradient from blue to red
            int blue = (int)(255 * (1 - normalizedSpeed));
            int red = (int)(255 * normalizedSpeed);
            int green = 0; // No green component

            // Create and return the corresponding color
            return Color.FromArgb(red, green, blue);
        }
    }
}
