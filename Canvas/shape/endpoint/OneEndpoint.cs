using System.Collections.Generic;
using System.Windows.Controls;

namespace WinCanvas {
    public class OneEndpoint:BaseEndpoint {
        public override string getType() { return "one"; }
        public override List<DrawLine> left(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x, position.y, position.x+length, position.y));
            lines.Add(new DrawLine(position.x+length-unit, position.y-unit, position.x+length-unit, position.y+unit));
            return lines;
        }
        public override List<DrawLine> up(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x, position.y, position.x, position.y+length));
            lines.Add(new DrawLine(position.x-unit, position.y+length-unit, position.x+unit, position.y+length-unit));
            return lines;
        }
        public override List<DrawLine> right(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x-length, position.y, position.x, position.y));
            lines.Add(new DrawLine(position.x-length+unit, position.y-unit, position.x-length+unit, position.y+unit));
            return lines;
        }
        public override List<DrawLine> down(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x, position.y-length, position.x, position.y));
            lines.Add(new DrawLine(position.x-unit, position.y-length+unit, position.x+unit, position.y-length+unit));
            return lines;
        }     
   }
}