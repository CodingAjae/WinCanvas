using System;
using System.Windows;
using System.Windows.Controls;

namespace WinCanvas {

    public partial class PathTestPage: Page {

        private CanvasManager _manager; 
        private int _buid = 0;
        private int _fuid = 0;
        private int _ruid = 0;

        private string _bdir = "";       
        private string _fdir = "";

        private string _btype = "none";
        private string _ftype = "none";

        public PathTestPage(CanvasManager manager) {
            _manager = manager;
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e) {
            BroadcastFactory.AddBroadcast(OnCallback);

            SetupDirectionRadioButton(wpBeginDirection, "begindir", "down");
            SetupDirectionRadioButton(wpFinishDirection, "finishdir", "down");
            SetupTypeRadioButton(wpBeginType, "begintype", "many");
            SetupTypeRadioButton(wpFinishType, "finishtype", "many");
        }
        private void OnUnload(object sender, RoutedEventArgs e) {
            BroadcastFactory.RemoveBroadcast(OnCallback);
        }

        private void SetupDirectionRadioButton(WrapPanel wp, string group, string select) {
            foreach(string item in new string[]{"left", "up", "right", "down"} ) {
                RadioButton rb = new RadioButton();
                rb.Content = item.ToUpper();
                rb.Tag = item;
                rb.GroupName = group;
                rb.Margin = new Thickness(15,5,0,0);
                rb.Checked += OnChecked;
                rb.IsChecked = (item == select);
                wp.Children.Add(rb);
            }
        }
        private void SetupTypeRadioButton(WrapPanel wp, string group, string select) {
            foreach(string item in new string[]{"none", "follow", "circle", "one", "many"} ) {
                RadioButton rb = new RadioButton();
                rb.Content = item.ToUpper();
                rb.Tag = item;
                rb.GroupName = group;
                rb.Margin = new Thickness(15,5,0,0);
                rb.Checked += OnChecked;
                rb.IsChecked = (item == select);
                wp.Children.Add(rb);
            }
        }

        private void OnChecked(object sender, RoutedEventArgs e) {
            RadioButton rb = (RadioButton)sender; 

            if( rb.GroupName == "begindir" ) {
                _bdir = (string)rb.Tag;
            } else if( rb.GroupName == "finishdir" ) {
                _fdir = (string)rb.Tag;
            } else if( rb.GroupName == "begintype" ) {
                _btype = (string)rb.Tag;
            } else if( rb.GroupName == "finishtype" ) {
                _ftype = (string)rb.Tag;
            }

            if( _bdir != "" && _fdir != "" ) {
                OnElementPathTest();
            }
        }

        public void OnElementPathTest() {
            EnumDirection bdirection = (EnumDirection)Enum.Parse(typeof(EnumDirection), _bdir.ToUpper());
            EnumDirection fdirection = (EnumDirection)Enum.Parse(typeof(EnumDirection), _fdir.ToUpper());

            if( _buid == 0 ) {
                 _buid = _manager.injectShape(new ElementShape(629, 119, string.Format("Begin({0})", _bdir)));
            } else {
                ((ElementShape)_manager.getShape(_buid)).text = string.Format("Begin({0})", _bdir); 
            }

            if( _fuid == 0 ) { 
                _fuid = _manager.injectShape(new ElementShape(844, 295, string.Format("Finish({0})", _fdir)));
            } else {
                ((ElementShape)_manager.getShape(_fuid)).text = string.Format("Finish({0})", _fdir); 
            }

            if( _ruid > 0 ) {
                _manager.removeShape(_ruid);
            }
            
            RelationShape relation = new RelationShape(_btype, _ftype);
            relation.begin = new DrawEndpoint(bdirection, _btype, _buid);
            relation.finish = new DrawEndpoint(fdirection, _ftype, _fuid);
            _manager.resetStatus();
            _ruid = _manager.injectShape(relation);
        }
        
        public void OnCallback(BroadcastArgs args) {
            if( args.evttype == "_debug_path")  {
                lbDebug.Content = args.debugmessage;
            } else if( args.evttype == "_debug_shape" && _buid == args.debuguid)  {
                lbBegin.Content = args.debugmessage;
            } else if( args.evttype == "_debug_shape" && _fuid == args.debuguid)  {
                lbFinish.Content = args.debugmessage;
            }   
        }
    }
}