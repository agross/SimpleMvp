namespace SimpleMvp
{
  interface IViewFactory
  {
    TView Create<TView>(object additionalArgumentsAsAnonymousType);
    void ShowDialog(IView newForm, object parent);
  }
}