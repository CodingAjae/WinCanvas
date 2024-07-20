namespace WinCanvas {
    public class DrawRange {
        public double start {get;set;} = 0;
        public double end {get;set;} = 0;
        public double center { get { return start + (end-start)/2; }}
        
        public DrawRange( double start, double end, double length ) {
            this.start = start - length;
            this.end = end + length;
        }
        public DrawRange( DrawArea area, bool horizontal, double length ) {
            if( horizontal ) { // 가로
                this.start = area.left - length;
                this.end = area.right + length;
            } else { // 세로
                this.start = area.top - length;
                this.end = area.bottom + length;
            }
        }

        public int compare(DrawRange range) {
            if( this.end < range.start ) {
                return 2;
            } else if( this.start > range.end ) {
                return -2;
            } else if( this.center < range.center ) {
                return 1;
            } else if( this.center > range.center ) {
                return -1;
            }

            return 0;
        }
        
    }
}