using Castle.Windsor;

namespace SimpleMvp
{
  public static class IoC
  {
    private static IWindsorContainer _container;

    public static T Resolve<T>()
    {
      return Resolve<T>(new {});
    }

    public static T Resolve<T>(object additionalArgumentsAsAnonymousType)
    {
      return (T) _container.Resolve(typeof(T), additionalArgumentsAsAnonymousType);
    }

    public static void SetContainer(IWindsorContainer container)
    {
      _container = container;
    }

    public static void Release(object instance)
    {
      _container.Release(instance);
    }
  }
}