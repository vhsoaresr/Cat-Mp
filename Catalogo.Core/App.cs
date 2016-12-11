using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace Catalogo.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes().EndingWith("Service")
                            .AsInterfaces()
                            .RegisterAsLazySingleton();

            Mvx.ConstructAndRegisterSingleton<IMvxAppStart, AppStart>();

            RegisterAppStart(Mvx.Resolve<IMvxAppStart>());
        }
    }
}