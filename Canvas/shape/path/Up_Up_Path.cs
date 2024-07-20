using System;
using System.Collections.Generic;

namespace WinCanvas.Path {
    public class Up_Up_Path:BasePath {
        public override List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) {
            List<DrawLine> array = new List<DrawLine>();

            if( a1.left <= a2.right && diff.y > 0 ) {
                if( a1.right >= p2.x - this.length && a1.left - 10 < p2.x ) {
                    _debug("up|up|1");
                    double basex = a1.right + this.length;

                    array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                    array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                    array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
                } else {
                    _debug("up|up|2");
                    array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                    array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
                }
            } else if( a1.left > a2.right && diff.y > 0 ) {
                _debug("up|up|3");
                array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
            } else if( a1.left <= a2.right && diff.y < 0 ) {
                if( a1.right >= p2.x - this.length && a1.left - 10 < p2.x ) {
                    _debug("up|up|4");
                    double basex = a2.right + this.length;

                    array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                    array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                    array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
                } else {
                    _debug("up|up|5");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            } else if( a1.left > a2.right && diff.y < 0 ) {
                _debug("up|up|6");
                array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
            }       

            return array;            
        }

    }
}