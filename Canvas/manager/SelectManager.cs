using System;
using System.Diagnostics;
using System.Windows.Controls;

namespace WinCanvas {
    public class SelectManager {
        private BaseShape? _selects = null;

        private bool _object_drag = false;
        private bool _update_position = false;

        public void releaseSelect() {
            // Debug.WriteLine("SelectManager|releaseSelect");
            if( _selects != null && _selects.getType() == "relation" ) {
                ((RelationShape)_selects).releaseSelect();
            }

            _selects = null;
        }
        public void add(BaseShape? shape) {
            // Debug.WriteLine("SelectManager|add");
            if( _selects != null && shape.uid != _selects.uid ) {
                releaseSelect();
            }   

            _selects = shape;
        }
        public bool check() {
            return _selects != null;
        
        }
        public BaseShape? get() {
            return _selects;
        }

        public bool checkObjectDrag() {
            if( _object_drag == true && this._selects == null ) {
                _object_drag = false;
            }

            return _object_drag;
        }
        public void startObjectDrag() {
            if( _selects == null ) {
                _object_drag = false;
                _update_position = false;
            } else {
                _object_drag = true;
                _update_position = false;
            }
        }
        public void finishObjectDrag() {
            _object_drag = false;
            _update_position = false;

            BroadcastArgs args = new BroadcastArgs();
            args.evttype = "_debug_finishdrag";
            BroadcastFactory.ExecuteBrtoadcast(args);

        }
        public bool isUpdatePosition() {
            return _update_position;
        }

        public void moveProcess(DrawDiff diff, bool shift ) {
            if( _selects != null && _selects.getType() == "relation" ) {
                _selects.update( diff );
            } else if( _selects != null ) {
                DrawArea area = _selects.getArea();
                if( shift ) {
                    if( Math.Abs(diff.x) > Math.Abs(diff.y) ) {
                        diff.y = 0;
                    } else  {
                        diff.x = 0;
                    }
                }
                _selects.update( diff );

            }
        }

        public void draw(Canvas canvas) {
            if( _selects != null ) {
                SelectShape shape = new SelectShape(_selects);
                shape.draw(canvas);
            }
        }

    }
}