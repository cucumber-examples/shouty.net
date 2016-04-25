using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouty
{
  public class ShoutyNetwork
  {
    private Dictionary<string, Coordinate> locationsByPerson = new Dictionary<string, Coordinate>();
    private Dictionary<string, string> messagesByPerson = new Dictionary<string, string>();
    private const int MESSAGE_RANGE = 1000;
    
    public void SetLocation(string personName, Coordinate coordinate)
    {
      locationsByPerson.Add(personName, coordinate);
    }

    public void Shout(string shouterName, string message)
    {
      messagesByPerson.Add(shouterName, message);
    }

    public IDictionary<string, string> GetMessagesHeardBy(string listenerName)
    {
      var result = new Dictionary<string, string>();

      foreach(var shout in messagesByPerson)
      {
        var shouter = shout.Key;
        var message = shout.Value;

        int distance = locationsByPerson[shouter].
          DistanceFrom(locationsByPerson[listenerName]);

        if (distance < MESSAGE_RANGE)
          result.Add(shouter, message);
      }

      return result;
    }
  }
}
