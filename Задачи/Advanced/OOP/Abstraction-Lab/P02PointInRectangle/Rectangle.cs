namespace P02PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            var accordingToX = point.X >= TopLeft.X && BottomRight.X >= point.X;
            var accordingToY = point.Y >= BottomRight.Y && TopLeft.Y >= point.Y;

            return accordingToX && accordingToY;

        }
    }
}
