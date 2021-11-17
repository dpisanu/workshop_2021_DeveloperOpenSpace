namespace CommonControls.Common
{
    public interface IWindow : IView
    {
        bool IsEnabled { get; set; }
        void Show();
        void Close();
        bool Focus();
    }
}