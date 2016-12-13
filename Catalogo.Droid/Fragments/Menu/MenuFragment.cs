using System.Collections.ObjectModel;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Catalogo.Core.ViewModels;
using Catalogo.Droid.Activities;
using Catalogo.Models;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Core.ViewModels;

namespace Catalogo.Droid.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.navigation_frame)]
    [Register("catalogo.droid.fragments.MenuFragment")]
    public class MenuFragment : MvxFragment<MenuViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.fragment_navigation, null);

            var navList = view.FindViewById<MvxListView>(Resource.Id.navigation_listview);
            navList.ItemClick = new MvxCommand<Categoria>(Filtrar);


            var textCategories = view.FindViewById<TextView>(Resource.Id.textview_all_categories);
            textCategories.Click += (sender, args) => { Filtrar(null); };

            return view;
        }

        private void Filtrar(Categoria categoria)
        {
            var baseFrag = (BaseFragment)Activity.SupportFragmentManager.FindFragmentById(Resource.Id.content_frame);

            if (baseFrag.GetType() == typeof(CatalogoFragment))
            {
                var viewModel = ((CatalogoFragment)baseFrag).ViewModel;
                viewModel.Produtos = categoria == null ? viewModel.AllProdutos : new ObservableCollection<Produto>(viewModel.AllProdutos.Where(p => p.CategoryId == categoria.Id));
            }
            else
            {
                ((MainActivity)Activity).ViewModel.ShowViews();
            }


            ((MainActivity)Activity).DrawerLayout?.CloseDrawers();
        }
    }
}
