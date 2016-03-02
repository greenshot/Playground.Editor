using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace Playground.Editor.Shapes
{
	public class Line : Shape
	{
		#region Constructors 

		/// <summary>
		/// Instantiates a new instance of a line. 
		/// </summary>
		public Line()
		{
			Stroke = Brushes.Green;
			StrokeThickness = 3;
			StrokeLineJoin = PenLineJoin.Round;
			StrokeStartLineCap = PenLineCap.Flat;
			StrokeEndLineCap = PenLineCap.Flat;
			Fill = Brushes.YellowGreen;

			Effect = new DropShadowEffect
			{
				RenderingBias = RenderingBias.Quality,
				Opacity = 0.8d,
				Color = Color.FromRgb(10, 10, 10),
				ShadowDepth = 20,
				BlurRadius = 10
			};
		}

		#endregion Constructors 

		#region Dynamic Properties

		/// <summary>
		/// X1 property
		/// </summary>
		public static readonly DependencyProperty X1Property =
			DependencyProperty.Register("X1", typeof(double), typeof(Line),
				new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender),
				new ValidateValueCallback(IsDoubleFinite));

		/// <summary> 
		/// X1 property
		/// </summary>
		[TypeConverter(typeof(LengthConverter))]
		public double X1
		{
			get
			{
				return (double)GetValue(X1Property);
			}
			set
			{
				SetValue(X1Property, value);
			}
		}

		/// <summary> 
		/// Y1 property
		/// </summary> 
		public static readonly DependencyProperty Y1Property =
			DependencyProperty.Register("Y1", typeof(double), typeof(Line),
				new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender),
				new ValidateValueCallback(IsDoubleFinite));

		/// <summary> 
		/// Y1 property 
		/// </summary>
		[TypeConverter(typeof(LengthConverter))]
		public double Y1
		{
			get
			{
				return (double)GetValue(Y1Property);
			}
			set
			{
				SetValue(Y1Property, value);
			}
		}

		/// <summary> 
		/// X2 property
		/// </summary> 
		public static readonly DependencyProperty X2Property =
			DependencyProperty.Register("X2", typeof(double), typeof(Line),
				new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender),
				new ValidateValueCallback(IsDoubleFinite));

		/// <summary>
		/// X2 property 
		/// </summary>
		[TypeConverter(typeof(LengthConverter))]
		public double X2
		{
			get
			{
				return (double)GetValue(X2Property);
			}
			set
			{
				SetValue(X2Property, value);
			}
		}

		/// <summary>
		/// Y2 property
		/// </summary>
		public static readonly DependencyProperty Y2Property =
			DependencyProperty.Register("Y2", typeof(double), typeof(Line),
				new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender),
				new ValidateValueCallback(IsDoubleFinite));

		/// <summary> 
		/// Y2 property
		/// </summary>
		[TypeConverter(typeof(LengthConverter))]
		public double Y2
		{
			get
			{
				return (double)GetValue(Y2Property);
			}
			set
			{
				SetValue(Y2Property, value);
			}
		}


		#endregion Dynamic Properties

		#region Protected Methods and Properties


		/// <summary> 
		/// Get the line that defines this shape
		/// </summary> 
		protected override Geometry DefiningGeometry
		{
			get
			{
				if (_cachedGeometry == null)
				{
					CacheDefiningGeometry();
				}
				return _cachedGeometry;
			}
		}

		#endregion

		#region Internal Methods
		internal virtual void CacheDefiningGeometry()
		{
			Point point1 = new Point(X1, Y1);
			Point point2 = new Point(X2, Y2);

			// Create the Line geometry
			_cachedGeometry = new LineGeometry(point1, point2);
		}

		internal static bool IsDoubleFinite(object o)
		{
			double d = (double)o;
			return (!double.IsInfinity(d) && !double.IsNaN(d));
		}

		#endregion Internal Methods

		#region Private Methods and Members

		protected Geometry _cachedGeometry;

		#endregion
	}

}
