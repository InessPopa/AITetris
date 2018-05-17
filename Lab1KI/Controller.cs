using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1KI
{
    class Controller
    {
        internal GridRepo gridRepo;
        internal int nr;

        public Controller(GridRepo gridRepo)
        {
            this.gridRepo = gridRepo;
            this.nr = 1;
        }

        public GridRepo GetGridRepo() { return gridRepo; }
        public void SetGridRepo(GridRepo gridRepo) { this.gridRepo = gridRepo; }

        public int GetNr() { return nr; }
        public void SetNr(int nr) { this.nr = nr; }

        private bool findPlace1(Grid grid, int nrForm, int i, int j, bool found, Graph graph)
        {
            int n = grid.getN();
            int nr = grid.getNrDisplay();
            int[,] table = new int[n, n];
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    table[x, y] = grid.getGrid()[x, y];
                }
            }
            Grid grid1 = new Grid(table, n, nr, -1);
            if (i < 0)
            {
                return found;
            }
            else if (j + 3 == grid.getN() && grid.getRowSumOFGrid(i) == 0)
            { return found; }
            else if (j + 3 == grid.getN())
            { return findPlace1(grid, nrForm, i - 1, 0, found, graph); }
            else if (grid1.PutTetris(nrForm, i, j))
            {
                grid1.setNrGrid(this.GetNr());
                graph.addEdge(grid.getNrGrid(), this.GetNr());
                graph.AddVertice();
                int x = this.GetNr() + 1;
                this.SetNr(x);
                gridRepo.addGrid(grid1);
                found = true;
                return findPlace1(grid, nrForm, i, j + 1, found, graph);
            }
            else
                return findPlace1(grid, nrForm, i, j + 1, found, graph);

        }

        private bool FindPlace2(Grid grid, int nrForm, int i, int j, bool found, Graph graph)
        {
            int n = grid.getN();
            int nr = grid.getNrDisplay();
            int[,] table = new int[n,n];
        for (int x = 0; x<n;x++)
            for (int y = 0; y<n;y++)
                table[x,y] = grid.getGrid()[x,y];

        Grid grid1 = new Grid(table, n, nr, -1); //NR TABLE!!!!
        if (i< 1)
            return found;
        else if (j+2==grid.getN() && grid.getRowSumOFGrid(i)==0 && grid.getRowSumOFGrid(i+1)==0)
            return found;
        else if (j+2==grid.getN())
            return FindPlace2(grid, nrForm, i-1,0, found, graph);
        else if (grid1.PutTetris(nrForm,i,j)) {
            grid1.setNrGrid(this.GetNr());
            graph.addEdge(grid.getNrGrid(),this.GetNr());
            graph.AddVertice();
            int x = this.GetNr() + 1;
            this.SetNr(x);
            gridRepo.addGrid(grid1);
            found = true;
            return FindPlace2(grid, nrForm, i, j+1, found, graph);
        }
        else
            return FindPlace2(grid, nrForm, i, j+1, found, graph);
   }


        private bool FindPlace3(Grid grid, int nrForm, int i, int j, bool found, Graph graph)
        {
            int n = grid.getN();
            int nr = grid.getNrDisplay();
            int[,] table = new int[n,n];
        for (int x = 0; x<n;x++)
            for (int y = 0; y<n;y++)
                table[x,y] = grid.getGrid()[x,y];

        Grid grid1 = new Grid(table, n, nr, -1);
        if (i< 3)
            return found;
        else if (j==grid.getN() && grid.getRowSumOFGrid(i)==0 && grid.getRowSumOFGrid(i+1)==0
                && grid.getRowSumOFGrid(i+2)==0 && grid.getRowSumOFGrid(i+3)==0)
            return found;
        else if (j==grid.getN())
            return FindPlace3(grid, nrForm, i-1,0, found, graph);
        else if (grid1.PutTetris(nrForm,i,j)) {
            grid1.setNrGrid(this.GetNr());
            graph.addEdge(grid.getNrGrid(),this.GetNr());
            graph.AddVertice();
            int x = this.GetNr() + 1;
            this.SetNr(x);
            gridRepo.addGrid(grid1);
            found = true;
            return FindPlace3(grid, nrForm, i, j+1, found, graph);
        }
        else
            return FindPlace3(grid, nrForm, i, j+1, found, graph);
      }

        private bool FindPlace4(Grid grid, int nrForm, int i, int j, bool found, Graph graph)
        {
            int n = grid.getN();
            int nr = grid.getNrDisplay();
            int[,] table = new int[n,n];
        for (int x = 0; x<n;x++)
            for (int y = 0; y<n;y++)
                table[x,y] = grid.getGrid()[x,y];

        Grid grid1 = new Grid(table, n, nr, -1);
        if (i< 2)
            return found;
        else if (j+1==grid.getN() && grid.getRowSumOFGrid(i)==0 && grid.getRowSumOFGrid(i+1) == 0
                && grid.getRowSumOFGrid(i+2) == 0)
            return found;
        else if (j+1==grid.getN())
            return FindPlace4(grid, nrForm, i-1,0, found, graph);
        else if (grid1.PutTetris(nrForm,i,j)) {
            grid1.setNrGrid(this.GetNr());
            graph.addEdge(grid.getNrGrid(),this.GetNr());
            graph.AddVertice();
            int x = this.GetNr() + 1;
            this.SetNr(x);
            gridRepo.addGrid(grid1);
            found = true;
            return FindPlace4(grid, nrForm, i, j+1, found, graph);
         }
        else
            return FindPlace4(grid, nrForm, i, j+1, found, graph);
         }


        public bool findPlaces(int nrForm, Graph graph)
        {
            LinkedList<int> leaf = graph.findLeaf();
            bool foundPlace = false;

            foreach (var l in leaf)
            {
                Grid grid = gridRepo.gridRepo.ElementAt(l);
                if (nrForm == 1)
                {
                    if (findPlace1(grid, 1, grid.getN() - 1, 0, false, graph))
                        foundPlace = true;
                    if (FindPlace3(grid, 6, grid.getN() - 4, 0, false, graph))
                        foundPlace = true;
                }
                else if (nrForm == 2)
                {
                    if (FindPlace2(grid, 2, grid.getN() - 2, 0, false, graph))
                        foundPlace = true;
                    if (FindPlace4(grid, 7, grid.getN() - 3, 0, false, graph))
                        foundPlace = true;
                    if (FindPlace4(grid, 9, grid.getN() - 3, 0, false, graph))
                        foundPlace = true;
                    if (FindPlace2(grid, 8, grid.getN() - 2, 0, false, graph))
                        foundPlace = true;
                }
                else if (nrForm == 3 || nrForm == 4)
                {
                    if (FindPlace2(grid, 3, grid.getN() - 2, 0, false, graph))
                        foundPlace = true;
                    if (FindPlace4(grid, 10, grid.getN() - 3, 0, false, graph))
                        foundPlace = true;
                    if (FindPlace4(grid, 12, grid.getN() - 3, 0, false, graph))
                        foundPlace = true;
                    if (FindPlace2(grid, 11, grid.getN() - 2, 0, false, graph))
                        foundPlace = true;
                }
                else if (nrForm == 5)
                {
                    if (FindPlace2(grid, 5, grid.getN() - 2, 0, false, graph))
                        foundPlace = true;
                    if (FindPlace4(grid, 13, grid.getN() - 3, 0, false, graph))
                        foundPlace = true;
                    if (FindPlace4(grid, 15, grid.getN() - 3, 0, false, graph))
                        foundPlace = true;
                    if (FindPlace2(grid, 14, grid.getN() - 2, 0, false, graph))
                        foundPlace = true;
                }
            }
            return foundPlace;
        }
    }


}

