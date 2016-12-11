using Catalogo.Core.ViewModels;
using MvvmCross.Core.ViewModels;

namespace Catalogo.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public void Start(object hint = null)
        {
            ShowViewModel<MainViewModel>();
        }
    }
}