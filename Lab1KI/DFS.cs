using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1KI
{
    class DFS
    {
        internal int minX;
        internal int minY;
        internal Grid grid;

        public void setGrid(Grid grid) {

            this.grid = grid;
        }
        public void setMinX(int minX)
        {
            this.minX = minX;
        }

        public void setMinY(int minY)
        {
            this.minY = minY;
        }

        public int getMinX()
        {
            return minX;
        }

        public int getMinY()
        {
            return minY;
        }

        public DFS() { }

        public void DFSUtil(int v, bool[] visited, int x, int y, Grid grid, GridRepo gridRepo, Graph graph)
        {
            visited[v] = true;

            Grid aux = gridRepo.gridRepo.ElementAt(v);
            Tuple tup;
            if (graph.isLeaf(v))
            {
                tup = aux.gridSize();
                if (x * y > tup.getX() * tup.getY())
                {
                    this.grid.setGrid(aux.grid);
                    setMinX(tup.getX());
                    setMinY(tup.getY());
                }
            }

            IEnumerator<int> i = graph.adj.ElementAt(v).GetEnumerator();
            bool hasNext = i.MoveNext();
            while (hasNext)
            {
                int n = i.Current;
                hasNext = i.MoveNext();
                if (!visited[n])
                {
                    DFSUtil(n, visited, this.getMinX(), this.getMinY(), this.grid, gridRepo, graph);
                }
            }


        }

        public void Dfs(int v, GridRepo gridRepo, Graph graph)
        {
            bool[] visited = new bool[graph.V];
            Grid grid = new Grid();
            this.setMinX(8);
            this.setMinY(8);
            this.setGrid(grid);
            DFSUtil(v, visited, getMinX(), getMinY(), grid, gridRepo, graph);
        }
    }
}
