using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1KI
{
    class ResultGrid
    {
        internal ResultCell[,] grid;

        public ResultGrid() { this.grid = new ResultCell[20, 20]; }

        public ResultCell[,] getGrid() { return grid; }
        public ResultCell getCell(int i, int j) { return grid[i, j]; }
        public void setGrid(ResultCell[,] grid) { this.grid = grid; }

        public void ClearGrid()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    grid[i, j].setColor(System.Drawing.Color.LightGreen);
                }
            }
        }

        public void Update(int[,] tab)
        {
            for (int h = 0; h < 8; h++)
            {
                for (int w = 0; w < 8; w++)
                {
                    if (tab[h,w] == 0)
                    {
                        grid[h,w].setColor(System.Drawing.Color.LightGreen); //clear
                    }
                    else
                    {
                        switch (tab[h,w] % 5)
                        {
                            case 0:
                                grid[h,w].setColor(System.Drawing.Color.LightPink);
                                break;

                            case 1:
                                grid[h,w].setColor(System.Drawing.Color.LightSeaGreen);
                                break;
                            case 2:
                                grid[h,w].setColor(System.Drawing.Color.LightSkyBlue);
                                break;
                            case 3:
                                grid[h,w].setColor(System.Drawing.Color.LightYellow);
                                break;
                            case 4:
                                grid[h,w].setColor(System.Drawing.Color.Lime);
                                break;
                        }
                    }
                }
            }
        }
    }
}
