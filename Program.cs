using System;
using System.Collections.Generic;
using System.IO;

namespace DealerOnTest
{
  class Program
  {
    //width bound
    static int w;
    //height bound
    static int h;
    

    static void Main(string[] args)
    {
      var linesIEnumerable = ReadFrom("input.txt");
      IEnumerator<string> lines = linesIEnumerable.GetEnumerator();
      lines.MoveNext();

      //initialize board size
      var boardsize = lines.Current;
      if (!Util.parseBounds(lines.Current))
      {
        Console.WriteLine("illegal bounds");
        return;
      }
      string boundsRaw = lines.Current;
      string[] bounds = boundsRaw.Split(' ');
      w = int.Parse(bounds[0]);
      h = int.Parse(bounds[1]);

      //initialize rover and execute commands

      while (true)
      {
        //advance to next rover
        if (!lines.MoveNext())
        {
          //end of input
          return;
        }
        //process initial position of rover 
        var initPos = lines.Current;
        if (!Util.parseInitPos(initPos, w, h))
        {
          //initial position from NASA was imporoperly formatted
          Console.WriteLine("The rover's initial position was inproperly formatted");
          if (!lines.MoveNext())
          {
            //end of input
            return;
          }
          continue;
        }

        //make the rover
        var rover = new Rover(initPos, w, h);

        //process commands to rover
        if (!lines.MoveNext())
        {
          //no commands given (end of input)
          return;
        }
        var commands = lines.Current;
        if (!rover.moveRover(commands))
        {
          //command string failed
          continue;
        };
        //output
        rover.printLocation();
      }
    }

    //reads the input file
    static IEnumerable<string> ReadFrom(string file)
    {
      string line;
      using (var reader = File.OpenText(file))
      {
        while ((line = reader.ReadLine()) != null)
        {
          yield return line;
        }
      }
    }
  }
}
