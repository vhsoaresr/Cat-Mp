namespace Catalogo.Core.ViewModels
{
	public class MainViewModel : BaseViewModel
    {
        public void ShowViews()
        {
            ShowViewModel<CatalogoViewModel>();          
            ShowViewModel<MenuViewModel>();          
        }
    }
}