using System;
using System.Collections.Generic;

namespace WinCanvas.Path {
    public class Up_Left_Path:BasePath {
        public override List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) {
            List<DrawLine> array = new List<DrawLine>();

            if( a1.right <= a2.right && a1.bottom <= a2.bottom ) {
                _debug("up|left|1");
                double basex = a1.right + Math.Abs(a1.right-a2.left)/2;
                if( basex > p2.x ) {
                    basex = a1.left-this.length;
                }

                array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
            } else if( a1.right > a2.right && a1.bottom <= a2.bottom  ) {
                _debug("up|left|2");
                array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
            } else if( a1.right <= a2.right && a1.bottom > a2.bottom ) {
                if( p1.x <= p2.x ) {
                    if( p1.y <= p2.y ) {
                        _debug("up|left|3");
                        array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                        array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
                    } else {
                        _debug("up|left|4");
                        array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                        array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                    }
                } else {
                    _debug("up|left|5");
                    double basey = a2.bottom + Math.Abs(p1.y-a2.bottom+this.length)/2;
                    if( basey > p1.y ) {
                        basey = p1.y;
                    }

                    array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                    array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                    array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
                }
            } else if( a1.right > a2.right && a1.bottom > a2.bottom  ) {
                _debug("up|left|6");
                double basey = a2.bottom + Math.Abs(p1.y-a2.bottom+this.length)/2;

                if( p2.x < a2.right && p1.y > a2.top && p1.y < a2.bottom ) {
                    basey = a2.top - this.length;
                } else if( basey > p1.y ) {
                    basey = p1.y;
                }

                array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
            }

            return array;            
        }

    }
}