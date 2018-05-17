using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1KI
{
    public partial class Form1 : Form
    {
        string selectedAlgorithm = "";
        Grid grid = new Grid();
        GridRepo gridRepo = new GridRepo();
        Graph graph = new Graph(1);
        Model model = new Model();
        private List<string> myObservableList = new List<string>();
        Controller controller;
        Label[,] matrix = new Label[8, 8];
        ResultGrid resultGrid = new ResultGrid();

        private void setController() { this.controller = new Controller(gridRepo); }

        public Form1()
        {
            InitializeComponent();
            this.setController();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = 35;
            int y = 150;
            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 8; row++)
                {
                    Label label = new Label();
                    label.AutoSize = false;
                    label.BackColor = Color.LightGreen;
                    label.Name = "label" + row + col;
                    label.Height = 23;
                    label.Width = 23;
                    label.Location = new Point(x, y);
                    this.Controls.Add(label);
                    ResultCell resultCell = new ResultCell(col, row, label);
                    resultGrid.getGrid()[row, col] = resultCell;
                    y += 31;

                }
                x += 31;
                y = 150;
            }
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BringToFront();
                }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAlgorithm = listBox1.SelectedItem.ToString();
        }

        private void loadData()
        {
            myObservableList.Clear();
            String a = "\tDFS\t\t";
            String b = "\tGBFS\t\t";
            myObservableList.Add(a);
            myObservableList.Add(b);
        }
      
        private void SolveButton_Click(object sender, EventArgs e)
        {
            string algorithm = selectedAlgorithm;
            Tuple tup;
            if (algorithm == "")
            { textLabel.Text += "Please select algorithm"; }
            else if (algorithm.Equals("DFS"))
            {
                textLabel.Text += "Solving with DFS\n";
                tup = graph.DFS(0, gridRepo, resultGrid);
            }
            else if (algorithm.Equals("GBFS"))
            {
                textLabel.Text += "Solving with GBFS\n";
                tup = graph.GBFS(0, gridRepo, resultGrid);
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!controller.findPlaces(1, graph))
                textLabel.Text += "no more place :)";
            else
                textLabel.Text += "Long Form\n";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!controller.findPlaces(2, graph))
                textLabel.Text += "no more place :)";
            else
                textLabel.Text += "Strange Form\n";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!controller.findPlaces(3, graph))
                textLabel.Text += "no more place :)";
            else
                textLabel.Text += "J Form\n";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (!controller.findPlaces(5, graph))
                textLabel.Text += "no more place :)";
            else
                textLabel.Text += "Pyramide Form\n";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (!controller.findPlaces(4, graph))
                textLabel.Text += "no more place :)";
            else
                textLabel.Text += "L Form\n";
        }
    }
}
