using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace WinCanvas {
    public class BaseEndpoint {
        public string color { get; set; } = "#000000";
        public virtual string getType() { return "none"; }

        public virtual List<DrawLine> left(DrawPosition position, double length, double unit) { return new List<DrawLine>(); }
        public virtual List<DrawLine> up(DrawPosition position, double length, double unit) { return new List<DrawLine>(); }
        public virtual List<DrawLine> right(DrawPosition position, double length, double unit) { return new List<DrawLine>(); }
        public virtual List<DrawLine> down(DrawPosition position, double length, double unit) { return new List<DrawLine>(); }

        public Color hex2color(string str) {
            return (Color) ColorConverter.ConvertFromString(str);
        }

        public void update(DrawDiff diff, DrawEndpoint endpoint, DrawArea area) {
            if( endpoint.direction == EnumDirection.LEFT || endpoint.direction == EnumDirection.RIGHT) {
                endpoint.cursor += diff.y;
            }  else if( endpoint.direction == EnumDirection.UP || endpoint.direction == EnumDirection.DOWN) {
                endpoint.cursor += diff.x;
            } 

            double basey = area.top+area.getSize().height/2 + endpoint.cursor;
            double basex = area.left+area.getSize().width/2 + endpoint.cursor;
            if( endpoint.direction == EnumDirection.LEFT) {
                if( basey < area.top ) {
                    endpoint.direction = EnumDirection.UP;
                    endpoint.cursor = area.width/2 * -1;
                } else if ( basey > area.bottom ) {
                    endpoint.direction = EnumDirection.DOWN;
                    endpoint.cursor = area.width/2* -1;
                }
            } else if( endpoint.direction == EnumDirection.UP) {
                if( basex < area.left) {
                    endpoint.direction = EnumDirection.LEFT;
                    endpoint.cursor = area.height/2* -1;
                } else if ( basex > area.right ) {
                    endpoint.direction = EnumDirection.RIGHT;
                    endpoint.cursor = area.height/2* -1;
                }
            } else if( endpoint.direction == EnumDirection.RIGHT) {
                if( basey < area.top ) {
                    endpoint.direction = EnumDirection.UP;
                    endpoint.cursor = area.width/2;
                } else if ( basey > area.bottom ) {
                    endpoint.direction = EnumDirection.DOWN;
                    endpoint.cursor = area.width/2;
                }
            } else if( endpoint.direction == EnumDirection.DOWN) {
                if( basex < area.left) {
                    endpoint.direction = EnumDirection.LEFT;
                    endpoint.cursor = area.height/2;
                } else if ( basex > area.right ) {
                    endpoint.direction = EnumDirection.RIGHT;
                    endpoint.cursor = area.height/2;
                }
            }
        } 

        public void draw(Canvas canvas, DrawEndpoint endpoint, DrawArea area) { 
            DrawPosition position = getDockingPosition(endpoint, area);

            List<DrawLine>? lines = null;
            switch(endpoint.direction) {
            case EnumDirection.LEFT:
                lines = left(position, endpoint.length, endpoint.unit);
                break;
            case EnumDirection.UP:
                lines = up(position, endpoint.length, endpoint.unit);
                break;
            case EnumDirection.RIGHT:
                lines = right(position, endpoint.length, endpoint.unit);
                break;
            case EnumDirection.DOWN:
                lines = down(position, endpoint.length, endpoint.unit);
                break;
            }

            if( lines != null && lines.Count > 0 ) {
                foreach(DrawLine line in lines ) {
                    if( line.ellipse ) {
                        _draw_circle(canvas, line);
                    } else {
                        _draw_line(canvas, line);
                    }
                }
            }
        }

        public DrawPosition getDockingPosition(DrawEndpoint endpoint, DrawArea area) {
            double basey = area.top+area.getSize().height/2 + endpoint.cursor;
            double basex = area.left+area.getSize().width/2 + endpoint.cursor;
            
            if( endpoint.direction == EnumDirection.LEFT) {
                return new DrawPosition(area.left - endpoint.length, basey);                
            }  else if( endpoint.direction == EnumDirection.UP) {
                return new DrawPosition(basex, area.top - endpoint.length);
            }  else if( endpoint.direction == EnumDirection.RIGHT) {
                return new DrawPosition(area.right + endpoint.length, basey);
            }  else if( endpoint.direction == EnumDirection.DOWN) {
                return new DrawPosition(basex, area.bottom + endpoint.length);
            } 

            return new DrawPosition();
        }

        public DrawArea getArea(DrawEndpoint endpoint, DrawArea area) {
            DrawPosition p = getDockingPosition(endpoint, area);
            DrawArea earea = new DrawArea();

            if( endpoint.direction == EnumDirection.LEFT) {
                earea = new DrawArea(p.x, p.y-10, p.x+endpoint.length, p.y+10);
            }  else if( endpoint.direction == EnumDirection.RIGHT) {
                earea = new DrawArea(p.x-endpoint.length, p.y-10, p.x, p.y+10);
            }  else if( endpoint.direction == EnumDirection.UP) {
                earea = new DrawArea(p.x-10, p.y, p.x+10, p.y+endpoint.length);
            }  else if( endpoint.direction == EnumDirection.DOWN) {
                earea = new DrawArea(p.x-10, p.y-endpoint.length, p.x+10, p.y);
            } 

            return earea;
        }

        public bool check(DrawPosition position, DrawEndpoint endpoint, DrawArea area) { 
            return getArea(endpoint, area).check(position); 
        }

        protected void _draw_line(Canvas canvas, DrawLine line) {
            Line l = new Line();
            l.X1 = line.x1;
            l.Y1 = line.y1;
            l.X2 = line.x2;
            l.Y2 = line.y2;
            l.StrokeThickness = 1;
            l.Stroke = new SolidColorBrush(hex2color(this.color));
            canvas.Children.Add(l);
        }
        
        protected void _draw_circle(Canvas canvas, DrawLine line) {
            Ellipse circle = new Ellipse();
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = hex2color(this.color);
            circle.Fill = brush;
            circle.StrokeThickness = 0;
            circle.Width = line.x2 - line.x1;
            circle.Height = line.y2 - line.y1;       
                 
            Canvas.SetLeft(circle,line.x1);
            Canvas.SetTop(circle,line.y1);
            
            canvas.Children.Add(circle);
        }
    }
}