namespace WinCanvas {
    public class DrawLine {
        public double x1 { get; set; }
        public double y1 { get; set; }
        public double x2 { get; set; }
        public double y2 { get; set; }
        public bool ellipse { get; set; } = false;

        public DrawLine() {
            this.x1 = 0.0;
            this.y1 = 0.0;
            this.x2 = 0.0;
            this.y2 = 0.0;
            this.ellipse = false;
        }
        public DrawLine( double x1, double y1, double x2, double y2 ) {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.ellipse = false;
        }
        public DrawLine( bool ellipse, double x, double y, double width, double height ) {
            this.x1 = x;
            this.y1 = y;
            this.x2 = x+width;
            this.y2 = y+height;
            this.ellipse = ellipse;
        }
        public DrawLine( DrawPosition p1, DrawPosition p2) {
            this.x1 = p1.x;
            this.y1 = p1.y;
            this.x2 = p2.x;
            this.y2 = p2.y;
            this.ellipse = false;
        }
    }
}