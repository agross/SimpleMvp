using System.Windows.Forms;

namespace SimpleMvp
{
  class ViewFactory : IViewFactory
  {
    public TView Create<TView>(object additionalArgumentsAsAnonymousType)
    {
      return IoC.Resolve<TView>(additionalArgumentsAsAnonymousType ?? new {});
    }

    public void ShowDialog(IView newForm, object parent)
    {
      var theForm = newForm;
      theForm.ShowDialog((IWin32Window) parent);
    }
  }
}