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
        protected override int FragmentId => Resource.Layout.fragment_detalhamentoview;
    }
}