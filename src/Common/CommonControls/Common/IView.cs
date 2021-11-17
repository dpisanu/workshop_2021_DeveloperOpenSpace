namespace CommonControls.Common
{
    public interface IView
    {
        /// <summary>
        ///     Content of the view. Also known as DataContext
        /// </summary>
        object Content { get; set; }
    }
}