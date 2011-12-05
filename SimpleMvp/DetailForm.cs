using System;
using System.Windows.Forms;

namespace SimpleMvp
{
  public partial class DetailForm : Form, IDetailView
  {
    private readonly IPresenter<IDetailView> _presenter;

    public DetailForm()
    {
      InitializeComponent();
    }

    public DetailForm(string article) : this()
    {
      if (!DesignMode)
      {
        _presenter = IoC.Resolve<IPresenter<IDetailView>>(new {view = this, article = article});
      }
    }

    public event EventHandler CloseClick;

    public void ShowDetails(string article)
    {
      lblLabel.Text = article;
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
      IoC.Release(_presenter);
      base.OnFormClosed(e);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      Raise.Event(CloseClick, this);
    }
  }
}