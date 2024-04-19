using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sunshine_shivers
{
    internal class Player
    {
        private bool keyLeftPressed = false;
        private bool keyRightPressed = false;
        private bool keyDownPressed = false;
        private bool keyUpPressed = false;

        public int positionX;
        public int positionY;

        public void updatePosition(int[,] world)
        {
            int[] walkableTiles = { 0, 1};

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                int tileId = world[positionX - 1, positionY];
                if (keyLeftPressed == false && walkableTiles.Contains(tileId)) positionX -= 1;
                keyLeftPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Left) && keyLeftPressed == true)
            {
                keyLeftPressed = false;
            }

            // right
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                int tileId = world[positionX + 1, positionY];
                if (keyRightPressed == false && walkableTiles.Contains(tileId)) positionX += 1;
                keyRightPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Right) && keyRightPressed == true)
            {
                keyRightPressed = false;
            }

            // up
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                int tileId = world[positionX, positionY - 1];
                if (keyUpPressed == false && walkableTiles.Contains(tileId)) positionY -= 1;
                keyUpPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Up) && keyUpPressed == true)
            {
                keyUpPressed = false;
            }

            // down
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                int tileId = world[positionX, positionY + 1];
                Console.Write("x = ");
                Console.WriteLine(positionX);
                Console.Write("y = ");
                Console.WriteLine(positionY);
                Console.WriteLine("tileid = " + tileId);
                if (keyDownPressed == false && walkableTiles.Contains(tileId)) positionY += 1;
                keyDownPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Down) && keyDownPressed == true)
            {
                keyDownPressed = false;
            }
        }
    }
}
