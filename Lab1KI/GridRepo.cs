using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1KI
{
    class GridRepo
    {
        internal List<Grid> gridRepo { get; set; }

        public GridRepo()
        {
            gridRepo = new List<Grid>();
            Grid grid = new Grid();
            gridRepo.Add(grid);
        }

        public GridRepo(List<Grid> gridRepo) { this.gridRepo = gridRepo; }

        public void addGrid(Grid grid) { this.gridRepo.Add(grid); }
        
    }
}
