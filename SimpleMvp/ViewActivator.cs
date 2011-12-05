using System;
using System.Linq;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ComponentActivator;
using Castle.MicroKernel.Context;

namespace SimpleMvp
{
  public class ViewActivator : DefaultComponentActivator
  {
    public ViewActivator(ComponentModel model, IKernel kernel, ComponentInstanceDelegate onCreation, ComponentInstanceDelegate onDestruction)
      : base(model, kernel, onCreation, onDestruction)
    {
    }

    protected override object CreateInstance(CreationContext context, ConstructorCandidate constructor, object[] arguments)
    {
      var instance = base.CreateInstance(context, constructor, arguments);
      AttachPresenter(instance, arguments, context.RequestedType);
      return instance;
    }

    private void AttachPresenter(object instance, object[] arguments, Type requestedType)
    {
      var view = instance as IView;
      if (view == null || arguments == null)
      {
        return;
      }

      var presenterType = typeof (IPresenter<>).MakeGenericType(requestedType);

      var presenter = arguments.FirstOrDefault(presenterType.IsInstanceOfType);
      if (presenter == null)
      {
        return;
      }

      presenter.GetType().GetMethod("AttachTo").Invoke(presenter, new object[]{view});
    }
  }
}