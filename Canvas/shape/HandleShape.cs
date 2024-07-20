using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;

namespace WinCanvas {
    public class HandleShape : BaseShape {
        public DrawArea area {get;set;} = new DrawArea();
        public string shape {get;set;} = "shape";
        public int idx { get; set;} = -1;

        /**
        * 0 1 2
        * 3 4 5
        * 6 7 8
        */                
        public HandleShape(int idx, string shape) {
            this.idx = idx;
            this.shape = shape;
            this.fillcolor = "#ffffff";
        }

        public void update(DrawArea sarea) {
            int half = 3;
            drawable = false;

            if( shape == "relation" ) {
                drawable = (idx == 4);
            } else if( idx != 4 ) {
                drawable = true;
            }   
            
            switch(idx) {
            case 0:
                area.left = sarea.left -half; 
                area.top = sarea.top - half;
                break;
            case 1:
                area.left = sarea.left + sarea.width/2 - half; 
                area.top = sarea.top - half;
                break;
            case 2:
                area.left = sarea.left + sarea.width - half; 
                area.top = sarea.top - half;
                break;
            case 3:
                area.left = sarea.left - half; 
                area.top = sarea.top + sarea.height/2 - half;
                break;
            case 4:
                area.left = sarea.left + sarea.width/2 - half; 
                area.top = sarea.top + sarea.height/2 - half;
                break;            
            case 5:
                area.left = sarea.left + sarea.width - half; 
                area.top = sarea.top + sarea.height/2 - half;
                break;
            case 6:
                area.left = sarea.left - half; 
                area.top = sarea.top + sarea.height - half;
                break;
            case 7:
                area.left = sarea.left + sarea.width/2 - half; 
                area.top = sarea.top + sarea.height - half;
                break;
            case 8:
                area.left = sarea.left + sarea.width - half; 
                area.top = sarea.top + sarea.height - half;
                break;                
            }

            area.right = area.left + half*2;
            area.bottom = area.top + half*2;
        }

        public override void draw(Canvas canvas) {
            if( drawable ) {
                Rectangle rect = new Rectangle();
                rect.Stroke = new SolidColorBrush(hex2color(this.bordercolor));
                rect.Fill = new SolidColorBrush(hex2color(this.fillcolor));
                rect.Width = area.width;
                rect.Height = area.height;
                Canvas.SetLeft(rect,area.position.x);
                Canvas.SetTop(rect,area.position.y);
                canvas.Children.Add(rect);
            }
        }

        public override bool check(DrawPosition pos) {   
            return area.check(pos);
        }
    }
}