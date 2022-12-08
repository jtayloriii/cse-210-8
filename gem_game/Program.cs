using Raylib_cs;
using System.Numerics;

namespace HelloWorld
{
    // May want/need to make two createObject functions with different list names to identify whether
    // you will either add or subtract points depending on which list (rock/gem) it is in. Then
    // randomly select between the two for object creation/re-creation
    static class Program
    {
        static Random rdm = new Random();

        public static void Main()
        {
            var ScreenHeight = 480;
            var ScreenWidth = 800;
            var circleObjects = new List<GameObject>();
            var rectangleObjects = new List<GameObject>();
            var playerPoints = new Player();

            // 

            var RectangleSize = 20;
            var PlayerRectangle = new Rectangle(ScreenWidth - (RectangleSize * 2), ScreenHeight - (RectangleSize * 2), RectangleSize - 8, RectangleSize - 5);
            var TargetRectangle = new Rectangle(100, 100, RectangleSize, RectangleSize);
            var MovementSpeed = 4;

            // 

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "GameObject");
            Raylib.SetTargetFPS(40);

            for (int i = 0; i < 20; i++)
            {
                createObject(ScreenWidth, ScreenHeight, circleObjects, rectangleObjects);
            }

            if (!Raylib.WindowShouldClose())
            {
                while (!Raylib.WindowShouldClose()) 
                {
                    playerPoints.display();

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
                        PlayerRectangle.x += MovementSpeed;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
                        PlayerRectangle.x -= MovementSpeed;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) {
                        PlayerRectangle.y -= MovementSpeed;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) {
                        PlayerRectangle.y += MovementSpeed;
                    }

                    Raylib.DrawRectangleRec(PlayerRectangle, Color.PURPLE);

                    for (int i = rectangleObjects.Count - 1; i > 0; i--)
                    {
                        if (Raylib.CheckCollisionCircleRec(rectangleObjects[i].Position, 20, PlayerRectangle))
                        {
                            playerPoints.points += 1;
                            rectangleObjects.RemoveAt(i);
                            i--;
                            createObject(ScreenWidth, ScreenHeight, circleObjects, rectangleObjects);
                        }

                        var X = 0;
                        var Y = 0;
                        var itemPosition = new Vector2(X, Y);
                        if ((rectangleObjects[i] != null) && (i < circleObjects.Count) && (i >= 0))
                        {
                            itemPosition = rectangleObjects[i].Position; //

                            if (itemPosition.Y > (ScreenHeight - 5))
                            {
                                rectangleObjects.RemoveAt(i);
                                i--;
                                createObject(ScreenWidth, ScreenHeight, circleObjects, rectangleObjects);
                            }
                        }
                    }

                    for (int i = circleObjects.Count - 1; i > 0; i--)
                    {
                        if (Raylib.CheckCollisionCircleRec(circleObjects[i].Position, 20, PlayerRectangle))
                        {
                            playerPoints.points -= 1;
                            circleObjects.RemoveAt(i);
                            i--;
                            createObject(ScreenWidth, ScreenHeight, circleObjects, rectangleObjects);
                        }
                        var X = 0;
                        var Y = 0;
                        var itemPosition = new Vector2(X, Y);
                        if ((circleObjects[i] != null) && (i < circleObjects.Count) && (i >= 0))
                        {
                            itemPosition = circleObjects[i].Position;
                            
                            if (itemPosition.Y > (ScreenHeight - 5))
                            {
                                circleObjects.RemoveAt(i);
                                i--;
                                createObject(ScreenWidth, ScreenHeight, circleObjects, rectangleObjects);
                            }
                        }
                    }
                    

                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.BLACK);

                    // Draw all of the objects in their current location
                    foreach (var obj in rectangleObjects) {
                        obj.Draw();
                    }

                    // Draw all of the objects in their current location
                    foreach (var obj in circleObjects) {
                        obj.Draw();
                    }

                    Raylib.EndDrawing();

                    foreach (var obj in rectangleObjects) {
                        obj.Move();
                    }
                    
                    // Move all of the objects to their next location
                    foreach (var obj in circleObjects) {
                        obj.Move();
                    }

                    // 

                }
            }
            Raylib.CloseWindow();
        }




        public static void createObject(int ScreenWidth, int ScreenHeight, List<GameObject> rectangleObjects, List<GameObject> circleObjects)
        {
            // 

            var randomScreenX = rdm.Next(0, ScreenWidth);
            var randomScreenY = rdm.Next(0, ScreenHeight);

            var whichType = rdm.Next(2);
            Console.WriteLine(whichType);
            var position = new Vector2(randomScreenX, randomScreenY);

            Console.WriteLine(position);
            switch (whichType) 
            {
                case 0:
                    Console.WriteLine("Creating a square");
                    var square = new GameSquare(Color.BLUE, 20);
                    square.Position = position;
                    square.Velocity = new Vector2(0, 1);   // square.Velocity = new Vector2(randomX, randomY);
                    rectangleObjects.Add(square);
                    break;
                case 1:
                    Console.WriteLine("Creating a circle");
                    var circle = new GameCircle(Color.RED, 10);
                    circle.Position = position;
                    circle.Velocity = new Vector2(0, 1);   // circle.Velocity = new Vector2(randomX, randomY);
                    circleObjects.Add(circle);
                    break;
                default:
                    break;
            }
        }
    }
}
