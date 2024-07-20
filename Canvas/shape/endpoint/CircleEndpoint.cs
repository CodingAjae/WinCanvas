using System.Windows.Controls;
using System.Collections.Generic;

namespace WinCanvas {
    public class CircleEndpoint:BaseEndpoint {
        public override string getType() { return "circle"; }

        public override List<DrawLine> left(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x, position.y, position.x+length, position.y));
            lines.Add(new DrawLine(true, position.x+length-unit, position.y-unit/2, unit, unit));
            return lines;
        }
        public override List<DrawLine> up(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x, position.y, position.x, position.y+length));
            lines.Add(new DrawLine(true, position.x-unit/2, position.y+length-unit, unit, unit));
            return lines;
        }
        public override List<DrawLine> right(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x-length, position.y, position.x, position.y));
            lines.Add(new DrawLine(true, position.x-length, position.y-unit/2, unit, unit));
            return lines;
        }
        public override List<DrawLine> down(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x, position.y-length, position.x, position.y));
            lines.Add(new DrawLine(true, position.x-unit/2, position.y-length, unit, unit));
            return lines;
        }    

    }
}