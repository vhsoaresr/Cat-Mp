using System;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Catalogo.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platform.WeakSubscription;
using MvvmCross.Droid.Support.V4;

namespace Catalogo.Droid.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("catalogo.droid.fragments.CatalogoFragment")]
    public class CatalogoFragment : BaseFragment<CatalogoViewModel>
    {
        private IDisposable _itemSelectedToken;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            //var recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.my_recycler_view);
            //if (recyclerView != null)
            //{
            //    recyclerView.HasFixedSize = true;
            //    var layoutManager = new LinearLayoutManager(Activity);
            //    recyclerView.SetLayoutManager(layoutManager);
            //}

            //var swipeToRefresh = view.FindViewById<MvxSwipeRefreshLayout>(Resource.Id.refresher);
            //var appBar = Activity.FindViewById<AppBarLayout>(Resource.Id.appbar);
            //if (appBar != null)
            //    appBar.OffsetChanged += (sender, args) => swipeToRefresh.Enabled = args.VerticalOffset == 0;

            return view;
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            _itemSelectedToken?.Dispose();
            _itemSelectedToken = null;
        }

        protected override int FragmentId => Resource.Layout.fragment_catalogoview;
    }
}