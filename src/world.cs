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
        public int[,] world = new int[20, 20];

        public void generateWorld() {
            // random ground
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
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
            // make world border
            for (int i = 0; i < 20; i++)
            {
                world[i,0] = 3;
                world[i,19] = 3;
            }
            for (int j = 0; j < 20; j++)
            {
                world[0,j] = 3;
                world[19,j] = 3;
            }
        }
    }

}
