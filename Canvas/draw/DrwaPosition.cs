using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WinCanvas {

    public class DrawPosition {
        public double x { get; set; }
        public double y { get; set; }
        
        public DrawPosition() {
            this.x = 0.0;
            this.y = 0.0;
        }
        public DrawPosition(double x, double y) {
            this.x = x;
            this.y = y;
        }
        public DrawPosition(Canvas canvas) {
            Point point = Mouse.GetPosition(canvas);
            this.x = point.X;
            this.y = point.Y;
        }
        public DrawPosition(ScrollViewer scroll) {
            Point point = Mouse.GetPosition(scroll);
            this.x = point.X;
            this.y = point.Y;
        }
        public DrawPosition copy() {
            return new DrawPosition(this.x, this.y);
        }
        public DrawDiff calcDiff(DrawPosition position) {
            return new DrawDiff(this, position);
        }
        public string ToString() {
            return "x="+this.x+"|y="+this.y;
        }
    }
}