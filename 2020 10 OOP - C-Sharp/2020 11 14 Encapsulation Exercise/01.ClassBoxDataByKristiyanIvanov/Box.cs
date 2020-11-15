using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxDataByKristiyanIvanov
{
    public class Box
    {
        private const string INVALID_SIDE_EXC_MSG = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return this.length; }
            private set
            {
                ValidateSide(value, nameof(Length));
                this.length = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                ValidateSide(value, nameof(Width));
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                ValidateSide(value, nameof(Height));
                this.height = value;
            }
        }

        public double CalculateSurfaceArea() =>
                                             (2 * this.Length * this.Width)
                                           + CalculateLeteralSurfaceArea();

        public double CalculateLeteralSurfaceArea() =>
                                             (2 * this.Length * this.Height)
                                           + (2 * this.Width * this.Height);


        public double CalculateVolume() => this.Length * this.Width * this.Height;

        private void ValidateSide(double side, string sideType)
        {
            if (side <= 0)
            {
                throw new ArgumentException(String.Format
                    (INVALID_SIDE_EXC_MSG, sideType));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Surface Area - {this.CalculateSurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {this.CalculateLeteralSurfaceArea():f2}")
                .AppendLine($"Volume - {this.CalculateVolume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
