using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WinCanvas {
    public class LineShape: BaseShape {
         public LineShape(double x1, double y1, double x2, double y2) {
            position = new DrawPosition(x1,y1);
            size = new DrawSize(Math.Abs(x2-x1), Math.Abs(y2-y1));
        }

        public override string getType() { return "line"; }
        public override void draw(Canvas canvas) {
            DrawArea area = new DrawArea(position, size);
            Line line = new Line();
            line.X1 = area.left;
            line.Y1 = area.top;
            line.X2 = area.right;
            line.Y2 = area.bottom;
            line.StrokeThickness = this.bordersize;
            line.Stroke = new SolidColorBrush(hex2color(this.bordercolor));
            canvas.Children.Add(line);
        }
    }
}