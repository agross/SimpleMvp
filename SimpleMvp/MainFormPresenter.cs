using System;
using System.Windows.Forms;

namespace SimpleMvp
{
  internal class MainFormPresenter : IPresenter<IMainFormView>
  {
    private readonly IArticleRepository _articles;
    private readonly IViewFactory _views;
    private IMainFormView _view;

    public MainFormPresenter(IArticleRepository articles, IViewFactory views)
    {
      _articles = articles;
      _views = views;
    }

    private void View_CloseClick(object sender, EventArgs e)
    {
      _view.Close();

      Application.Exit();
    }

    private void View_DetailsClick(object sender, EventArgs eventArgs)
    {
      var article = _view.GetSelectedArticle();

      if (article == null)
      {
        return;
      }

      var details = _views.Create<IDetailView>(new {article = article});
      _views.ShowDialog(details, _view);
      _views.Release(details);
    }

    public void AttachTo(IMainFormView view)
    {
      _view = view;

      _view.DetailsClick += View_DetailsClick;
      _view.CloseClick += View_CloseClick;

      _view.ShowArticles(_articles.GetAll());
    }

    public void Dispose()
    {
      _view.CloseClick -= View_CloseClick;
      _view.DetailsClick -= View_DetailsClick;
    }
  }
}