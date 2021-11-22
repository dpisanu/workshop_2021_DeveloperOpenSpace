using System.Threading.Tasks;

namespace CommonControls.Views
{
    public interface IModalWindow : IView
    {
        Task ShowAsync();
    }
}