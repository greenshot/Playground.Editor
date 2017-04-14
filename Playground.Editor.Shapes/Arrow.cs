//  Dapplo - building blocks for desktop applications
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

using System;
using System.Windows;
using System.Windows.Media;

#endregion

namespace Playground.Editor.Shapes
{
    public class Arrow : Line
    {
        protected override void CacheDefiningGeometry()
        {
            Point startPoint = new Point(X1, Y1);
            Point endPoint = new Point(X2, Y2);

            var length = Math.Sqrt(Math.Pow(endPoint.Y - startPoint.Y, 2) + Math.Pow(endPoint.X - startPoint.X, 2));
            var f = length / 15d;

            var f2 = length / 30d;

            var arrowBase = new Point(endPoint.X - (endPoint.X - startPoint.X) / f2, endPoint.Y - (endPoint.Y - startPoint.Y) / f2);
            var arrowTip1 = new Point(arrowBase.X + (endPoint.Y - startPoint.Y) / f, arrowBase.Y - (endPoint.X - startPoint.X) / f);
            var arrowTip2 = new Point(arrowBase.X - (endPoint.Y - startPoint.Y) / f, arrowBase.Y + (endPoint.X - startPoint.X) / f);
            var arrowTipExt1 = new Point(arrowBase.X + (endPoint.Y - startPoint.Y) / f2, arrowBase.Y - (endPoint.X - startPoint.X) / f2);
            var arrowTipExt2 = new Point(arrowBase.X - (endPoint.Y - startPoint.Y) / f2, arrowBase.Y + (endPoint.X - startPoint.X) / f2);

            // Create PathFigure with start-point
            var arrow = new PathFigure(startPoint, new[] {new PolyLineSegment(new[] {arrowTip1, arrowTipExt1, endPoint, arrowTipExt2, arrowTip2}, true)}, true)
            {
                IsFilled = true
            };
            CachedGeometry = new PathGeometry(new[] {arrow}, FillRule.Nonzero, null);
        }
    }
}