using System;
using System.Linq;
class Util
{
  static string[] compass = { "N", "E", "S", "W" };



  //confirms the formatting of the the user inputed grid bounds
  public static bool parseBounds(string input)
  {
    string[] bounds = input.Split(' ');

    if (bounds.Length != 2 ||
    !Int32.TryParse(bounds[0], out int suc) ||
    suc < 0 ||
    !Int32.TryParse(bounds[1], out suc) ||
    suc < 0)
    {
      return false;
    }

    return true;
  }


  public static bool parseInitPos(string pos, int w, int h)
  {
    string[] tuple = pos.Split(' ');
    if (tuple.Length != 3 || !(compass.Contains(tuple[2])))
    {
      return false;
    }
    if (Int32.TryParse(tuple[0], out int suc) &&
     suc >= 0 && suc <= w &&
     Int32.TryParse(tuple[1], out suc) &&
     suc >= 0 && suc <= h)
    {
      return true;
    }
    return false;
  }


}