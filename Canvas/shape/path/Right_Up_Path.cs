using System;
using System.Collections.Generic;

namespace WinCanvas.Path {
    public class Right_Up_Path:BasePath {
        public override List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) {
            List<DrawLine> array = new List<DrawLine>();
     
            if( diff.x >= 0 && diff.y >= 0 ) {
               _debug("right|up|1");
                array.Add(new DrawLine(x1:p1.x, p1.y, p2.x, p1.y));
                array.Add(new DrawLine(x1:p2.x, p1.y, p2.x, p2.y));
            } else if( diff.x < 0 && diff.y >= 0 ) {
                _debug("right|up|2");
                double basey = a1.bottom + Math.Abs(a1.bottom-p2.y-this.length)/2;
                if( basey > p2.y) {
                    basey = a1.top - this.length;
                }

                array.Add(new DrawLine(p1.x, p1.y, p1.x,  basey));
                array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
            } else if( diff.x >= 0 && diff.y < 0 ) {
                _debug("right|up|3");
                double basex = p1.x + Math.Abs(p1.x + length-a2.left)/2;
                if( p1.x >= a2.left - 5 ) {
                    basex = a2.right + this.length;
                }

                array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
            } else if( diff.x < 0 && diff.y < 0 ) {
                if( p1.x >= a2.left - 5 && p1.x <= a2.right ) {
                    _debug("right|up|4");
                    double basex = a2.right + this.length;

                    array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                    array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                    array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
                } else if( p2.y > p1.y - this.length ) {
                    _debug("right|up|5");
                    double basey  = a1.top - this.length;

                    array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                    array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
                } else {
                    _debug("right|up|6");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            }   
     
            return array;            
        }

    }
}