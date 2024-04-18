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

        public void updatePosition()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (keyLeftPressed == false) positionX -= Game1.tileSize;
                keyLeftPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Left) && keyLeftPressed == true)
            {
                keyLeftPressed = false;
            }

            // right
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (keyRightPressed == false) positionX += Game1.tileSize;
                keyRightPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Right) && keyRightPressed == true)
            {
                keyRightPressed = false;
            }

            // up
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (keyUpPressed == false) positionY -= Game1.tileSize;
                keyUpPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Up) && keyUpPressed == true)
            {
                keyUpPressed = false;
            }

            // down
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (keyDownPressed == false) positionY += Game1.tileSize;
                keyDownPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Down) && keyDownPressed == true)
            {
                keyDownPressed = false;
            }
        }
    }
}
