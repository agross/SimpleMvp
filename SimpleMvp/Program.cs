using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace SimpleMvp
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      var container = new WindsorContainer();
      container.Register(new IRegistration[]
                         {
                           Component.For<IWindsorContainer>().Instance(container),
                           Component.For<IArticleRepository>().ImplementedBy<ArticleRepository>(),
                           Component.For<IViewFactory>().ImplementedBy<ViewFactory>(),
                           AllTypes
                             .FromThisAssembly()
                             .IncludeNonPublicTypes()
                             .BasedOn(typeof(IPresenter<>))
                             .WithService.FromInterface()
                             .LifestyleTransient(),
                           AllTypes
                             .FromThisAssembly()
                             .Where(t => t.Name.EndsWith("Form"))
                             .WithService.Select((type, baseTypes) => type.GetInterfaces().Where(x => x.Name != "IView" && x.Name.EndsWith("View")))
                             .LifestyleTransient()
                             .Configure(r => r.Activator<ViewActivator>())
                         });

      IoC.SetContainer(container);

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var viewFactory = container.Resolve<IViewFactory>();
      var mainForm = viewFactory.Create<IMainFormView>(null);
      viewFactory.ShowDialog(mainForm, null);
      
      Application.Run();

      viewFactory.Release(mainForm);
    }
  }
}
