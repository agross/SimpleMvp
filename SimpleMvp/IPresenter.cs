using System;

namespace SimpleMvp
{
  public interface IPresenter<TView> : IDisposable
  {
    void AttachTo(TView view);
  }
}