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

            var projectiles = new List<GameObject>();

            // 

            Console.WriteLine("Defend your cargo ships!! (BLUE) Ram or shoot down the enemy flying saucers!! (RED)");

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "GameObject");
            Raylib.SetTargetFPS(40);

            for (int i = 0; i < 20; i++)
            {
                createObject(ScreenWidth, ScreenHeight, rectangleObjects, circleObjects);
            }

            if (!Raylib.WindowShouldClose())
            {
                while (!Raylib.WindowShouldClose()) 
                {
                    playerPoints.display();

                    // Player rectangle key inputs with draw player func.

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

                    // Collision check, bottom-of-screen hit check, with create new objects after them (RECTANGLE)

                    for (int i = rectangleObjects.Count - 1; i > 0; i--)
                    {
                        if (Raylib.CheckCollisionCircleRec(rectangleObjects[i].Position, 20, PlayerRectangle))
                        {
                            playerPoints.points -= 1;
                            rectangleObjects.RemoveAt(i);
                            i--;
                            createObject(ScreenWidth, ScreenHeight, rectangleObjects, circleObjects);
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
                                createObject(ScreenWidth, ScreenHeight, rectangleObjects, circleObjects);
                            }
                        }
                    }

                    // Collision check, bottom-of-screen hit check, with create new objects after them (CIRCLE)

                    for (int i = circleObjects.Count - 1; i > 0; i--)
                    {
                        if (Raylib.CheckCollisionCircleRec(circleObjects[i].Position, 20, PlayerRectangle))
                        {
                            playerPoints.points += 1;
                            circleObjects.RemoveAt(i);
                            i--;
                            createObject(ScreenWidth, ScreenHeight, rectangleObjects, circleObjects);
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
                                createObject(ScreenWidth, ScreenHeight, rectangleObjects, circleObjects);
                            }
                        }
                    }

                    // input for projectile with collision checks

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) {
                        createProjectile(projectiles, PlayerRectangle);
                    }

                    for (int i = circleObjects.Count - 1; i > 0; i--)
                    {
                        for (int j = projectiles.Count - 1; j > 0; j--)
                        {
                            var projectilePosition = projectiles[j].Position;
                            var projectileRectangle = new Rectangle(projectilePosition.X, projectilePosition.Y, 5, 5);

                            if ((Raylib.CheckCollisionCircleRec(circleObjects[i].Position, 20, projectileRectangle)) && (circleObjects[i] != null)) 
                            {
                                playerPoints.points += 1;
                                circleObjects.RemoveAt(i);
                                projectiles.RemoveAt(j);
                                createCircle(ScreenWidth, ScreenHeight, rectangleObjects, circleObjects);
                            }
                        }
                    }

                    for (int i = rectangleObjects.Count - 1; i > 0; i--)
                    {
                        for (int j = projectiles.Count - 1; j > 0; j--)
                        {
                            var projectilePosition = projectiles[j].Position;
                            var projectileRectangle = new Rectangle(projectilePosition.X, projectilePosition.Y, 5, 5);

                            if ((Raylib.CheckCollisionCircleRec(rectangleObjects[i].Position, 20, projectileRectangle)) && (rectangleObjects[i] != null)) 
                            {
                                playerPoints.points -= 1;
                                rectangleObjects.RemoveAt(i);
                                projectiles.RemoveAt(j);


                                // For some reason, the positioning of the projectiles are completely different
                                // when "singled out," so there doesn't seem to be a simple way of comparing their
                                // distances between each other.


                                // for (int k = projectiles.Count - 1; k > 0; k--)
                                // {
                                //     var secondPosition = projectiles[k].Position;
                                //     int firstx = (int) projectilePosition.X;
                                //     int firsty = (int) projectilePosition.Y;
                                //     int secondx = (int) secondPosition.X;
                                //     int secondy = (int) secondPosition.Y + 800; // I have no real idea why this works other than 
                                //                                                 // this y must come from the bottom of the screen?
                                //     if ((-100 < (secondx - firstx)) && ((secondx - firstx) < 100) && 
                                //     (-250 > (secondy - firsty)) && ((secondy - firsty) < 250)) 
                                //     {
                                //         Console.WriteLine($"colliding projectile x: {firstx}");
                                //         Console.WriteLine($"colliding projectile y: {firsty}");
                                //         Console.WriteLine($"other projectile x: {secondx}");
                                //         Console.WriteLine($"other projectile y: {secondy}");
                                //         projectiles.RemoveAt(k);
                                //         --j;
                                //     }
                                // }

                                createRectangle(ScreenWidth, ScreenHeight, rectangleObjects, circleObjects);
                            }
                        }
                    }

                    foreach (var obj in projectiles) {
                        obj.Draw();
                    }
                    foreach (var obj in projectiles) {
                        obj.Move();
                    }


                    //
                    

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
            var randomScreenY = rdm.Next(-150, 0);

            var whichType = rdm.Next(2);
            var position = new Vector2(randomScreenX, randomScreenY);

            switch (whichType) 
            {
                case 0:
                    var square = new GameSquare(Color.BLUE, 20);
                    square.Position = position;
                    square.Velocity = new Vector2(0, 1);   // square.Velocity = new Vector2(randomX, randomY);
                    rectangleObjects.Add(square);
                    break;
                case 1:
                    var circle = new GameCircle(Color.RED, 10);
                    circle.Position = position;
                    circle.Velocity = new Vector2(0, 2);   // circle.Velocity = new Vector2(randomX, randomY);
                    circleObjects.Add(circle);
                    break;
                default:
                    break;
            }
        }

        public static void createCircle(int ScreenWidth, int ScreenHeight, List<GameObject> rectangleObjects, List<GameObject> circleObjects)
        {
            // 

            var randomScreenX = rdm.Next(0, ScreenWidth);
            var randomScreenY = -50;

            var position = new Vector2(randomScreenX, randomScreenY);

            var circle = new GameCircle(Color.RED, 10);
            circle.Position = position;
            circle.Velocity = new Vector2(0, 1);
            circleObjects.Add(circle);
        }
        public static void createRectangle(int ScreenWidth, int ScreenHeight, List<GameObject> rectangleObjects, List<GameObject> circleObjects)
        {
            // 

            var randomScreenX = rdm.Next(0, ScreenWidth);
            var randomScreenY = -50;

            var position = new Vector2(randomScreenX, randomScreenY);

            var square = new GameSquare(Color.BLUE, 20);
            square.Position = position;
            square.Velocity = new Vector2(0, 1);   // square.Velocity = new Vector2(randomX, randomY);
            rectangleObjects.Add(square);
        }

        public static void createProjectile(List<GameObject> projectiles, Rectangle playerRectangle)
        {
            // 

            var ScreenX = playerRectangle.x;
            var ScreenY = playerRectangle.y - 5;
            var position = new Vector2(ScreenX, ScreenY);

            var bullet = new GameProjectile(Color.YELLOW, 5);
            bullet.Position = position;
            bullet.Velocity = new Vector2(0, -6);   
            projectiles.Add(bullet);

        }
    }
}
