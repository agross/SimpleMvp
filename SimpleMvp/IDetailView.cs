using System;
using System.Windows.Forms;

namespace SimpleMvp
{
  public interface IView
  {
    DialogResult ShowDialog(IWin32Window parent);
  }

  public interface IDetailView : IView
  {
    event EventHandler CloseClick;
    void Close();
    void ShowDetails(string article);
    event EventHandler<ArticleEventArgs> RequestShowArticle;
  }

  public class ArticleEventArgs : EventArgs
  {
    public string Article { get; set; }
  }
}