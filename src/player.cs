using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace sunshine_shivers
{
    internal class Player
    {
        //private bool keyLeftPressed = false;
        //private bool keyRightPressed = false;
        //private bool keyDownPressed = false;
        //private bool keyUpPressed = false;

        //private double hitbox = 0.3;

        private double accelerationX;
        private double accelerationY;

        public double positionX;
        public double positionY;

        public int facing = 0;


        public void updatePosition(int[,] world)
        {
            int[] walkableTiles = { 0, 1};

            // acceleration vector
            int x = 0;
            int y = 0;
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) y++;
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) y--;
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) x--;
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) x++;

            Vector2 direction = new Vector2(x,y);
            if (x != 0 || y != 0) direction = Vector2.Normalize(direction);
            System.Diagnostics.Debug.WriteLine(direction.X);
            accelerationX += 0.018*direction.X;
            accelerationY += 0.018*direction.Y;
            // induce a friction
            accelerationX *= 0.82;
            accelerationY *= 0.82;

            // prevent drifting
            if (direction.X == 0 && accelerationX*accelerationX < 0.0001) accelerationX = 0;
            if (direction.Y == 0 && accelerationY * accelerationY < 0.0001) accelerationY = 0;

            positionX += accelerationX;
            positionY += accelerationY;

            // calculate facing angle
            if (x != 0 || y != 0) facing = (int)Math.Round(4 * (1 + Math.Atan2(accelerationX, accelerationY) / Math.PI));
            if (facing == 8) facing = 0;

            //if (Keyboard.GetState().IsKeyDown(Keys.Left))
            //{
            //    int tileId = world[(int)(positionX - hitbox), (int)positionY];
            //    if (keyLeftPressed == false && walkableTiles.Contains(tileId)) positionX -= 1.0;
            //    keyLeftPressed = true;
            //}
            //if (Keyboard.GetState().IsKeyUp(Keys.Left) && keyLeftPressed == true)
            //{
            //    keyLeftPressed = false;
            //}

            //// right
            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //{
            //    int tileId = world[(int)(positionX + hitbox), (int)positionY];
            //    if (keyRightPressed == false && walkableTiles.Contains(tileId)) positionX += 1.0;
            //    keyRightPressed = true;
            //}
            //if (Keyboard.GetState().IsKeyUp(Keys.Right) && keyRightPressed == true)
            //{
            //    keyRightPressed = false;
            //}

            //// up
            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    int tileId = world[(int)positionX, (int)(positionY - hitbox)];
            //    if (keyUpPressed == false && walkableTiles.Contains(tileId)) positionY -= 1.0;
            //    keyUpPressed = true;
            //}
            //if (Keyboard.GetState().IsKeyUp(Keys.Up) && keyUpPressed == true)
            //{
            //    keyUpPressed = false;
            //}

            //// down
            //if (Keyboard.GetState().IsKeyDown(Keys.Down))
            //{
            //    int tileId = world[(int)positionX, (int)(positionY + hitbox)];
            //    if (keyDownPressed == false && walkableTiles.Contains(tileId)) positionY += 1.0;
            //    keyDownPressed = true;
            //}
            //if (Keyboard.GetState().IsKeyUp(Keys.Down) && keyDownPressed == true)
            //{
            //    keyDownPressed = false;
            //}
        }
    }
}
