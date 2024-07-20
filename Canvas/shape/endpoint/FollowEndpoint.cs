using System.Collections.Generic;

namespace WinCanvas {
    public class FollowEndpoint:BaseEndpoint {
        public override string getType() { return "follow"; }

        public override List<DrawLine> left(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x, position.y, position.x+length, position.y));
            lines.Add(new DrawLine(position.x+length, position.y, position.x+length-unit, position.y-unit/2));
            lines.Add(new DrawLine(position.x+length, position.y, position.x+length-unit, position.y+unit/2));
            return lines;
        }
        public override List<DrawLine> up(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x, position.y, position.x, position.y+length));
            lines.Add(new DrawLine(position.x, position.y+length, position.x+unit/2, position.y+length-unit));
            lines.Add(new DrawLine(position.x, position.y+length, position.x-unit/2, position.y+length-unit));
            return lines;
        }
        public override List<DrawLine> right(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x-length, position.y, position.x, position.y));
            lines.Add(new DrawLine(position.x-length, position.y, position.x-length+unit, position.y-unit/2));
            lines.Add(new DrawLine(position.x-length, position.y, position.x-length+unit, position.y+unit/2));
            return lines;
        }
        public override List<DrawLine> down(DrawPosition position, double length, double unit) {
            List<DrawLine> lines = new List<DrawLine>();
            lines.Add(new DrawLine(position.x, position.y-length, position.x, position.y));
            lines.Add(new DrawLine(position.x, position.y-length, position.x+unit/2, position.y-length+unit));
            lines.Add(new DrawLine(position.x, position.y-length, position.x-unit/2, position.y-length+unit));
            return lines;
        }   
    }
}