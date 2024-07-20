using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WinCanvas {
    public class TextShape: BaseShape {
        public string text { get; set; } = "";
        public int fontsize {get; set;} = 12;
        public string fontcolor { get; set; } = "#000000";
        public bool bold { get; set; } = false;
        public bool underline { get; set; } = false;
        public bool italic { get; set; } = false;

        public TextShape( int x, int y, string text ) {
            this.position = new DrawPosition(x,y);
            this.text = text;
        }
        
        public override string getType() { return "font"; }
        public override void draw(Canvas canvas) {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.FontSize = fontsize;
            textBlock.Foreground = new SolidColorBrush(hex2color(fontcolor));      
            textBlock.FontWeight = FontWeight.FromOpenTypeWeight(bold?700:400);      
            Canvas.SetLeft(textBlock, position.x);
            Canvas.SetTop(textBlock, position.y);
            
            canvas.Children.Add(textBlock);
        }
    }
}