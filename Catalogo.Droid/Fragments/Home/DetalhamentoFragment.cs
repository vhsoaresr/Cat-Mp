using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using Catalogo.Core.ViewModels;
using Catalogo.Droid.Activities;
using MvvmCross.Binding.Droid.BindingContext;

namespace Catalogo.Droid.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("catalogo.droid.fragments.DetalhamentoFragment")]
    public class DetalhamentoFragment : BaseFragment<DetalhamentoViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(FragmentId, null);
            Toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);

            if (Toolbar == null) return view;

            if (ParentActivity == null) return view;

            ParentActivity.SetSupportActionBar(Toolbar);
            ParentActivity.SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            ParentActivity.SupportActionBar?.SetDisplayShowHomeEnabled(true);

            return base.OnCreateView(inflater, container, savedInstanceState);        
        }

        protected override int FragmentId => Resource.Layout.fragment_detalhamentoview;
    }
}