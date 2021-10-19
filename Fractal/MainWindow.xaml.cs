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
		private const string Source = "0.5,0.5,3.5";
		private int depth;

		public MainWindow()
		{
			//Fractal_2D();
			InitializeComponent();
		}

		public void Fractal_2D()
		{
			double x0 = 25;
			double y0 = 25;
			DrawFractal(x0, y0, 700, depth);
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

		private void depthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Label label = depthComboBox.SelectedItem as Label;

			int newDepth = int.Parse(label.Content.ToString());

			if (newDepth == depth) return;

			depth = newDepth;

			Fractal_2D();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			depthComboBox.SelectedIndex = 2;
		}
	}
}
