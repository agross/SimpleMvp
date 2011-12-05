using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SimpleMvp
{
  public partial class MainForm : Form, IMainFormView
  {
    private readonly IPresenter<IMainFormView> _presenter;

    public MainForm()
    {
      InitializeComponent();
    }

    public MainForm(IPresenter<IMainFormView> presenter) : this()
    {
      _presenter = presenter;
    }
    
    public void ShowArticles(IEnumerable<string> articles)
    {
      lbxArticles.Items.Clear();
      lbxArticles.Items.AddRange(articles.ToArray());
    }

    public event EventHandler DetailsClick;
    public event EventHandler CloseClick;

    public string GetSelectedArticle()
    {
      return lbxArticles.SelectedItem as string;
    }

    private void btnDetails_Click(object sender, EventArgs e)
    {
      Raise.Event(DetailsClick, this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      Raise.Event(CloseClick, this);
    }

    private void lbxArticles_DoubleClick(object sender, EventArgs e)
    {
      btnDetails_Click(sender, e);
    }
  }
}