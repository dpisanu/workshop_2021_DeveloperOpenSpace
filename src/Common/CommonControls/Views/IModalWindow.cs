using System.Threading.Tasks;

namespace Common.CommonControls.Views
{
    public interface IModalWindow : IView
    {
        Task ShowAsync();
    }
}