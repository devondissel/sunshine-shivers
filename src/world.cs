using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sunshine_shivers
{
    public class Dimension
    {
        public int[,] world = new int[40, 40];

        public void generateWorld() {
            // random ground
            Random rnd = new Random();
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    int tile = rnd.Next(2);
                    world[i, j] = tile;
                }
            }
            // make little house
            for (int i = 5; i < 12; i++) {
                for (int j = 5; j < 12; j++) {
                    world[i, j] = 3;
                }
            }
            world[8,11] = 2;
            // make world border
            for (int i = 0; i < 40; i++)
            {
                world[i,0] = 3;
                world[i,39] = 3;
            }
            for (int j = 0; j < 40; j++)
            {
                world[0,j] = 3;
                world[39,j] = 3;
            }
        }
    }

}
