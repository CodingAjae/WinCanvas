using System.Windows.Controls;
using System.Windows.Input;

namespace WinCanvas {
   public enum EnumCanvasEvent {
        NONE, MOUSEENTER, MOUSELEAVE, SCROLLDRAG_BEGIN, SCROLLDRAG_FINISH, CREATE
    }
 
    public class CanvasManager {
        private ObjectManager _object_manager;
        private SelectManager _select_manager;
        private Canvas _canvas_ref;
        private ScrollViewer _scroll_ref;
        private DrawPosition _drag_position;
        public bool mousedown { get; set; }
        public bool mousedrag { get; set; }
        public bool scrolldrag { get; set; }

        public CanvasManager(Canvas canvas, ScrollViewer scroll, DocumentManager document) {
            _canvas_ref = canvas;
            _scroll_ref = scroll;
            
            _object_manager = new ObjectManager(this, document);
            _select_manager = new SelectManager();
            resetStatus();
        }

        public void OnUpdateCanvas() {
            _canvas_ref.Children.Clear();
            _object_manager.draw(_canvas_ref);
            _select_manager.draw(_canvas_ref);
        }

        public void readyShape(BaseShape shape) {
            shape.manager = _object_manager;
            _object_manager.createReady(shape);
            _proc_change_cursor(EnumCanvasEvent.CREATE);
        }

        public int injectShape(BaseShape shape) {
            shape.manager = _object_manager;
            return _object_manager.add(shape);
        }

        public void removeShape(int uid) {
            _object_manager.remove(uid);
        }   
        public BaseShape getShape(int uid )  {
            return _object_manager.get(uid);
        }

        public void clearShape() {
            _select_manager.releaseSelect();
            _object_manager.clear();
        }

        public void resetStatus() {
            _proc_change_cursor(EnumCanvasEvent.NONE);
            _object_manager.reset();
            _select_manager.releaseSelect();
            mousedown = false;
            mousedrag = false;
            scrolldrag = false; 
        }

        public void OnMouseDown(MouseEventArgs e) {
            mousedrag = true;

            if( scrolldrag ) {
                _drag_position = new DrawPosition(_scroll_ref);
            } else if( _object_manager.isCreateReady() ) {
                DrawPosition position = new DrawPosition(_canvas_ref);
                int uid =_object_manager.updateReady(position);
                if( uid > 0 ) {
                    _proc_change_cursor(EnumCanvasEvent.NONE);

                    BroadcastArgs args = new BroadcastArgs();
                    args.evttype = "create_shape";
                    args.createuid = uid;
                    BroadcastFactory.ExecuteBrtoadcast(args);
                }
            } else {
                DrawPosition position = new DrawPosition(_canvas_ref);
                BaseShape? shape = _object_manager.search(position);
                if( shape != null ) {
                    _select_manager.add(shape);
                    _drag_position = position.copy();
                    _select_manager.startObjectDrag();
                } else {
                    _select_manager.releaseSelect();
                }
            }
        }
        public void OnMouseMove(MouseEventArgs e) {
            DrawPosition position = new DrawPosition();
            if( mousedrag ) {
                if( scrolldrag ) {
                    position = new DrawPosition(_scroll_ref);
                    DrawDiff diff = _drag_position.calcDiff(position);
                    _proc_scroll_move(diff);
                } else if( _select_manager.checkObjectDrag() ) {
                    if( e.LeftButton == MouseButtonState.Released ) {
                        _select_manager.finishObjectDrag();
                    } else {
                        position = new DrawPosition(_canvas_ref);
                        DrawDiff diff = _drag_position.calcDiff(position);
                        _select_manager.moveProcess(diff, Keyboard.IsKeyDown(Key.LeftShift) );
                    }

                } else {
                    position = new DrawPosition(_canvas_ref);
                }

                _drag_position = position.copy();
            }
        }
        public void OnMouseUp(MouseButtonEventArgs e) {
            mousedrag = false;
            _select_manager.finishObjectDrag();
        }
        public void OnMouseEnter(MouseEventArgs e) {
            _proc_change_cursor(EnumCanvasEvent.MOUSEENTER);
        }
        public void OnMouseLeave(MouseEventArgs e) {
            _proc_change_cursor(EnumCanvasEvent.MOUSELEAVE);
            // resetStatus();    

            _object_manager.reset();
            mousedown = false;
            mousedrag = false;
            scrolldrag = false; 

        }
        public void OnMouseWheel(MouseWheelEventArgs e) {
            if (Keyboard.IsKeyDown(Key.LeftShift) ) {
                e.Handled = true;
                _scroll_ref.ScrollToHorizontalOffset(_scroll_ref.HorizontalOffset - e.Delta);
            } else  if (Keyboard.IsKeyDown(Key.LeftCtrl) ) {
                e.Handled = true;

                // double height = _canvas_ref.ActualHeight;
                // double width = _canvas_ref.ActualWidth;
                // double zoom = e.Delta;
                // height += 2;
                // width += 2;
                // ScaleTransform sc = new ScaleTransform(width, height);
                // _canvas_ref.LayoutTransform = sc;
                // _canvas_ref.UpdateLayout();
            }
        }
        public void OnKeyDown(KeyEventArgs e) {
            if( e.Key == Key.Space ) {
                scrolldrag = true; 
                _drag_position = new DrawPosition(_scroll_ref);
                _proc_change_cursor(EnumCanvasEvent.SCROLLDRAG_BEGIN);
            } else if ( e.Key == Key.Escape ) {
                resetStatus();
                _select_manager.finishObjectDrag();
                _proc_change_cursor(EnumCanvasEvent.NONE);

            }
        }
        public void OnKeyUp(KeyEventArgs e) {
            if( scrolldrag ) {
                scrolldrag = false; 
                _proc_change_cursor(EnumCanvasEvent.SCROLLDRAG_FINISH);
            }
        }
        private void _proc_scroll_move(DrawDiff diff) {
            _scroll_ref.ScrollToHorizontalOffset(_scroll_ref.HorizontalOffset - diff.x);
            _scroll_ref.ScrollToVerticalOffset(_scroll_ref.VerticalOffset - diff.y);
        }
        private void _proc_change_cursor(EnumCanvasEvent evt) {
            if( evt == EnumCanvasEvent.MOUSEENTER ) {
                if( _object_manager.isCreateReady() ) {
                    Mouse.OverrideCursor = Cursors.Cross;
                } else {
                    Mouse.OverrideCursor = Cursors.Arrow;
                }
            } else if( evt == EnumCanvasEvent.MOUSELEAVE ) {
                Mouse.OverrideCursor = Cursors.Arrow;
            } else if( evt == EnumCanvasEvent.SCROLLDRAG_BEGIN ) {
                Mouse.OverrideCursor = Cursors.SizeAll;
            } else if( evt == EnumCanvasEvent.SCROLLDRAG_FINISH ) {
                Mouse.OverrideCursor = Cursors.Arrow;
            } else if( evt == EnumCanvasEvent.NONE ) {
                Mouse.OverrideCursor = Cursors.Arrow;
            } else if( evt == EnumCanvasEvent.CREATE ) {
                Mouse.OverrideCursor = Cursors.Cross;
            } 
        }
    }   
}