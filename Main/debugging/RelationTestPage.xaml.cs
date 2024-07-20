using System.Windows;
using System.Windows.Controls;

namespace WinCanvas {
    public partial class RelationTestPage: Page {
        private CanvasManager _manager; 
        private string _type = "many";
        private int _buid = 0;
        private int _fuid = 0;
        private int _ruid = 0;

        public RelationTestPage(CanvasManager manager) {
            _manager = manager;
            InitializeComponent();
        }
        private void OnLoad(object sender, RoutedEventArgs e) {
            BroadcastFactory.AddBroadcast(OnCallback);
            
            _buid = _manager.injectShape(new ElementShape(100, 100, "BEGIN"));
            _fuid = _manager.injectShape(new ElementShape(400, 400, "FINIESH"));
            OnRelation();
        }
        private void OnUnload(object sender, RoutedEventArgs e) {
            BroadcastFactory.RemoveBroadcast(OnCallback);
        }

        private void OnRelation() {
            if( _buid > 0 && _fuid > 0 ) {
                if( _ruid > 0 ) {
                    _manager.removeShape(_ruid);
                }

                RelationShape relation = new RelationShape(_type, _type);
                relation.begin  = new DrawEndpoint(EnumDirection.NONE, "circle", _buid);
                relation.finish = new DrawEndpoint(EnumDirection.NONE, "arrow", _fuid);
                _ruid = _manager.injectShape(relation);
            }
        }
        private void OnClearRelationClick(object sender, RoutedEventArgs e) {
            if( _ruid > 0 ) {
                _manager.removeShape(_ruid);
                _ruid = 0;
            }
        }
        public void OnCallback(BroadcastArgs args) {
            if( args.evttype == "create_shape" ) {
                if( _buid == 0 ) {
                    _buid = args.createuid;
                } else if( _fuid == 0 ) {
                    _fuid = args.createuid;
                }                
            } else if ( args.evttype == "_debug_relation") {
                if( args.debuggubun == "begin") {
                    lbBegin.Content = args.debugmessage;
                } else if( args.debuggubun == "finish") {
                    lbFinish.Content = args.debugmessage;
                }
            } else if ( args.evttype == "_debug_shape" ) {
                if( args.debuguid == _buid ) {
                    lbBegin2.Content = args.debugmessage;
                } else if ( args.debuguid == _fuid ) {
                    lbFinish2.Content = args.debugmessage;
                }
            } else if ( args.evttype == "_debug_finishdrag") {
                 OnRelation();
            }
        }
    }
   
}