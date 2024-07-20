using System.Security.Cryptography;

namespace WinCanvas {
    public class DrawSize {
        public double width { get; set; } 
        public double height { get; set; }
        
        public DrawSize() {
            this.width = 0.0;
            this.height = 0.0;
        }
        public DrawSize(double width, double height) {
            this.width = width;
            this.height = height;
        }
    }
}