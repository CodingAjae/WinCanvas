using System;

namespace WinCanvas {
    public class DrawArea {
        public double left { get; set; }
        public double top { get; set; }
        public double right { get; set; }
        public double bottom { get; set; }
        
        public DrawArea() {
            this.left = 0.0;
            this.top = 0.0;
            this.right = 0.0;
            this.bottom = 0.0;
        }
        public DrawArea(double left, double top, double right, double bottom) {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }
        public DrawArea( DrawPosition position, DrawSize size ) {
            this.left = position.x;
            this.top = position.y;
            this.right = position.x + size.width;
            this.bottom = position.y + size.height;
        }

        public string ToString() {
            return "left="+left+"|top="+top+"|right="+right+"|bottom="+bottom;
        }

        public double width { get { return right - left; }}
        public double height { get { return bottom - top; }}

        public DrawPosition position { get { return new DrawPosition(left, top);}}

        public bool check( DrawPosition pos ) {
            return pos.x >= left && pos.x <= right && pos.y >= top && pos.y <= bottom;
        }

        public DrawSize getSize() {
            double width = Math.Abs(right-left);
            double height = Math.Abs(bottom-top);
            return new DrawSize(width, height);
        }

        public bool validation() {
            DrawSize size = getSize();
            return size.width > 0 && size.height > 0;
        }

        public DrawRange getHorizontalRange(double length) { //가로범위
            return new DrawRange(this, true, length);
        }
        public DrawRange getVerticalRange(double length) { // 세로범위
            return new DrawRange(this, false, length);
        }
    }
}