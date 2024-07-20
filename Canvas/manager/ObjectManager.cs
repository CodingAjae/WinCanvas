using System.Collections.Generic;
using System.Windows.Controls;

namespace WinCanvas {
    public class ObjectManager {
        private CanvasManager _canvas_manager;
        private DocumentManager _document_manager;
        private List<BaseShape> _shapes = new List<BaseShape>();
        private BaseShape? _ready_shape = null;

        public ObjectManager(CanvasManager manager, DocumentManager document) {
            this._canvas_manager = manager;
            this._document_manager = document;
        }
        public void draw( Canvas canvas ) {
            foreach( BaseShape item in _shapes ) {
                if( item.drawable ) {
                    item.draw(canvas);
                }
            }
        }
        
        public void reset() {
            _ready_shape = null;                
        }

        public void createReady(BaseShape shape) {
            _ready_shape = shape;
        }

        public bool isCreateReady() {
            if( _ready_shape != null ) {
                return true;
            }

            return false;
        }
        public int updateReady(DrawPosition position) {
            if( _ready_shape == null ) {
                return -1;
            }

            if( _ready_shape.getType() == "relation" ) {
                BaseShape? shape = search(position);
                if( shape != null ) {
                    ((RelationShape)_ready_shape).updateRelation(shape.uid);
                } 
            } else {
                _ready_shape.update(position);
            }            

            if( _ready_shape.isComplete() ) {
                int uid = add(_ready_shape);
                _ready_shape = null;                
                return uid;
            }

            return -1;
        }

        public void clear() {
            _shapes.Clear();
            _shapes = new List<BaseShape>();
        }

        public int add(BaseShape shape) {
            if( shape.uid < 0 ) {
                shape.uid = _document_manager.uidGenerate();
            }

            _shapes.Add(shape);
            return shape.uid;
        }
        public void remove(int uid) {
            for( int idx = 0; idx < _shapes.Count; idx++ ) {
                if( _shapes[idx].uid == uid ) {
                    _shapes.RemoveAt(idx);
                    return;
                }
            }
        }
        public BaseShape? get(int uid) {
            foreach( BaseShape item in _shapes ) {
                if( item.uid == uid ) {
                    return item;
                }
            }

            return null;
        }
        public BaseShape? search(DrawPosition position) {
            foreach( BaseShape item in _shapes ) {
                if( item.check(position) ) {
                    return item;
                }
            }

            return null;
        }                
    }
}