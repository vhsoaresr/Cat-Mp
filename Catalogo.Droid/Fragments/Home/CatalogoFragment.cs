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
        protected override int FragmentId => Resource.Layout.fragment_catalogoview;
    }
}