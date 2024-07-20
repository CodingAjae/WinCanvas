namespace WinCanvas {
    public class DocumentManager {
        private int _uid_sequence = 0;

        public int uidGenerate() {
            return ++ this._uid_sequence;
        }
    }
}