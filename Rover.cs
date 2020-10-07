using System;
using System.Linq;
class Rover
{
  //rover's x-axis position
  public int x;
  //rover's y-axis position
  public int y;
  //width bounds 
  public int w;
  //height bounds
  public int h;
  //rover's direction
  public int head;
  //compass structure
  static string[] compass = { "N", "E", "S", "W" };

  public Rover(string pos, int w, int h)
  {
    this.w =w;
    this.h =h;
    string[] args = pos.Split(null);
    this.x = int.Parse(args[0]);
    this.y = int.Parse(args[1]);
    switch (args[2])
    {
      case "N":
        this.head = 0;
        break;
      case "E":
        this.head = 1;
        break;
      case "S":
        this.head = 2;
        break;
      case "W":
        this.head = 3;
        break;
      default:
        //bad input
        break;
    }
  }

  public bool moveRover(string commands)
  {
    foreach (var command in commands)
    {
      switch (command)
      {
        case 'L':
          rotate('L');
          break;
        case 'R':
          rotate('R');
          break;
        case 'M':
          if (!advance())
          {
            Console.WriteLine("Rover fell off the edge!");
            return false;
          }
          break;
        default:
          //illegal commands from NASA
          Console.WriteLine("The rover's commands were inproperly formatted");
          return false;
      }
    }
    return true;
  }


  public void printLocation()
  {
    Console.WriteLine(String.Format("{0} {1} {2}", this.x, this.y, compass[this.head]));

  }


  void rotate(char dir)
  {
    if (dir == 'L')
    {
      if (this.head == 0) this.head = 3;
      else
      {
        this.head = this.head - 1;
      }
    }
    else if (dir == 'R')
    {
      this.head = (this.head + 1) % 4;
    }
    else
    {
      Console.WriteLine("Internal program error: reached illegal state");
    }

  }

  bool advance()
  {
    //check if out of bounds?
    switch (this.head)
    {
      case 0:
        if (y == this.h)
        {
          //rover fell off the north edge
          return false;

        }
        this.y = this.y + 1;
        break;
      case 1:
        if (x == this.w)
        {
          //rover fell off the east edge
          return false;

        }
        this.x = this.x + 1;
        break;
      case 2:
        if (y == 0)
        {
          //rover fell off the south edge
          return false;

        }
        this.y = this.y - 1;
        break;
      case 3:
        if (x == 0)
        {
          //rover fell off the west edge
          return false;

        }
        this.x = this.x - 1;
        break;
      default:
        Console.WriteLine("Internal program error: reached illegal state");
        return false;
    }
    return true;
  }
}
