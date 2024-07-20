
namespace WinCanvas {
/*
_debug_shape
_debug_path 
_debug_finishdrag

create_shape
*/
    public class BroadcastArgs {
        public string evttype { get; set;} = "";
        public int createuid { get; set; } = 0;        
        public int debuguid { get; set; } = 0;
        public string debugmessage { get; set; } = "";
        public string debuggubun {get;set;} = "";
    }

    public class BroadcastFactory {
        private static BroadcastFactory _factory = new BroadcastFactory();
        
        public delegate void BroadcastCallback(BroadcastArgs evt);

        public static void AddBroadcast(BroadcastCallback callback) {
            _factory.add(callback);
        }
        public static void RemoveBroadcast(BroadcastCallback callback) {
            _factory.remove(callback);
        }
        public static void ExecuteBrtoadcast(BroadcastArgs args) {
            _factory.exec(args);
        }
 
        BroadcastCallback _callback =  null;
        private BroadcastFactory() {}

        public void add(BroadcastCallback callback) {
            _callback += callback;
        }
        public void remove(BroadcastCallback callback) {
            _callback -= callback;
        }
        public void exec(BroadcastArgs args) {
            if( _callback != null ) 
                _callback(args);
        }
    }
}