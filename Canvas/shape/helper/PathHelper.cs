using WinCanvas.Path;

namespace WinCanvas {
    public class PathHelper {

        public static BaseEndpoint? creaetEndpoint(string type ) {
            if( type == "none" )  {
                return new NoneEndpoint();
             } else if( type == "circle" )  {
                return new CircleEndpoint();
            } else if( type == "one" )  {
                return new OneEndpoint();
            } else if( type == "many" )  {
                return new ManyEndpoint();
            } else if( type == "follow" )  {
                return new FollowEndpoint();
            }

            return null;
        }

        public static BasePath? createPath(EnumDirection begin, EnumDirection finish) {
            if( begin == EnumDirection.LEFT &&  finish == EnumDirection.LEFT ) {
                return new Left_Left_Path();
            } else if( begin == EnumDirection.LEFT &&  finish == EnumDirection.UP ) {
                return new Left_Up_Path();
            } else if( begin == EnumDirection.LEFT &&  finish == EnumDirection.RIGHT ) {
                return new Left_Right_Path();
            } else if( begin == EnumDirection.LEFT &&  finish == EnumDirection.DOWN ) {
                return new Left_Down_Path();

            } else if( begin == EnumDirection.UP   &&  finish == EnumDirection.LEFT ) {
                return new Up_Left_Path();
            } else if( begin == EnumDirection.UP   &&  finish == EnumDirection.UP ) {
                return new Up_Up_Path();
            } else if( begin == EnumDirection.UP   &&  finish == EnumDirection.RIGHT ) {
                return new Up_Right_Path();
            } else if( begin == EnumDirection.UP   && finish == EnumDirection.DOWN ) {
                return new Up_Down_Path();

            } else if( begin == EnumDirection.RIGHT &&  finish == EnumDirection.LEFT ) {
                return new Right_Left_Path();
            } else if( begin == EnumDirection.RIGHT &&  finish == EnumDirection.UP ) {
                return new Right_Up_Path();
            } else if( begin == EnumDirection.RIGHT &&  finish == EnumDirection.RIGHT ) {
                return new Right_Right_Path();
            } else if( begin == EnumDirection.RIGHT &&  finish == EnumDirection.DOWN ) {
                return new Right_Down_Path();

            } else if( begin == EnumDirection.DOWN &&  finish == EnumDirection.LEFT ) {
                return new Down_Left_Path();
            } else if( begin == EnumDirection.DOWN &&  finish == EnumDirection.UP ) {
                return new Down_Up_Path();
            } else if( begin == EnumDirection.DOWN &&  finish == EnumDirection.RIGHT ) {
                return new Down_Right_Path();
            } else if( begin == EnumDirection.DOWN &&  finish == EnumDirection.DOWN ) {
                return new Down_Down_Path();
            }
            
            return null;
        }

        public static EnumDirection calcDirection(DrawArea abase, DrawArea adest, bool finish) {
            int hres = abase.getHorizontalRange(0).compare(adest.getHorizontalRange(0)); //가로
            int vres = abase.getVerticalRange(0).compare(adest.getVerticalRange(0)); //세로

            BroadcastArgs args = new BroadcastArgs();
            args.evttype = "_debug_relation";
            args.debuggubun = finish?"finish":"begin";
            args.debugmessage = "("+ (finish?"finish":"begin") +") H1="+hres+" |V1="+vres;
            BroadcastFactory.ExecuteBrtoadcast(args);

            
            if( vres == -2 && hres == -2 ) {
                return finish? EnumDirection.UP : EnumDirection.LEFT;
            } else if( vres == -2 && hres == -1 ) {
                return EnumDirection.UP;
            } else if( vres == -2 && hres == 0 ) {
                return EnumDirection.UP;
            } else if( vres == -2 && hres == 1 ) {
                return EnumDirection.UP;
            } else if( vres == -2 && hres == 2 ) {
                return finish? EnumDirection.UP : EnumDirection.RIGHT;

            } else if( vres == -1 && hres == -2 ) {
                return EnumDirection.LEFT;
            } else if( vres == -1 && hres == -1 ) {
                return EnumDirection.UP;
            } else if( vres == -1 && hres == 0 ) {
                return EnumDirection.UP;
            } else if( vres == -1 && hres == 1 ) {
                return EnumDirection.UP;
            } else if( vres == -1 && hres == 2 ) {
                return EnumDirection.RIGHT;
            
            } else if( vres == 0 && hres == -2 ) {
                return EnumDirection.LEFT;
            } else if( vres == 0 && hres == -1 ) {
                return EnumDirection.LEFT;
            } else if( vres == 0 && hres == 0 ) {
                return EnumDirection.NONE;
            } else if( vres == 0 && hres == 1 ) {
                return EnumDirection.RIGHT;
            } else if( vres == 0 && hres == 2 ) {
                return EnumDirection.RIGHT;

            } else if( vres == 1 && hres == -2 ) {
                return EnumDirection.LEFT;
            } else if( vres == 1 && hres == -1 ) {
                return EnumDirection.DOWN;
            } else if( vres == 1 && hres == 0 ) {
                return EnumDirection.DOWN;
            } else if( vres == 1 && hres == 1 ) {
                return EnumDirection.DOWN;
            } else if( vres == 1 && hres == 2 ) {
                return EnumDirection.RIGHT;

            } else if( vres == 2 && hres == -2 ) {
                return finish?EnumDirection.DOWN:EnumDirection.LEFT;
            } else if( vres == 2 && hres == -1 ) {
                return EnumDirection.DOWN;
            } else if( vres == 2 && hres == 0 ) {
                return EnumDirection.DOWN;
            } else if( vres == 2 && hres == 1 ) {
                return EnumDirection.DOWN;
            } else if( vres == 2 && hres == 2 ) {
                return finish?EnumDirection.DOWN:EnumDirection.RIGHT;
            }

           return EnumDirection.NONE;
        }        
    }
}
