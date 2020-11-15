using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
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
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                else
                {
                    this.length = value;
                }
            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                else
                {
                    this.width = value;
                }
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                else
                {
                    this.height = value;
                }
            }
        }

        public double CalculateSurfaceArea()
        {
            double surfaceArea = 2 * this.Length * this.Width
                               + 2 * this.Length * this.Height
                               + 2 * this.Width * this.Height;
            return surfaceArea;
        }

        public double CalculateLeteralSurfaceArea()
        {
            double leteralSurfaceArea = 2 * this.Length * this.Height
                                      + 2 * this.Width * this.Height;
            return leteralSurfaceArea;
        }

        public double CalculateVolume()
        {
            double volume = this.Length * this.Width * this.Height;
            return volume;
        }
    }
}