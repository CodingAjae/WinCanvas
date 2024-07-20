using System;
using System.Collections.Generic;

namespace WinCanvas.Path {
    public class Left_Up_Path:BasePath {
        public override List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) {
            List<DrawLine> array = new List<DrawLine>();
    
            if( diff.x >= 0 && diff.y >= 0 ) {
                if( a1.bottom > p2.y && a1.left < a2.left ) {
                    _debug("left|up|1");
                    double basey = a1.top - this.length;

                    array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                    array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
                } else {
                    _debug("left|up|2");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            } else if( diff.x < 0 && diff.y >= 0 ) {
                _debug("left|up|3");
                array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
            } else if( diff.x >= 0 && diff.y < 0 ) {
                if( a1.bottom > p2.y && a1.top < a2.bottom  && p1.x < a2.left ) {
                    _debug("left|up|4");
                    double basey = a1.top - this.length;
                    if( basey > p2.y ) {
                        basey = p2.y;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                    array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
                } else if (a2.left < p1.x ) {
                    _debug("left|up|5");
                    double basex = a2.left -5;

                    array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                    array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                    array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
                } else {
                    _debug("left|up|6");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            } else if( diff.x < 0 && diff.y < 0 ) {
                if( p1.x < a2.right ) {
                    _debug("left|up|7");
                    double basex = a2.left -5;

                    array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                    array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                    array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
                } else {
                    _debug("left|up|8");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            }
                                    
            return array;            
        }

    }
}