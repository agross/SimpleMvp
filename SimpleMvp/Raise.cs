using System;

namespace SimpleMvp
{
  public static class Raise
  {
    public static void Event(EventHandler eventToRaise, object sender)
    {
      var temp = eventToRaise;
      if (temp != null)
      {
        temp(sender, EventArgs.Empty);
      }
    }
    
    public static void Event(EventHandler<EventArgs> eventToRaise, object sender)
    {
      var temp = eventToRaise;
      if (temp != null)
      {
        temp(sender, EventArgs.Empty);
      }
    }

    public static void Event<TEventArgs>(EventHandler<TEventArgs> eventToRaise, object sender, TEventArgs e)
      where TEventArgs : EventArgs
    {
      var temp = eventToRaise;
      if (temp != null)
      {
        temp(sender, e);
      }
    }
  }
}