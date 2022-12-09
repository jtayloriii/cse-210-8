using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                // HandleFoodCollisions(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        // private void HandleFoodCollisions(Cast cast)
        // {
        //     Snake snake = (Snake)cast.GetFirstActor("snake");
        //     Score score = (Score)cast.GetFirstActor("score");
        //     Food food = (Food)cast.GetFirstActor("food");
            
        //     if (snake.GetHead().GetPosition().Equals(food.GetPosition()))
        //     {
        //         int points = food.GetPoints();
        //         snake.GrowTail(points);
        //         score.AddPoints(points);
        //         food.Reset();
        //     }
        // }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Actor head = snake.GetHead();
            List<Actor> body = snake.GetBody();

            Snake2 snake2 = (Snake2)cast.GetFirstActor("snake2");
            Actor head2 = snake2.GetHead();
            List<Actor> body2 = snake2.GetBody();

            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                }

                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                }
            }

            // foreach (Actor segment in body2)
            // {
            //     foreach (Actor segment in body)
            //         {
            //             if (segment.GetPosition().Equals(head2.GetPosition()))
            //             {

            //             }
            //             if (segment.GetPosition().Equals(head.GetPosition())) 
            //             {

            //             }
            //         }
            // }

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                }

                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                }
            }
        }

        public bool HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                Snake2 snake2 = (Snake2)cast.GetFirstActor("snake2");
                List<Actor> segments = snake.GetSegments();
                List<Actor> segments2 = snake2.GetSegments();
                // Food food = (Food)cast.GetFirstActor("food");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = (Constants.MAX_Y / 2) + 20;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }

                foreach (Actor segment in segments2)
                {
                    segment.SetColor(Constants.WHITE);
                }
                snake.SetColor(Constants.WHITE);
                snake2.SetColor(Constants.WHITE);
                // food.SetColor(Constants.WHITE);
                return true;
            }

            return false;
        }

    }
}