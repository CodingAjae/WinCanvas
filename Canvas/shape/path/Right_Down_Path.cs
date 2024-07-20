using System;
using System.Collections.Generic;

namespace WinCanvas.Path {
    public class Right_Down_Path:BasePath {
        public override List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) {
            List<DrawLine> array = new List<DrawLine>();

            if( diff.x >= 0 && diff.y > 0 ) {
                _debug("right|down|1");
                double basex = p1.x + Math.Abs(p1.x-a2.left+this.length)/2;
                if( p1.x-a2.left+this.length > 0 && p1.x <= a2.left-5 ) {
                    basex = p1.x;
                } else if( p1.x >= a2.left-5) {
                    basex = a2.right + this.length;
                }

                array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
            } else if( diff.x > 0 && diff.y < 0 ) {
                _debug("right|down|2");
                array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
            } else if( diff.x < 0 && diff.y > 0 && p1.y < a2.bottom ) {
                double basex = a2.right + this.length;
                if( p1.x >= a2.left-5 && p1.x < a2.right )  {
                    _debug("right|down|3");
                    array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                    array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                    array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
                } else {
                    _debug("right|down|4");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            } else if( diff.x < 0 && p1.y >= a2.bottom ) {
                if( a1.bottom >= a2.bottom && a1.top < p2.y  ) {
                    _debug("right|down|5");
                    double basey = a1.bottom + this.length;

                    array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                    array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
                } else {
                    _debug("right|down|6");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            }

            return array;
        }

    }
}