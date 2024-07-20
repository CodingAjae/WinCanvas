using System;
using System.Collections.Generic;

namespace WinCanvas.Path {
    public class Right_Left_Path:BasePath {
        public override List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) {
            List<DrawLine> array = new List<DrawLine>();
 
            double basex = p1.x + Math.Abs(p1.x-a2.left+this.length)/2;
            if( diff.x >= 0 && diff.y >= 0 ) {
                _debug("right|left|1");
                array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
            } else if( diff.x >= 0 && diff.y < 0 ) {
                _debug("right|left|2");
                array.Add(new DrawLine(p1.x, p1.y, basex, p1.y));
                array.Add(new DrawLine(basex, p1.y, basex, p2.y));
                array.Add(new DrawLine(basex, p2.y, p2.x, p2.y));
            } else if( diff.x < 0 && diff.y >= 0 ) {
                _debug("right|left|3");
                double basey = a1.bottom + Math.Abs(a1.bottom-a2.top)/2;
                if( Math.Abs(diff.x) <= this.length) {
                    basey = p1.y + (p2.y - p1.y)/2;
                } else if( Math.Abs(a1.bottom-a2.top) <= this.length || (basey > a2.top && basey < a2.bottom ) ) {
                    basey = a1.top - this.length;
                }

                array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
            } else if( diff.x < 0 && diff.y < 0 ) {
                _debug("right|left|4");
                double basey = a2.bottom + Math.Abs(a1.top - a2.bottom)/2;
                if( Math.Abs(diff.x) <= this.length) {
                    basey = p1.y + (p2.y - p1.y)/2;
                } else if( Math.Abs(a1.top - a2.bottom) <= this.length || (a1.top > a2.top && a1.top < a2.bottom )) {
                    basey = a1.bottom + this.length;
                }

                array.Add(new DrawLine(p1.x, p1.y, p1.x, basey));
                array.Add(new DrawLine(p1.x, basey, p2.x, basey));
                array.Add(new DrawLine(p2.x, basey, p2.x, p2.y));
            }
                       
            return array;            
        }

    }
}