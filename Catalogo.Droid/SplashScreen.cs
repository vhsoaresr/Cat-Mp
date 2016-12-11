using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace Catalogo.Droid
{
    [Activity(
		Label = "Catálogo Meus Pedidos"
		, MainLauncher = true
		, Icon = "@drawable/Icon"
		, Theme = "@style/AppTheme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen() : base(Resource.Layout.splash_screen)
        {
        }
    }
}