using System.Diagnostics;
using System.Windows.Controls;
using WinCanvas.Path;

namespace WinCanvas {
    public class RelationShape: BaseShape {       
        public override string getType() { return "relation"; }

        public DrawEndpoint begin {get;set;} = new DrawEndpoint();
        public DrawEndpoint finish {get;set;} = new DrawEndpoint();

        private string _select = "none";
        private BaseEndpoint _begin_endpoint;
        private BaseEndpoint _finish_endpoint;

        public RelationShape(string btype, string ftype)  {
            begin.type = btype;
            finish.type = ftype;
        }

        public override void draw(Canvas canvas) {
            BaseShape s1 = manager.get(begin.uid)!;
            BaseShape s2 = manager.get(finish.uid)!;

            if( begin.direction == EnumDirection.NONE ) {
                begin.direction = PathHelper.calcDirection(s1.getArea(), s2.getArea(), false );                 
            }

            if( finish.direction == EnumDirection.NONE ) {
                finish.direction = PathHelper.calcDirection(s2.getArea(), s1.getArea(), true );                 
            }

            _begin_endpoint = _draw_endpoint(canvas, begin, s1.getArea())!;
            _finish_endpoint = _draw_endpoint(canvas, finish, s2.getArea())!;

            DrawPosition p1 = _begin_endpoint.getDockingPosition(begin, s1.getArea());
            DrawPosition p2 = _finish_endpoint.getDockingPosition(finish, s2.getArea());
            
            _debug(s1.uid, string.Format("area({0})|position({1})", s1.getArea().ToString(), p1.ToString()));
            _debug(s2.uid, string.Format("area({0})|position({1})", s2.getArea().ToString(), p2.ToString()));

            _draw_path(canvas, p1, p2, s1.getArea(), s2.getArea());
        }

        public override bool check(DrawPosition position) { 
            BaseShape s1 = manager.get(begin.uid)!;
            BaseShape s2 = manager.get(finish.uid)!;

            if( _begin_endpoint.check(position, begin, s1.getArea())) { 
                _select = "begin";
                return true;
            }
            if( _finish_endpoint.check(position, finish, s2.getArea())) { 
                _select = "finish";
                return true;
            }

            _select = "none";
            return false; 
        }

        public override DrawArea getArea() { 
            BaseShape s1 = manager.get(begin.uid)!;
            BaseShape s2 = manager.get(finish.uid)!;

            if( _select == "begin" ) {
                return _begin_endpoint.getArea(begin, s1.getArea());
            } else if( _select == "finish" ) {
                return _finish_endpoint.getArea(finish, s2.getArea());
            } 

            return new DrawArea();
        }

        public override void update(DrawDiff diff) {
            BaseShape s1 = manager.get(begin.uid)!;
            BaseShape s2 = manager.get(finish.uid)!;

            if( _select == "begin" ) {
                _begin_endpoint.update(diff, begin, s1.getArea());
            } else if( _select == "finish" ) {
                _finish_endpoint.update(diff, finish, s2.getArea());
            } 
        } 

        public void releaseSelect() {
            _select = "none";
        }

        public void updateRelation(int uid) {
            if( begin.uid == 0 ) {
                begin.uid = uid;
            } else if( finish.uid == 0 ) {
                finish.uid = uid;
            }
         }

        public override bool isComplete() { 
            if( begin.uid > 0 && finish.uid > 0 ) {
                return true;
            }

            return false;
        }

        private void _draw_path(Canvas canvas, DrawPosition p1, DrawPosition p2, DrawArea a1, DrawArea a2) {
            BasePath? path = PathHelper.createPath(begin.direction, finish.direction);
            if( path != null ) {
                path.color = begin.pcolor;
                path.draw(canvas, p1, p2, a1, a2);
            }
        }

        private BaseEndpoint? _draw_endpoint(Canvas canvas, DrawEndpoint endpoint, DrawArea area) {
            BaseEndpoint? ep = PathHelper.creaetEndpoint(endpoint.type);
            if( ep != null ) {
                ep.color = begin.ecolor;
                ep.draw(canvas, endpoint, area);
                return ep;
            }

            return null;
        }
    }   
}