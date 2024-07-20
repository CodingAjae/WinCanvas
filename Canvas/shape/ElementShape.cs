using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace WinCanvas {
    public class ElementShape : BaseShape {
        public override string getType() { return "element"; }
        public string text {get; set;} = "";

        public ElementShape(string text) {
            this.text = text;
            this.position = new DrawPosition(0,0);
            this.size = new DrawSize(154,93);
        }
        public ElementShape(double x, double y, string text) {
            this.text = text;
            this.position = new DrawPosition(x,y);
            this.size = new DrawSize(154,93);
        }

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

            if( text != null && text.Length > 0 ) {
                TextBlock tbl = new TextBlock();
                tbl.Width = size.width;
                tbl.TextAlignment = TextAlignment.Center;
                tbl.Text = text;
                tbl.FontSize = 18;
                tbl.Foreground = new SolidColorBrush(hex2color("#0000ff"));      
                tbl.FontWeight = FontWeight.FromOpenTypeWeight(700);      
                
                Canvas.SetLeft(tbl, position.x);
                Canvas.SetTop(tbl, position.y + size.height/2 - 12);
                canvas.Children.Add(tbl);
            }
        }
    }
}