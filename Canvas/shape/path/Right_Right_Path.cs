using System;
using System.Collections.Generic;

namespace WinCanvas.Path {
    public class Right_Right_Path:BasePath {
        public override List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) {
            List<DrawLine> array = new List<DrawLine>();
  
            if( diff.x >= 0 && diff.y >= 0 ) {
                if( p1.x >= a2.left-5) {
                    _debug("right|right|1");
                    array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                    array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
                } else if( p1.y >= a2.top ) {
                    _debug("right|right|2");
                    double basex = p1.x + Math.Abs(p1.x - a2.left + this.length)/2;
                    double basey = a2.top - this.length;
                    if( basex >= a2.left - this.length ) {
                        basex = p1.x;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                    array.Add(new DrawLine(basex, p1.y, basex, basey));
                    array.Add(new DrawLine(basex, basey, p2.x, basey));
                    array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
                } else {
                    _debug("right|right|3");
                    array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                    array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
                }
            } else if( diff.x >= 0 && diff.y < 0 ) {
                if( p1.x >= a2.left-5) {
                    _debug("right|right|4");
                    array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                    array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
                } else if( p1.y >= p2.y && p1.y <= a2.bottom ) {
                    _debug("right|right|5");
                    double basex = p1.x + Math.Abs(p1.x - a2.left + this.length)/2;
                    double basey = a2.bottom + this.length;
                    if( basex >= a2.left - this.length ) {
                        basex = p1.x;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                    array.Add(new DrawLine(basex, p1.y, basex, basey));
                    array.Add(new DrawLine(basex, basey, p2.x, basey));
                    array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
                } else {
                    _debug("right|right|6");
                    array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                    array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
                }
            } else if( diff.x < 0 && diff.y >= 0 ) {
                if( p2.x >= a1.left-5) {
                    _debug("right|right|7");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                } else if( p1.y >= a2.top ) {
                    _debug("right|right|8");
                    double basex = p2.x + Math.Abs(p2.x - a1.left + this.length)/2;
                    double basey = a2.bottom + this.length;
                    if( basex >= a1.left - this.length ) {
                        basex = p2.x;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, basex, basey));
                    array.Add(new DrawLine(basex, basey, basex, p2.y));
                    array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
                } else {
                    _debug("right|right|9");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            } else if( diff.x < 0 && diff.y < 0 ) {
                if( p2.x >= a1.left-5) {
                    _debug("right|right|10");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                } else if( p1.y >= p2.y && p1.y <= a2.bottom ) {
                    _debug("right|right|11");
                    double basex = p2.x + Math.Abs(p2.x - a1.left + this.length)/2;
                    double basey = a2.top - this.length;
                    if( basex >= a1.left - this.length ) {
                        basex = p2.x;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, basex, basey));
                    array.Add(new DrawLine(basex, basey, basex, p2.y));
                    array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
                } else {
                    _debug("right|right|12");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            }  

            return array;
        }

    }
}