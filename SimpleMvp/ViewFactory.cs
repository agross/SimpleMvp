using System.Windows.Forms;
using Castle.Windsor;

namespace SimpleMvp
{
  class ViewFactory : IViewFactory
  {
    private readonly IWindsorContainer _container;

    public ViewFactory(IWindsorContainer container)
    {
      _container = container;
    }

    public TView Create<TView>(object additionalArgumentsAsAnonymousType)
    {
      return _container.Resolve<TView>(additionalArgumentsAsAnonymousType ?? new { });
    }
    
    public void Release(object instance)
    {
      _container.Release(instance);
    }

    public void ShowDialog(IView newForm, object parent)
    {
      var theForm = newForm;
      theForm.ShowDialog((IWin32Window) parent);
    }
  }
}