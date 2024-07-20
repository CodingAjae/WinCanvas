using System.Windows.Media;
using System.Windows.Controls;

namespace WinCanvas {
    public class BaseShape {
        public ObjectManager manager { get; set; }
        public virtual string getType() { return "none"; }
        public int uid { get; set; } = -1;
        public DrawSize size { get; set; } = new DrawSize();
        public DrawPosition position { get; set; } = new DrawPosition();
        public bool drawable { get; set; } = true;
        public string fillcolor { get; set; } = "#d9d9d9";
        public string bordercolor { get; set; } = "#000000";    
        public int bordersize { get; set; } = 1;

        public virtual void draw(Canvas canvas) { }
        public virtual bool check(DrawPosition position) { return getArea().check(position); }
        public virtual DrawArea getArea() { return new DrawArea(this.position, this.size); }
        public virtual bool isComplete() { return position.x > 0 && position.y > 0; }
        public virtual void update(DrawDiff diff) {
            DrawArea area = getArea();
            this.position = new DrawPosition(area.left+diff.x, area.top+diff.y);
        } 
        public virtual void update(DrawPosition position) {
            this.position = position;
        } 

        public virtual void update(DrawPosition position, DrawSize size) {
            this.position = position;
            this.size = size;
        } 

        public Color hex2color(string str) {
            return (Color) ColorConverter.ConvertFromString(str);
        }
        protected void _debug(int uid, string message) {
            BroadcastArgs args = new BroadcastArgs();
            args.evttype = "_debug_shape";
            args.debuguid = uid;
            args.debugmessage = message;
            BroadcastFactory.ExecuteBrtoadcast(args);
        }
    }
}