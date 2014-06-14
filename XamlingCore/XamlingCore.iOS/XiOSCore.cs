using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using MonoTouch.UIKit;
using XamlingCore.iOS.Navigation;
using XamlingCore.Portable.Contract.Glue;
using XamlingCore.Portable.View.ViewModel;

namespace XamlingCore.iOS
{
    public class XiOSCore<TRootVm, TInitialVM, TGlue> : XCore<TRootVm, TInitialVM, TGlue>
        where TRootVm : XRootViewModelBase
        where TInitialVM : XViewModel
        where TGlue : class, IGlue, new()
    {

        private iOSNavigator _navigator;

        public void Init()
        {
            var msr = new ManualResetEvent(false);

            Task.Run(async () =>
            {
                await InitRoot();
                _navigator = new iOSNavigator(RootVm.Navigation, RootVm.Container);
                msr.Set();
            });

            msr.WaitOne();

            
        }
    }

    public abstract class XCore<TRootVm, TInitialVM, TGlue> 
        where TRootVm : XRootViewModelBase
        where TInitialVM : XViewModel
        where TGlue : class, IGlue, new()
    {
        protected IContainer Container;
        protected TRootVm RootVm;

        protected async Task InitRoot()
            
        {
            var glue = new TGlue();
            glue.Init();

            Container = glue.Container;
            RootVm = Container.Resolve<TRootVm>();
            
            await RootVm.Init();
            var initalVm = RootVm.CreateContentModel<TInitialVM>();
            if (initalVm == null)
            {
                throw new Exception("Initial VM could not be resolved, ensure viewmodels are registered");
            }

            RootVm.NavigateTo(initalVm);
        }

        
    }
}