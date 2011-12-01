using System;
using System.Windows.Forms;

namespace SimpleMvp
{
  internal interface IView
  {
    DialogResult ShowDialog(IWin32Window parent);
  }

  internal interface IDetailView : IView
  {
    event EventHandler CloseClick;
    void Close();
    void ShowDetails(string article);
  }
}