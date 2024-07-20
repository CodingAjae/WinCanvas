using System;
using System.Collections.Generic;

namespace WinCanvas.Path {
    public class Up_Down_Path:BasePath {
        public override List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) {
            List<DrawLine> array = new List<DrawLine>();

            if( a1.left <= a2.right && diff.y >= 0 ) {
                _debug("up|down|1");
                double basex = a1.right + Math.Abs(a2.left - a1.right)/2;
                if( a1.right > a2.left && a1.left < a2.left ) {
                    basex = a2.right + this.length;
                } else if ( a1.left >= a2.left )  {
                    basex = a2.left - this.length;
                }

                array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
            } else if( a1.left > a2.right && diff.y >= 0  ) {
                _debug("up|down|2");
                double basex = a2.right + Math.Abs(a2.right - a1.left)/2;
                array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));

            } else if( a1.left <= a2.right && diff.y < 0 ) {
                _debug("up|down|3");
                double basey = a2.bottom + Math.Abs(a2.bottom-p1.y-this.length)/2;

                array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
            } else if( a1.left > a2.right && diff.y < 0 ) {
                _debug("up|down|4");
                double basey = a2.bottom + Math.Abs(a2.bottom-p1.y-this.length)/2;

                array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
            }
            
            return array;            
        }

    }
}