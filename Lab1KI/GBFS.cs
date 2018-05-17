using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1KI
{
    class GBFS
    {
        private int minX;
        private int minY;
        private Grid grid;

        public GBFS() { }

        public int getMinX()
        {
            return minX;
        }

        public void setMinX(int minX)
        {
            this.minX = minX;
        }

        public int getMinY()
        {
            return minY;
        }

        public void setMinY(int minY)
        {
            this.minY = minY;
        }

        public Grid getT()
        {
            return grid;
        }

        public void setT(Grid t)
        {
            this.grid = t;
        }

    
    public void GBFSUtil(int parent, bool[] visited, int x, int y, Grid grid, GridRepo gridRepo, Graph graph)
        {
            visited[parent] = true;

            Grid aux = gridRepo.gridRepo.ElementAt(parent);
            Tuple tup;
            if (graph.isLeaf(parent))
            {
                tup = aux.gridSize();
                if (x * y > tup.getX() * tup.getY())
                {
                    this.getT().setGrid(aux.getGrid());
                    setMinX(tup.getX());
                    setMinY(tup.getY());
                }
            }
            else
            {
                int kid = graph.findMin(gridRepo, parent);
                GBFSUtil(kid, visited, this.getMinX(), this.getMinY(), this.getT(), gridRepo, graph);
            }
        }

        public void Gbfs(int parent, GridRepo gridRepo, Graph graph)
        {
            bool[] visited = new bool[graph.V];
            Grid t = new Grid();
            this.setMinX(8);
            this.setMinY(8);
            this.setT(t);
            GBFSUtil(parent, visited, getMinX(), getMinY(), t, gridRepo, graph);
        }
    }
}
