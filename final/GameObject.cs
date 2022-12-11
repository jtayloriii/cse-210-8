using Raylib_cs;
using System.Numerics;
class GameObject { //Initialzing objects with a position and velocity 
    public Vector2 Position { get; set; } = new Vector2(0, 0);
    public Vector2 Velocity { get; set; } = new Vector2(0, 0);

    virtual public void Draw() {
        // Base game objects do not have anything to draw
    }

    public void Move() {
        Vector2 NewPosition = Position;
        NewPosition.X += Velocity.X;
        NewPosition.Y += Velocity.Y;
        Position = NewPosition;
    }
}

class ColoredObject: GameObject { // Giving the objects colors
    public Color Color { get; set; }

    public ColoredObject(Color color) {
        Color = color;
    }
}

class GameSquare: ColoredObject { // Cgiving the squares a size
    public int Size { get; set; }

    public GameSquare(Color color, int size): base(color) {
        Size = size;
    }

    override public void Draw() {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, Size, Size, Color);
    }
}

class GameProjectile : ColoredObject { // giving shot projectiles a size
    public int Size { get; set; }

    public GameProjectile(Color color, int size): base(color) {
        Size = size;
    }

    override public void Draw() {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, Size, Size, Color);
    }
}

class GameCircle: ColoredObject { // giving the circles (saucers) a size

    public int Radius { get; set; }

    public GameCircle(Color color, int radius): base(color) {
        Radius = radius;
    }
    override public void Draw() {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, Radius, Color);
    }
}

class Player // keeping track of the score on the upper left hand corner
{
    public int points = 0;

    public void display() 
    {
        Raylib.DrawText($"Player points: {points}", 12, 34, 20, Color.WHITE);
    }
}