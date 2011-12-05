using System;
using System.Collections.Generic;

namespace SimpleMvp
{
  public interface IMainFormView : IView
  {
    void ShowArticles(IEnumerable<string> articles);
    event EventHandler DetailsClick;
    event EventHandler CloseClick;
    string GetSelectedArticle();
    void Close();
  }
}