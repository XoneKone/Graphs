using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }


        Graph graph = new Graph();

        private void Input_graph_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string filetext = File.ReadAllText(filename);
            MessageBox.Show("Файл открыт");
            graph = new Graph(filetext);
            List<VertexGraph> vertices = graph.GetVertices();
            List<EdgeGraph> edges = graph.GetEdges();
            Output_vertices.Clear();
            Output_Edges.Clear();
            origin_matrix_adj.Clear();
            foreach (var v in vertices)
            {
                Output_vertices.AppendText(v.ToString() + " ");
            }
            foreach(var ed in edges)
            {
                Output_Edges.AppendText(ed.ToString() + "\n");
            }
            int[,] matrix = graph.GetMatrix();
            int rows = matrix.GetUpperBound(0) + 1;
            for(int i =0; i<rows;i++)
            {
                for (int j = 0; j < rows; j++)
                    origin_matrix_adj.AppendText(matrix[i, j].ToString() + " ");
                origin_matrix_adj.AppendText("\n");
            }
        }
        
       

        private void Run1_Click_1(object sender, EventArgs e)
        {
            int index = Tasks.SelectedIndex;
            Algorithms algorithms = new Algorithms();
            switch (index)
            {
                case 0:
                    {
                        output.Clear();
                        List<int> res = new List<int>();
                        bool answer = algorithms.FindEulerPath(graph, out res);
                        if (answer)
                            output.AppendText("Нет эйлерова пути!\n");
                        else
                        {
                            output.AppendText("Эйлеров путь:\n");
                            foreach (var v in res)
                            {
                                output.AppendText(v.ToString() + " ");
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        output.Clear();
                        List<VertexGraph> combsub = new List<VertexGraph>();
                        List<VertexGraph> not = new List<VertexGraph>();
                        List<List<VertexGraph>> MaxCliques = new List<List<VertexGraph>>();
                        List<VertexGraph> candidates =  graph.GetVertices();
                        algorithms.BronKerbosh(combsub, candidates, not, graph,  MaxCliques);
                        if (MaxCliques.Count > 1)
                        {
                            output.AppendText("Наибольшая клика:\n");
                            MaxCliques.Sort();                                                        
                            foreach (var v in MaxCliques.Last())
                            {
                                output.AppendText(v.ToString() + " ");
                            }
    
                        }
                        else { output.AppendText("Наибольших клик нет!\n"); }
                        break;
                    }
                case 2:
                    {
                        output.Clear();
                        VertexGraph S = new VertexGraph(graph.VertexCount - 1);
                        VertexGraph I = new VertexGraph(0);
                        int [,] capacity = graph.GetMatrix();
                        int[,] legalFlows = new int[graph.VertexCount, graph.VertexCount];
                        int max_flow = algorithms.EdmondsKarp(I, S, graph, capacity,out legalFlows);
                        output.AppendText($"Максимальный поток = {max_flow}\n");
                        int rows = legalFlows.GetUpperBound(0) + 1;
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < rows; j++)
                                output.AppendText(legalFlows[i, j].ToString() + " ");
                            output.AppendText("\n");
                        }
                        break;
                    }
                case 3:
                    {

                    }
            }
        }
    }
}
