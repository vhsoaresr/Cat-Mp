using Catalogo.Services;
using MvvmCross.Core.ViewModels;

namespace Catalogo.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        public readonly IDataService DataService;
        public BaseViewModel() { }
        public BaseViewModel(IDataService dataService)
        {
            DataService = dataService;
        }
    }
}
