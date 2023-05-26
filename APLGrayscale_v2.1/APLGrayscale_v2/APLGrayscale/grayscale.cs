using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLGrayscale
{
    class Grayscale
    {
		public struct HSV
		{
			private double _h;
			private double _s;
			private double _v;

			public HSV(double h, double s, double v)
			{
				this._h = h;
				this._s = s;
				this._v = v;
			}

			public double H
			{
				get { return this._h; }
				set { this._h = value; }
			}

			public double S
			{
				get { return this._s; }
				set { this._s = value; }
			}

			public double V
			{
				get { return this._v; }
				set { this._v = value; }
			}

			public bool Equals(HSV hsv)
			{
				return (this.H == hsv.H) && (this.S == hsv.S) && (this.V == hsv.V);
			}

		}

		public struct SelectColor
		{
			private String _name;
			private int _lowerBoundary;
			private int _upperBoundary;

			public SelectColor(String name, int lowerBoundary, int upperBoundary)
			{
				this._name = name;
				this._lowerBoundary = lowerBoundary;
				this._upperBoundary = upperBoundary;
			}

			public String Name
			{
				get { return this._name; }
				set { this._name = value; }
			}

			public int LowerBoundary
			{
				get { return this._lowerBoundary; }
				set { this._lowerBoundary = value; }
			}

			public int UpperBoundary
			{
				get { return this._upperBoundary; }
				set { this._upperBoundary = value; }
			}
		}

		readonly SelectColor[] colors = new SelectColor[7]{ new SelectColor("RED", 0, 20),
															new SelectColor("ORANGE", 20, 40),
															new SelectColor("YELLOW", 40, 65),
															new SelectColor("GREEN", 65, 160),
															new SelectColor("BLUE", 160, 250),
															new SelectColor("PURPLE", 250, 290),
															new SelectColor("PINK", 290, 350)};



		public static HSV RGBToHSV(byte R, byte G, byte B)
		{
			double delta, min;
			double h = 0, s, v;

			min = Math.Min(Math.Min(R, G), B);
			v = Math.Max(Math.Max(R, G), B);
			delta = v - min;

			if (v == 0.0)
				s = 0;
			else
				s = delta / v;

			if (s == 0)
				h = 0.0;

			else
			{
				if (R == v)
					h = (G - B) / delta;
				else if (G == v)
					h = 2 + (B - R) / delta;
				else if (B == v)
					h = 4 + (R - G) / delta;

				h *= 60;

				if (h < 0.0)
					h = h + 360;
			}

			return new HSV(h, s, (v / 255));
		}

		public SelectColor chooseColor(String colorName)
		{
			foreach (SelectColor c in colors)
			{
				if (colorName == c.Name)
					return c;
			}

			return new SelectColor("BLACK", 0, 0);
		}

		public bool isVisible(SelectColor color, HSV pixel)
		{
			if (pixel.H >= color.LowerBoundary && pixel.H <= color.UpperBoundary)
				return true; //if true - alphaChannel = 1
			else
				return false; //if false - alphaChannel = 0
		}
	}
}
