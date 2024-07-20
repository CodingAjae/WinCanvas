using System.Collections.Generic;
using System.Windows.Controls;

namespace WinCanvas {
    public class SelectShape:BaseShape {
        private BaseShape _shape;
        private List<HandleShape> _handlers = new List<HandleShape>();

        public SelectShape(BaseShape shape) {
            _shape = shape;

            for( int idx = 0; idx < 9; idx++) {
                _handlers.Add(new HandleShape(idx, shape.getType()));
            }
        }

        public override void draw(Canvas canvas) {
            DrawArea area = _shape.getArea();
            if( area.validation() ) {
                foreach( HandleShape shape in _handlers ) {
                    shape.update(area);
                    shape.draw(canvas);
                }
            } 
        }
    }
}