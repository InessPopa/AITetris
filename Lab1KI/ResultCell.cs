using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1KI
{
    class ResultCell : System.Windows.Forms.Label
    {
        internal int xIndex { get; set; }
        internal int yIndex { get; set; }
        internal System.Drawing.Color color { get; set; }
        internal System.Windows.Forms.Label label { get; set; }

        public ResultCell(int xIndex, int yIndex, System.Windows.Forms.Label label)
        {
            this.xIndex = xIndex;
            this.yIndex = yIndex;
            this.label = label;
        }
        public void setColor(System.Drawing.Color color) { label.BackColor = color; }

    }
       
}
