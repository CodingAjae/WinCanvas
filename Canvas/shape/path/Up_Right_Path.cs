using System;
using System.Collections.Generic;

namespace WinCanvas.Path {
    public class Up_Right_Path:BasePath {
        public override List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) {
            List<DrawLine> array = new List<DrawLine>();
            
            if( a1.right <= a2.right && a1.bottom <= a2.bottom ) {
                _debug("up|right|1");
                array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
            } else if( a1.right > a2.right && a1.bottom <= a2.bottom  ) {
                _debug("up|right|2");
                double basex = a1.right + this.length;
                if( a1.left >= p2.x ) {
                    basex = p2.x + Math.Abs(a1.left-p2.x-this.length)/2;
                }

                array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
            } else if( a1.right <= a2.right && a1.bottom > a2.bottom ) {
                _debug("up|right|3");
                double basey = a2.bottom + Math.Abs(a2.bottom-p1.y-this.length)/2;
                if( a1.top >= a2.top && p1.y <= a2.bottom ) {
                    basey = a2.top - this.length;
                } else if( basey >= p1.y ) {
                    basey = p1.y;
                }

                array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));

            } else if( a1.right > a2.right && a1.bottom > a2.bottom  ) {
                if( a1.top > a2.top && a1.top < a2.bottom ) {
                    _debug("up|right|4");
                    double basex = a1.right + this.length;
                    if( a1.left >= p2.x ) {
                        basex = p2.x + Math.Abs(a1.left-p2.x-this.length)/2;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                    array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                    array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
                } else if( p1.x < p2.x ) {
                    _debug("up|right|5");
                    array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                    array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
                } else {
                    _debug("up|right|6");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            }
            
            return array;            
        }

    }
}