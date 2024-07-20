using System.Collections.Generic;
using System.Windows.Controls;

namespace WinCanvas {
    public class NoneEndpoint:BaseEndpoint {
        public override string getType() { return "none"; }

        public override List<DrawLine> left(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x, position.y, position.x+length, position.y));
            return lines;
        }
        public override List<DrawLine> up(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x, position.y, position.x, position.y+length));
            return lines;
        }
        public override List<DrawLine> right(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x-length, position.y, position.x, position.y));
            return lines;
        }
        public override List<DrawLine> down(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x, position.y-length, position.x, position.y));
            return lines;
        }     
    }
}