using System;

namespace WinCanvas {

    public class DrawDiff {
        public EnumDirection direction { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public DrawDiff() {
            this.direction = EnumDirection.NONE;
            this.x = 0.0;
            this.y = 0.0;
        }
        public DrawDiff(double x, double y) {
            this.x = x;
            this.y = y;
        }
        public DrawDiff(DrawPosition before, DrawPosition after) {
            this.x = after.x - before.x;
            this.y = after.y - before.y;
        }
        public string ToString() {
            return "diffx="+this.x+"|diffy="+this.y;
        }
    }
}