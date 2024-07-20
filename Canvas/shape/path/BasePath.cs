using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace WinCanvas {
    public class BasePath {
        public int length {get;set;} = 37;
        public string color {get;set;} = "#000000";

        public virtual List<DrawLine> path(DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2, DrawDiff diff) { return new List<DrawLine>(); }

        protected void _debug(string debug) {
            BroadcastArgs args = new BroadcastArgs();
            args.evttype = "_debug_path";
            args.debugmessage = debug;  
            BroadcastFactory.ExecuteBrtoadcast(args);
        }

        public Color hex2color(string str) {
           return (Color) ColorConverter.ConvertFromString(str);
        }
        
        private void _draw_line(Canvas canvas, DrawLine line) {
            Line l = new Line();
            l.X1 = line.x1;
            l.Y1 = line.y1;
            l.X2 = line.x2;
            l.Y2 = line.y2;
            l.StrokeThickness = 1;
            l.Stroke = new SolidColorBrush(hex2color(this.color));
            canvas.Children.Add(l);
        }

        public void draw(Canvas canvas, DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2) {
            List<DrawLine> lines = path(p1, p2, a1, a2, p1.calcDiff(p2));

            if( lines != null && lines.Count > 0 ) {
                foreach(DrawLine line in lines ) {
                    _draw_line(canvas, line);
                }
            }
        }       
    }
}