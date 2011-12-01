using System;
using System.Collections.Generic;
using System.Linq;
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
                           Component.For<IArticleRepository>().ImplementedBy<ArticleRepository>(),
                           Component.For<IViewFactory>().ImplementedBy<ViewFactory>(),
                           Component.For<IMainFormView>().ImplementedBy<MainForm>().LifestyleTransient(),
                           Component.For<IDetailView>().ImplementedBy<DetailForm>().LifestyleTransient(),
                           Component.For<IPresenter<IMainFormView>>().ImplementedBy<MainFormPresenter>().LifestyleTransient(),
                           Component.For<IPresenter<IDetailView>>().ImplementedBy<DetailFormPresenter>().LifestyleTransient()
                         });

      IoC.SetContainer(container);

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}
