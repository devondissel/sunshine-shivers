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

        public double x;
        public double y;

        public int facing = 0;


        public void updatePosition(int[,] world)
        {
            int[] walkableTiles = { 0, 1};

            // acceleration vector
            int i = 0;
            int j = 0;
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) j++;
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) j--;
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) i--;
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) i++;

            Vector2 direction = new Vector2(i,j);
            if (i != 0 || j != 0) direction = Vector2.Normalize(direction);
            System.Diagnostics.Debug.WriteLine(direction.X);
            accelerationX += 0.018*direction.X;
            accelerationY += 0.018*direction.Y;
            // induce a friction
            accelerationX *= 0.82;
            accelerationY *= 0.82;

            // prevent drifting
            if (direction.X == 0 && accelerationX*accelerationX < 0.0001) accelerationX = 0;
            if (direction.Y == 0 && accelerationY * accelerationY < 0.0001) accelerationY = 0;

            x += accelerationX;
            y += accelerationY;

            // calculate facing angle
            if (i != 0 || j != 0) facing = (int)Math.Round(4 * (1 + Math.Atan2(accelerationX, accelerationY) / Math.PI));
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
