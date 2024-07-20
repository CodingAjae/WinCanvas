using System;
using System.Collections.Generic;

namespace WinCanvas.Path {
    public class Left_Down_Path:BasePath {
        public override List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) {
            List<DrawLine> array = new List<DrawLine>();

            if( diff.x >= 0 && a1.bottom <= a2.bottom ) {
                if( p1.x > a2.left ) {
                    _debug("left|down|1");
                    double basex = a2.left - 5;
                    array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                    array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                    array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
                } else {
                    _debug("left|down|2");
                    array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            } else if( diff.x < 0 && p1.y <= p2.y ) {
                if( p1.x > a2.left && p1.x < a2.right +5 ) {
                   _debug("left|down|3");
                     double basex = a2.left - 5;
                    array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                    array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                    array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
                } else {
                   _debug("left|down|4");
                     array.Add(new DrawLine(p1.x, p1.y, p1.x, p2.y));
                    array.Add(new DrawLine(p1.x, p2.y, p2.x, p2.y));
                }
            } else if( diff.x >= 0 && a1.bottom > a2.bottom ) {
                _debug("left|down|5");
                double basey = a1.top - Math.Abs(a1.top-a2.bottom)/2;
                if( a1.bottom > a2.bottom && a1.top < p2.y ) {
                    basey = a1.bottom + this.length;
                } else if( basey <= p2.y ) {
                    basey = p2.y;
                }

                array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));

            } else if( diff.x < 0 && p1.y > p2.y ) {
                _debug("left|down|6");
                 array.Add(new DrawLine(p1.x, p1.y, p2.x, p1.y));
                array.Add(new DrawLine(p2.x, p1.y, p2.x, p2.y));
            }
            
            return array;            
        }

    }
}