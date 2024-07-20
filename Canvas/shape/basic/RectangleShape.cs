using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Net;

namespace WinCanvas {
    public class RectangleShape : BaseShape {
        public override string getType() { return "rect"; }
        public override void draw(Canvas canvas) {
            Rectangle rect = new Rectangle();
            rect.StrokeThickness = this.bordersize;
            rect.Stroke = new SolidColorBrush(hex2color(this.bordercolor));
            rect.Fill = new SolidColorBrush(hex2color(this.fillcolor));
            rect.Width = size.width;
            rect.Height = size.height;

            Canvas.SetLeft(rect,position.x);
            Canvas.SetTop(rect,position.y);
            canvas.Children.Add(rect);
        }
    }
}