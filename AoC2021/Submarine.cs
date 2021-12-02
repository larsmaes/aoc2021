using System.Drawing;
using System;


namespace AoC2021;

public class Submarine
{

  private int _x = 0;
  public int X { get => _x; }
  private int _z = 0;
  public int Z { get => _z; }
  private int _aim = 0;
  public int Aim { get => _aim; }

  public int Depth
  {
    get
    {
      return Math.Abs(Z);
    }
  }

  [Obsolete("Move is wrong, please use MoveWithAim")]
  public void Move(string direction, int distance)
  {
    switch (direction)
    {
      case "forward":
        this._x += distance;
        break;
      case "down":
        this._z -= distance;
        break;
      case "up":
        this._z += distance;
        break;
    }
  }

  public void MoveWithAim(string direction, int distance)
  {
    switch (direction)
    {
      case "forward":
        this._x += distance;
        this._z -= distance * _aim;
        break;
      case "down":
        this._aim += distance;
        break;
      case "up":
        this._aim -= distance;
        break;
    }
  }




}