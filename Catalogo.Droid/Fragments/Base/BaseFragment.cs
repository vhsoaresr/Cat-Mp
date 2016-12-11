using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Catalogo.Droid.Activities;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;

namespace Catalogo.Droid.Fragments
{
    public abstract class BaseFragment : MvxFragment
    {
        protected BaseFragment()
        {
            RetainInstance = true;
        }
        public MvxCachingFragmentCompatActivity ParentActivity => ((MvxCachingFragmentCompatActivity)Activity);
        protected Toolbar Toolbar { get; set; }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(FragmentId, null);

            Toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar == null) return view;

            if (ParentActivity == null) return view;

            ParentActivity.SetSupportActionBar(Toolbar);
            ParentActivity.SupportActionBar?.SetDisplayShowTitleEnabled(false);

            return view;
        }

        protected abstract int FragmentId { get; }
    }

    public abstract class BaseFragment<TViewModel> : BaseFragment where TViewModel : class, IMvxViewModel
    {
        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}

