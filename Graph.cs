using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Graph
    {
        List<VertexGraph> Vertices;
        List<EdgeGraph> Edges;
        
        public Graph()
        {
            Vertices = new List<VertexGraph>();
            Edges = new List<EdgeGraph>();
        }

        public Graph(string InputText)
        {
            Vertices = new List<VertexGraph>();
            Edges = new List<EdgeGraph>();
            if (InputText != String.Empty)
            {
                InputText = InputText.Replace(" ", "");
                InputText = InputText.Replace("\r", "");
                
                int k = 0; string[] col;
                string[] text = InputText.Split('\n');                         
                    foreach(var row  in text)
                    {
                        col = row.Split(',');
                        VertexGraph from = new VertexGraph(k);
                        Vertices.Add(from);
                        for (int i = 0; i < col.Length; i++)
                        {
                            if (col[i] != "0" && col[i] != "")
                            {
                                VertexGraph to = new VertexGraph(i);
                                EdgeGraph edge;
                                if (col[i] != "1")
                                {
                                    int weight = int.Parse(col[i]);
                                    edge = new EdgeGraph(from, to, weight);
                                }
                                else
                                    edge = new EdgeGraph(from, to);
                                Edges.Add(edge);
                            }

                        }
                        k++;
                    }

                    
                    
                
            }
        }
        public int VertexCount => Vertices.Count;

        public int EdgesCount => Edges.Count;

        public void AddVertex(VertexGraph vertex)
        {
            Vertices.Add(vertex);
        }

        public void AddEdge(VertexGraph from, VertexGraph to)
        {
            var edge = new EdgeGraph(from, to);
            Edges.Add(edge);
        }

        public void AddEdge(VertexGraph from, VertexGraph to, int weight)
        {
            var edge = new EdgeGraph(from, to,weight);
            Edges.Add(edge);
        }

        public int [,] GetMatrix()
        {
            var matrix = new int[Vertices.Count, Vertices.Count];

            foreach(var edge in Edges)
            {
                var row = edge.From.Number;
                var col = edge.To.Number;
                matrix[row, col] = edge.Weight;
            }

            return matrix;
        }

        public List<VertexGraph> GetVertices()
        {
            List<VertexGraph> vertices = new List<VertexGraph>(Vertices);
            return vertices;
        }

        public List<EdgeGraph> GetEdges()
        {
            List<EdgeGraph> edges = new List<EdgeGraph>(Edges);
            return edges;
        }

        public List<VertexGraph> GetVertexLists(VertexGraph vertex)
        {
            var result = new List<VertexGraph>();

            foreach(var edge in Edges)
            {
                if (edge.From == vertex)
                {
                    result.Add(edge.To);
                }
            }
            return result;
        }     
    }
}
