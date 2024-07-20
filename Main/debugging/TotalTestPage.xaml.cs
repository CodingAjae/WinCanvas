using System.Windows;
using System.Windows.Controls;

namespace WinCanvas {
    public partial class TotalTestPage: Page {
        private CanvasManager _manager; 
        private int _index = 0;

        public TotalTestPage(CanvasManager manager) {
            _manager = manager;
            InitializeComponent();
        }
        private void OnLoad(object sender, RoutedEventArgs e) {
            BroadcastFactory.AddBroadcast(OnCallback);
            
            _manager.injectShape(new ElementShape(100, 100, string.Format("E{0}", ++_index)));
            _manager.injectShape(new ElementShape(400, 400, string.Format("E{0}", ++_index)));
        }
        private void OnUnload(object sender, RoutedEventArgs e) {
            BroadcastFactory.RemoveBroadcast(OnCallback);
        }

        private void OnRelationClick(object sender, RoutedEventArgs e) {
            RelationShape shape = new RelationShape("circle", "follow");
            _manager.readyShape(shape);
        }
        
        private void OnElementClick(object sender, RoutedEventArgs e) {
            string name = string.Format("E{0}", ++_index);
            _manager.readyShape(new ElementShape(name));
        }
        
        private void OnClearAllClick(object sender, RoutedEventArgs e) {
            _manager.clearShape();
            _index = 0;
        }

        public void OnCallback(BroadcastArgs args) {

        }
    }
   
}