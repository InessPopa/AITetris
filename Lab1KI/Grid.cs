using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1KI
{
    class Grid
    {
        internal int[,] grid = new int[8, 8];
        internal int size;
        internal int nrDisplay;
        internal int nrGrid;

        public Grid()
        {
            size = 8;
            nrDisplay = 1;
            nrGrid = 0;
        }

        public Grid(int[,] grid, int n, int nrDisplay, int nrGrid)
        {
            this.grid = grid;
            this.size = n;
            this.nrDisplay = nrDisplay;
            this.nrGrid = nrGrid;
        }

        public void setGrid(int[,] grid) { this.grid = grid; }

        public void setN(int n) { this.size = n; }

        public void setNrDisplay(int nrDisplay) { this.nrDisplay = nrDisplay; }

        public int getNrGrid() { return nrGrid; }

        public void setNrGrid(int nrGrid) { this.nrGrid = nrGrid; }

        public int getNrDisplay() { return nrDisplay; }

        public int getN() { return size; }

        public int[,] getGrid() { return grid; }

        public bool PutTetris(int nrForm, int i, int j)
        {
            switch ((nrForm % 15) - 1)
            {
                case 0:
                    if (PutForm1(i, j))
                        return true;
                    else return false;

                case 1:
                    if (PutForm2(i, j))
                        return true;
                    else return false;

                case 2:
                    if (PutForm3(i, j))
                        return true;
                    else return false;

                case 3:
                    if (PutForm4(i, j))
                        return true;
                    else return false;
                case 4:
                    if (PutForm5(i, j))
                        return true;
                    else return false;

                case 5:
                    if (PutForm6(i, j))
                        return true;
                    else return false;

                case 6:
                    if (PutForm7(i, j))
                        return true;
                    else return false;

                case 7:
                    if (PutForm8(i, j))
                        return true;
                    else return false;
                case 8:
                    if (PutForm9(i, j))
                        return true;
                    else return false;

                case 9:
                    if (PutForm10(i, j))
                        return true;
                    else return false;

                case 10:
                    if (PutForm11(i, j))
                        return true;
                    else return false;

                case 11:
                    if (PutForm12(i, j))
                        return true;
                    else return false;
                case 12:
                    if (PutForm13(i, j))
                        return true;
                    else return false;

                case 13:
                    if (PutForm14(i, j))
                        return true;
                    else return false;
                case -1:
                    if (PutForm15(i, j))
                        return true;
                    else return false;

                default:
                    return false;
            }
        }

        private bool PutForm1(int i, int j)
        {
            for (int k = j; k <= j + 3; k++)
            {
                if (grid[i,k] != 0)
                    return false;
                else
                    grid[i,k] = nrDisplay;
            }
            nrDisplay++;
            return true;
        }

        private bool PutForm2(int i, int j)
        {
            if (grid[i,j] != 0 || grid[i,j + 2] != 0)
                return false;
            else
            {
                grid[i,j] = nrDisplay;
                grid[i,j + 2] = nrDisplay;
            }
            for (int k = j; k <= j + 2; k++)
            {
                if (grid[i + 1,k] != 0)
                    return false;
                else
                    grid[i + 1,k] = nrDisplay;
            }
            nrDisplay++;
            return true;
        }

        private bool PutForm3(int i, int j)
        {
            if (grid[i,j] != 0)
                return false;
            else
                grid[i,j] = nrDisplay;
            for (int k = j; k <= j + 2; k++)
            {
                if (grid[i + 1,k] != 0)
                    return false;
                else
                    grid[i + 1,k] = nrDisplay;
            }
            nrDisplay++;
            return true;
        }

        private bool PutForm4(int i, int j)
        {
            for (int k = j; k <= j + 2; k++)
                if (grid[i,k] != 0)
                    return false;
                else
                    grid[i,k] = nrDisplay;
            if (grid[i + 1,j + 2] != 0)
                return false;
            else
            {
                grid[i + 1,j + 2] = nrDisplay;
            }
            nrDisplay++;
            return true;
        }

        private bool PutForm5(int i, int j)
        {
            if (grid[i,j + 1] != 0)
                return false;
            else
                grid[i,j + 1] = nrDisplay;
            for (int k = j; k <= j + 2; k++)
            {
                if (grid[i + 1,k] != 0)
                    return false;
                else
                    grid[i + 1,k] = nrDisplay;
            }
            nrDisplay++;
            return true;
        }

        private bool PutForm6(int i, int j)
        {
            for (int k = i; k <= i + 3; k++)
            {
                if (grid[k,j] != 0)
                    return false;
                else
                    grid[k,j] = nrDisplay;
            }
            nrDisplay++;
            return true;
        }

        private bool PutForm7(int i, int j)
        {
            if (grid[i,j + 1] != 0)
                return false;
            else
                grid[i,j + 1] = nrDisplay;
            if (grid[i + 2,j + 1] != 0)
                return false;
            else
                grid[i + 2,j + 1] = nrDisplay;
            for (int k = i; k <= i + 2; k++)
            {
                if (grid[k,j] != 0)
                    return false;
                else
                    grid[k,j] = nrDisplay;
            }
            nrDisplay++;
            return true;
        }

        private bool PutForm8(int i, int j)
        {
            for (int k = j; k <= j + 2; k++)
                if (grid[i,k] != 0)
                    return false;
                else
                    grid[i,k] = nrDisplay;
            if (grid[i + 1,j] != 0)
                return false;
            else
                grid[i + 1,j] = nrDisplay;
            if (grid[i + 1,j + 2] != 0)
                return false;
            else
                grid[i + 1,j + 2] = nrDisplay;
            nrDisplay++;
            return true;
        }

        private bool PutForm9(int i, int j)
        {
            if (grid[i,j] != 0)
                return false;
            else
                grid[i,j] = nrDisplay;
            if (grid[i + 2,j] != 0)
                return false;
            else
                grid[i + 2,j] = nrDisplay;
            for (int k = i; k <= i + 2; k++)
            {
                if (grid[k,j + 1] != 0)
                    return false;
                else
                    grid[k,j + 1] = nrDisplay;
            }
            nrDisplay++;
            return true;
        }

        private bool PutForm10(int i, int j)
        {
            if (grid[i,j + 1] != 0)
                return false;
            else
                grid[i,j + 1] = nrDisplay;
            for (int k = i; k <= i + 2; k++)
            {
                if (grid[k,j] != 0)
                    return false;
                else
                    grid[k,j] = nrDisplay;
            }
            nrDisplay++;
            return true;
        }

        private bool PutForm11(int i, int j)
        {
            for (int k = j; k <= j + 2; k++)
                if (grid[i,k] != 0)
                    return false;
                else
                    grid[i,k] = nrDisplay;
            if (grid[i + 1,j + 2] != 0)
                return false;
            else
                grid[i + 1,j + 2] = nrDisplay;
            nrDisplay++;
            return true;
        }

        private bool PutForm12(int i, int j)
        {
            if (grid[i + 2,j] != 0)
                return false;
            else
                grid[i + 2,j] = nrDisplay;
            for (int k = i; k <= i + 2; k++)
            {
                if (grid[k,j + 1] != 0)
                    return false;
                else
                    grid[k,j + 1] = nrDisplay;
            }
            nrDisplay++;
            return true;
        }

        private bool PutForm13(int i, int j)
        {
            if (grid[i + 1,j + 1] != 0)
                return false;
            else
                grid[i + 1,j + 1] = nrDisplay;
            for (int k = i; k <= i + 2; k++)
            {
                if (grid[k,j] != 0)
                    return false;
                else
                    grid[k,j] = nrDisplay;
            }
            nrDisplay++;
            return true;
        }

        private bool PutForm14(int i, int j)
        {
            for (int k = j; k <= j + 2; k++)
                if (grid[i,k] != 0)
                    return false;
                else
                    grid[i,k] = nrDisplay;
            if (grid[i + 1,j + 1] != 0)
                return false;
            else
                grid[i + 1,j + 1] = nrDisplay;
            nrDisplay++;
            return true;
        }

        private bool PutForm15(int i, int j)
        {
            if (grid[i + 1,j] != 0)
                return false;
            else
                grid[i + 1,j] = nrDisplay;
            for (int k = i; k <= i + 2; k++)
            {
                if (grid[k,j + 1] != 0)
                    return false;
                else
                    grid[k,j + 1] = nrDisplay;
            }
            nrDisplay++;
            return true;
        }

        private int columnSum(int j)
        {
            int i;
            int sum = 0;

            for (i = 0; i < this.getN(); i++)
                sum += this.getGrid()[i,j];
            return sum;
        }

        public Tuple gridSize()
        {
            int i = 0;
            int j = 0;
            int k = 7;
            int n;
            int m;

            while (i < 8 && getRowSumOFGrid(i) == 0)
                i++;

            while (j < 8 && columnSum(j) == 0)
                j++;

            while (k >= 0 && columnSum(k) == 0)
                k--;

            n = 8 - i;
            m = k - j + 1;
            Tuple tup = new Tuple(n, m);

            return tup;
        }

        public int getRowSumOFGrid(int rowNumber)
        {
            int sum = 0;
            for (int i = 0; i < this.getGrid().GetLength(0)-1; i++)
            {
                if (i == rowNumber)
                {
                    for (int j = 0; j < this.getGrid().GetLength(0)-1; j++)
                    {
                        sum = sum + this.getGrid()[i, j];
                    }
                }
            }
            return sum;
        }

    }

}
