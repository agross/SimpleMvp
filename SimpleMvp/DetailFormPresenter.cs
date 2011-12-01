using System;

namespace SimpleMvp
{
  internal class DetailFormPresenter : IPresenter<IDetailView>
  {
    private readonly IDetailView _view;
    private readonly IArticleRepository _articles;

    public DetailFormPresenter(IDetailView view, IArticleRepository articles, string article)
    {
      _view = view;
      _articles = articles;

      _view.ShowDetails(article);

      _view.CloseClick +=View_CloseClick;
    }

    private void View_CloseClick(object sender, EventArgs eventArgs)
    {
      _view.Close();
    }

    public void Dispose()
    {
      _view.CloseClick -= View_CloseClick;
    }
  }
}