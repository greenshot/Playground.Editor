﻿//  Dapplo - building blocks for desktop applications
//  Copyright (C) 2016-2017 Dapplo
// 
//  For more information see: http://dapplo.net/
//  Dapplo repositories are hosted on GitHub: https://github.com/dapplo
// 
//  This file is part of Playground.Editor
// 
//  Playground.Editor is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  Playground.Editor is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have a copy of the GNU Lesser General Public License
//  along with Playground.Editor. If not, see <http://www.gnu.org/licenses/lgpl.txt>.

#region using

using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

#endregion

namespace Playground.Editor.Shapes
{
    public class Line : Shape
    {
        #region Private Methods and Members

        protected Geometry CachedGeometry;

        #endregion

        #region Constructors 

        /// <summary>
        ///     Instantiates a new instance of a line.
        /// </summary>
        public Line()
        {
            Stroke = Brushes.Green;
            StrokeThickness = 3;
            StrokeLineJoin = PenLineJoin.Round;
            StrokeStartLineCap = PenLineCap.Flat;
            StrokeEndLineCap = PenLineCap.Flat;
            Fill = Brushes.YellowGreen;

            // Test with a shadow effect
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

        #region Protected Methods and Properties

        /// <summary>
        ///     Get the line that defines this shape
        /// </summary>
        protected override Geometry DefiningGeometry
        {
            get
            {
                if (CachedGeometry == null)
                {
                    CacheDefiningGeometry();
                }
                return CachedGeometry;
            }
        }

        #endregion

        #region Dynamic Properties

        /// <summary>
        ///     X1 property
        /// </summary>
        public static readonly DependencyProperty X1Property =
            DependencyProperty.Register("X1", typeof(double), typeof(Line),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender),
                IsDoubleFinite);

        /// <summary>
        ///     X1 property
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        public double X1
        {
            get { return (double) GetValue(X1Property); }
            set { SetValue(X1Property, value); }
        }

        /// <summary>
        ///     Y1 property
        /// </summary>
        public static readonly DependencyProperty Y1Property =
            DependencyProperty.Register("Y1", typeof(double), typeof(Line),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender),
                IsDoubleFinite);

        /// <summary>
        ///     Y1 property
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        public double Y1
        {
            get { return (double) GetValue(Y1Property); }
            set { SetValue(Y1Property, value); }
        }

        /// <summary>
        ///     X2 property
        /// </summary>
        public static readonly DependencyProperty X2Property =
            DependencyProperty.Register("X2", typeof(double), typeof(Line),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender),
                IsDoubleFinite);

        /// <summary>
        ///     X2 property
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        public double X2
        {
            get { return (double) GetValue(X2Property); }
            set { SetValue(X2Property, value); }
        }

        /// <summary>
        ///     Y2 property
        /// </summary>
        public static readonly DependencyProperty Y2Property =
            DependencyProperty.Register("Y2", typeof(double), typeof(Line),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender),
                IsDoubleFinite);

        /// <summary>
        ///     Y2 property
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        public double Y2
        {
            get { return (double) GetValue(Y2Property); }
            set { SetValue(Y2Property, value); }
        }

        #endregion Dynamic Properties

        #region Internal Methods

        protected virtual void CacheDefiningGeometry()
        {
            Point point1 = new Point(X1, Y1);
            Point point2 = new Point(X2, Y2);

            // Create the Line geometry
            CachedGeometry = new LineGeometry(point1, point2);
        }

        private static bool IsDoubleFinite(object o)
        {
            double d = (double) o;
            return !double.IsInfinity(d) && !double.IsNaN(d);
        }

        #endregion Internal Methods
    }
}