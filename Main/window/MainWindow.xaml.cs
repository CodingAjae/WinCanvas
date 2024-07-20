using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;


namespace WinCanvas {
    public partial class MainWindow : Window {
        DispatcherTimer _timer = new DispatcherTimer();
        DocumentManager _document = new DocumentManager();
        CanvasManager _manager;

        public MainWindow() {
            BroadcastFactory.AddBroadcast(OnCallback);
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e) {
            _manager = new CanvasManager(mainCanvas, mainScroll, _document);   
            OnSetupEnv();

            OnCommandNavigate(new PathTestPage(_manager));
            // OnCommandNavigate(new RelationTestPage(_manager));
            // OnCommandNavigate(new TotalTestPage(_manager));
        }

        private void OnMouseEnter(object sender, MouseEventArgs e) {
            _manager.OnMouseEnter(e);
        }
        private void OnMouseLeave(object sender, MouseEventArgs e) {
            _manager.OnMouseLeave(e);
        }
        private void OnMouseMove(object sender, MouseEventArgs e) {
            _manager.OnMouseMove(e);
        }
        private void OnMouseDown(object sender, MouseEventArgs e) {
            _manager.OnMouseDown(e);
        }
        private void OnMouseUp(object sender, MouseButtonEventArgs e) {
            _manager.OnMouseUp(e);
        }
        private void OnMouseWheel(object sender, MouseWheelEventArgs e) {
            _manager.OnMouseWheel(e);
        }
        private void OnKeyDown(object sender, KeyEventArgs e) {
            _manager.OnKeyDown(e);
        }
        private void OnKeyUp(object sender, KeyEventArgs e) {
            _manager.OnKeyUp(e);
        }
        private void OnTimer(object sender, EventArgs e){
            _manager.OnUpdateCanvas();
        }
        public void OnCommandNavigate( Page page ) {
            commandFrame.NavigationService.Navigate(page);
        }
        public void OnSetupEnv() {
            var window = Window.GetWindow(this);
            window.KeyDown += OnKeyDown;
            window.KeyUp += OnKeyUp;

            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Tick += OnTimer;
            _timer.Start();
        }
        public void OnCallback(BroadcastArgs args) {
            
        }
    }
}
