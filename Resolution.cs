namespace Managers
{
    public struct Resolution
    {
        public int Width;
        public int Height;
        public bool IsFullScreen;

        public Resolution(int width, int height, bool isFullScreen)
        {
            Width = width;
            Height = height;
            IsFullScreen = isFullScreen;
        }

        public override string ToString()
        {
            return $"W: {Width} x H: {Height} x FullScreen: {IsFullScreen}";
        }
    }
}
