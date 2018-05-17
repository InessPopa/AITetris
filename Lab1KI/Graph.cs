using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1KI
{
    class Graph
    {
        internal int V { get; set; }
        internal LinkedList<LinkedList<int>> adj { get; set; }

        public Graph(int v)
        {
            V = v;
            adj = new LinkedList<LinkedList<int>>();
            for (int i = 0; i < v; ++i)
            {
                adj.AddLast(new LinkedList<int>());
            }
            
        }

        public void AddVertice()
        {
            V++;
            adj.AddLast(new LinkedList<int>());
        }

        public void addEdge(int v, int w) { adj.ElementAt(v).AddLast(w);  }

        public int getNrOfNeighbors(int v) { return adj.ElementAt(v).Count; }

        public bool isLeaf(int i) { return (getNrOfNeighbors(i) == 0); }

        public LinkedList<int> findLeaf()
        {
            LinkedList<int> leaf = new LinkedList<int>();

            for (int i = 0; i < V; i++)
            {
                if (getNrOfNeighbors(i) == 0)
                {
                    leaf.AddLast(i);
                }
            }
            return leaf;
        }

        public Tuple DFS(int v, GridRepo gridRepo, ResultGrid resultGrid)
        {
            DFS dfs = new DFS();
            dfs.Dfs(v, gridRepo, this);
            resultGrid.Update(dfs.grid.getGrid());
            Tuple tup = new Tuple(dfs.getMinX(), dfs.getMinY());
            return tup;
        }

        public int tetrisHeight(Grid grid)
        {
            int height = 0;

            while (height < 8 && grid.getRowSumOFGrid(height) == 0)
                height++;

            return 8 - height;
        }

        public int findMin(GridRepo gridRepo, int parent)
        {
            LinkedList<int> kids = this.adj.ElementAt(parent);
            int minHeight = 8;
            int h;
            int nrTab = -1;
            Grid aux;

            foreach(int nrTable in kids)
            {
                aux = gridRepo.gridRepo.ElementAt(nrTable);
                h = tetrisHeight(aux);
                if (h < minHeight)
                {
                    minHeight = h;
                    nrTab = nrTable;
                }
            }
            return nrTab;
        }

        public Tuple GBFS(int v, GridRepo gridRepo, ResultGrid resultGrid)
        {
            GBFS gbfs = new GBFS();
            gbfs.Gbfs(v, gridRepo, this);
            resultGrid.Update(gbfs.getT().getGrid());
            Tuple tup = new Tuple(gbfs.getMinX(), gbfs.getMinY());
            return tup;
        }
    }
}
