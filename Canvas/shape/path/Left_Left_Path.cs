using System;
using System.Collections.Generic;

namespace WinCanvas.Path {
    public class Left_Left_Path:BasePath {
        public override List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) {
            List<DrawLine> array = new List<DrawLine>();
       
            if( diff.x >= 0 && diff.y >= 0 ) {
                if( p1.x >= a2.left-5) {
                    _debug("left|left|1");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                } else if( p1.y >= a2.top && a1.right <= p2.x ) {
                    _debug("left|left|2");
                    double basex = p1.x + Math.Abs(p1.x - a2.left + this.length)/2;
                    double basey = a2.top - this.length;
                    if( basex >= a2.left - this.length ) {
                        basex = p1.x;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, basex, basey));
                    array.Add(new DrawLine(basex, basey, p2.x, basey));
                    array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
                } else {
                    _debug("left|left|3");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            } else if( diff.x >= 0 && diff.y < 0 ) {
                if( p1.x >= a2.left-5) {
                    _debug("left|left|4");
                    array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                    array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
                } else if( p1.y >= p2.y && p1.y <= a2.bottom && a1.right <= p2.x) {
                    _debug("left|left|5");
                    double basex = p1.x + Math.Abs(p1.x - a2.left + this.length)/2;
                    double basey = a2.bottom + this.length;
                    if( basex >= a2.left - this.length ) {
                        basex = p1.x;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, basex, basey));
                    array.Add(new DrawLine(basex, basey, p2.x, basey));
                    array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
                } else {
                    _debug("left|left|6");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            } else if( diff.x < 0 && diff.y >= 0 ) {
                if( p2.x >= a1.left-5) {
                    _debug("left|left|7");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                } else if( p1.y >= a2.top && p1.x >= a2.right ) {
                    _debug("left|left|8");
                    double basex = p2.x + Math.Abs(p2.x - a1.left + this.length)/2;
                    double basey = a2.bottom + this.length;
                    if( basex >= a1.left - this.length ) {
                        basex = p2.x;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, basex, basey));
                    array.Add(new DrawLine(basex, basey, p2.x, basey));
                    array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
                } else {
                    _debug("left|left|9");
                    array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                    array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
                }
            } else if( diff.x < 0 && diff.y < 0 ) {
                if( p2.x >= a1.left-5) {
                    _debug("left|left|10");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                } else if( p1.y >= p2.y && p1.y <= a2.bottom  && p1.x >= a2.right ) {
                    _debug("left|left|11");
                    double basex = p2.x + Math.Abs(p2.x - a1.left + this.length)/2;
                    double basey = a2.top - this.length;
                    if( basex >= a1.left - this.length ) {
                        basex = p2.x;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, basex, basey));
                    array.Add(new DrawLine(basex, basey, p2.x, basey));
                    array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
                } else {
                    _debug("left|left|12");
                    array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                    array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
                }
            }

            return array;            
        }

    }
}