
namespace WinCanvas {
    public class DrawEndpoint {
        public double length {get; set;} = 37;
        public double unit {get; set;} = 10;
        public double cursor {get; set;} = 0;
        
        public string ecolor { get; set; } = "#0000ff";
        public string pcolor { get; set; } = "#ff0000";
        
        
        public EnumDirection direction { get; set; } = EnumDirection.NONE;
        public int uid {get;set;} = 0;
        public string type {get;set;} = "none";
        

        public DrawEndpoint() {
            this.direction = EnumDirection.NONE;
            this.type = "none";
            this.uid = 0;
        }
        public DrawEndpoint(EnumDirection direction, string type, int uid) {
            this.direction = direction;
            this.type = type;
            this.uid = uid;
        }
    }
}