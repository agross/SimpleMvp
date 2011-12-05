using System;
using System.Windows.Forms;

namespace SimpleMvp
{
  public partial class DetailForm : Form, IDetailView
  {
    private readonly IPresenter<IDetailView> _presenter;
    private readonly string _article;

    public DetailForm()
    {
      InitializeComponent();
    }

    public DetailForm(IPresenter<IDetailView> presenter, string article) : this()
    {
      _presenter = presenter;
      _article = article;
    }

    public event EventHandler CloseClick;
    public event EventHandler<ArticleEventArgs> RequestShowArticle;

    public void ShowDetails(string article)
    {
      lblLabel.Text = article;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      Raise.Event(CloseClick, this);
    }

    private void DetailForm_Load(object sender, EventArgs e)
    {
      Raise.Event(RequestShowArticle, this, new ArticleEventArgs {Article = _article});
    }
  }
}