using System;
using System.Collections.Generic;

namespace WinCanvas.Path {
    public class Down_Right_Path:BasePath {
        public override List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) {
            List<DrawLine> array = new List<DrawLine>();

            if( a1.left <= a2.right && p1.y <= a2.top ) {
                if( p1.x < p2.x ) {
                    _debug("down|right|1");
                    array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                    array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
                } else {
                    _debug("down|right|2");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            } else if( a1.left > a2.right && p1.y <= a2.top ) {
                _debug("down|right|3");
                array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
            } else if( a1.left <= a2.right && p1.y > a2.top ) {
                if( a1.right < p2.x - this.length ) {
                    _debug("down|right|4");
                    double basey = a2.bottom + this.length;
                    if( p1.y >= basey ) {
                        basey = p1.y;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                    array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
                } else {
                    _debug("down|right|5");
                    double basex = a1.right + this.length;

                    array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                    array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                    array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
                }
            } else if( a1.left > a2.right && p1.y > a2.top) {
                _debug("down|right|6");
                double basex = a1.right + this.length;
                if( a1.left > p2.x + this.length ) {
                    basex = p2.x + Math.Abs(a1.left - p2.x - this.length)/2;
                }

                array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
            }
            
            return array;            
        }

    }
}