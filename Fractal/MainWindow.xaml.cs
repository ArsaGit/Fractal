using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fractal
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{	
			InitializeComponent();
			
			double x0 = 50;
			double y0 = 50;
			DrawFractal(x0, y0, 800, 8);
		}

		public void DrawFractal(double x0, double y0, double length, int depth)
		{
			if (depth != 0)
			{
				DrawSquare(x0, y0, length, Brushes.Black);

				length /= 3;

				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						if (i == 1 && j == 1)
						{
							DrawSquare(x0 + length * i, y0 + length * j, length, Brushes.White);
						}
						else
						{
							DrawFractal(x0 + length * i, y0 + length * j, length, depth - 1);
						}
					}
				}
			}
			else depth++;
		}

		public void DrawSquare(double x0, double y0, double length, SolidColorBrush color)
		{
			Rectangle square = new();
			square.Width = length;
			square.Height = length;
			square.Fill = color;
			Canvas.SetLeft(square, x0);
			Canvas.SetTop(square, y0);
			canvas1.Children.Add(square);
		}
	}
}
