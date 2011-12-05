using System;

namespace SimpleMvp
{
  internal class DetailFormPresenter : IPresenter<IDetailView>
  {
    private readonly IArticleRepository _articles;
    private IDetailView _view;

    public DetailFormPresenter(IArticleRepository articles)
    {
      _articles = articles;
    }

    private void View_CloseClick(object sender, EventArgs eventArgs)
    {
      _view.Close();
    }

    public void AttachTo(IDetailView view)
    {
      _view = view;

      _view.CloseClick += View_CloseClick;
      _view.RequestShowArticle += (sender, args) => _view.ShowDetails(args.Article);
    }

    public void Dispose()
    {
      _view.CloseClick -= View_CloseClick;
    }
  }
}