﻿using System;
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
                            if (res.First() == res.Last())
                            {
                                output.AppendText("Граф НЕ полуэйлеровый, а эйлеровый!");
                            }
                            else
                            {
                                output.AppendText("Граф полуэйлеровый!\nЭйлеров путь:\n");
                                foreach (var v in res)
                                {
                                    output.AppendText(v.ToString() + " ");
                                }
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
                        List<VertexGraph> max = new List<VertexGraph>();
                        algorithms.BronKerbosh(combsub, candidates, not, graph,  MaxCliques);
                        if (MaxCliques.Count > 1)
                        {
                            output.AppendText("Наибольшая клика:\n");
                            max = MaxCliques[0];
                            for (int i = 1; i < MaxCliques.Count; i++)
                            {
                                if(MaxCliques[i].Count > max.Count)
                                {
                                    max = MaxCliques[i];
                                }
                            }
                            foreach (var item in max)
                            {
                                output.AppendText(item.ToString() + " ");
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
                        output.Clear();
                        List<VertexGraph> combsub = new List<VertexGraph>();
                        List<VertexGraph> not = new List<VertexGraph>();
                        List<List<VertexGraph>> MaxIS = new List<List<VertexGraph>>();
                        List<VertexGraph> candidates = graph.GetVertices();
                        List<VertexGraph> max = new List<VertexGraph>();
                        algorithms.BronKerbosh_MIS(combsub,candidates,not,graph,MaxIS);
                        if (MaxIS.Count > 1)
                        {
                            output.AppendText("Наибольшее независимое множество:\n");
                            max = MaxIS[0];
                            for (int i = 1; i < MaxIS.Count; i++)
                            {
                                if (MaxIS[i].Count > max.Count)
                                {
                                    max = MaxIS[i];
                                }
                            }
                            foreach (var item in max)
                            {
                                output.AppendText(item.ToString() + " ");
                            }

                        }
                        else { output.AppendText("Наибольшее независимого множества нет!\n"); }
                        break;
                    }
                case 4:
                    {
                        output.Clear();                       
                        int[,] next = new int[graph.VertexCount,graph.VertexCount];
                        int[,] distanse = algorithms.Floyd_Warshall(graph, next);
                        VertexGraph start = new VertexGraph(0);
                        VertexGraph finish= new VertexGraph(graph.VertexCount-1);
                        List<VertexGraph> path = new List<VertexGraph>();
                        algorithms.Path(start, finish, next, path);

                        output.AppendText("Матрица кратчайших расстояний:\n");
                        int rows = distanse.GetUpperBound(0) + 1;
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < rows; j++)
                                output.AppendText(distanse[i, j].ToString() + " ");
                            output.AppendText("\n");
                        }
                        output.AppendText($"\nКратчайший путь от вершины "+start.ToString()+ " до " +finish.ToString()+":\n");
                        foreach (var item in path)
                        {
                            output.AppendText(item.ToString() + " ");
                        }
                        break;
                    }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            string filetext = output.Text;
            File.WriteAllText(filename, filetext);
            MessageBox.Show("Результаты сохранены");
        }
    }
}
