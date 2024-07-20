using System;
using System.Collections.Generic;

namespace WinCanvas.Path {
    public class Down_Down_Path:BasePath {
        public override List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) {
            List<DrawLine> array = new List<DrawLine>();

            if( a1.left <= a2.right && diff.y > 0 ) {
                if( a1.right >= p2.x - this.length && a1.left - 10 < p2.x ) {
                    _debug("down|down|1");

                    double basex = a2.left - this.length;
                    double basey = p1.y + Math.Abs(a2.top - p1.y - this.length)/2;
                    if( a2.top - p1.y <  this.length ) {
                        basey = p1.y;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, basex, basey));
                    array.Add(new DrawLine(basex, basey, basex, p2.y));
                    array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
                } else {
                    _debug("down|down|2");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            } else if( a1.left > a2.right && diff.y > 0 ) {
                _debug("down|down|3");
                array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
            } else if( a1.left <= a2.right && diff.y < 0 ) {
                if( a1.right >= p2.x - this.length && a1.left - 10 < p2.x ) {
                    _debug("down|down|4");
                    double basex = a1.right + this.length;
                    double basey = p2.y + Math.Abs(a1.top - p2.y - this.length)/2;
                    if( a1.top - p2.y <  this.length ) {
                        basey = p2.y;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                    array.Add(new DrawLine(basex, p1.y, basex, basey));
                    array.Add(new DrawLine(basex, basey, p2.x, basey));
                    array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
                } else {
                    _debug("down|down|5");
                    array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                    array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
                }
            } else if( a1.left > a2.right && diff.y < 0 ) {
                _debug("down|down|6");
                array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
            }
            
            return array;            
        }

    }
}