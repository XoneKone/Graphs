using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs
{
    
    public class Algorithms
    {
        public  List<VertexGraph> Wave(VertexGraph start, VertexGraph finish,Graph graph)
        {

            var list = new List<VertexGraph>();

            list.Add(start);

            for (int i = 0; i < list.Count; i++)
            {
                var vertex = list[i];
                foreach (var v in graph.GetVertexLists(vertex))
                {
                    if (!list.Contains(v) && !list.Contains(finish))
                    {
                        list.Add(v);
                    }
                }
            }
            return list;
        }

        public  List<VertexGraph> Dfs(VertexGraph start, VertexGraph finish, List<VertexGraph> result,Graph graph)
        {
            result.Add(start);
            foreach (var v in graph.GetVertexLists(start))
            {
                if (!result.Contains(v) && !result.Contains(finish))
                    Dfs(v, finish, result,graph);
            }
            return result;
        }

        public  bool FindEulerPath(Graph graph, out List<int>R)
        {
            var  matrix = new int[graph.VertexCount, graph.VertexCount];
            matrix = graph.GetMatrix();
            var deg = new int[graph.VertexCount];
            for(int i=0;i< graph.VertexCount; i++)
            {
                for(int j=0;j< graph.VertexCount; j++)
                {
                    deg[i] += matrix[i, j];
                }
            }

            int first = 0;
            while (deg[first] %2 == 0)
                ++first;
            int v1 = -1, v2 = -1;
            bool bad = false;
            bool exist = true;
            for(int i=0;i< graph.VertexCount; i++)
            {
                if ((deg[i] %2 ) == 1)
                {
                    if (v1 == -1)
                        v1 = i;
                    else if (v2 == -1)
                        v2 = i;
                    else bad = true;
                }
            }
            if(v1 != -1 && matrix[v1,v2]==0)
            {
                matrix[v1, v2]++;
                matrix[v2, v1]++;
                exist = false;
            }
            Stack<int> st = new Stack<int>();
            st.Push(first);
            List<int> result = new List<int>();
            while(st.Any())
            {
                int v = st.Peek();
                int i;
                for (i = 0; i < graph.VertexCount; i++)
                    if (matrix[v, i] == 1)
                        break;
                if (i== graph.VertexCount)
                {
                    result.Add(v);
                    st.Pop();
                }
                else
                {
                    matrix[v, i]--;
                    matrix[i, v]--;
                    st.Push(i);
                }
            }
            if (v1 != -1 && !exist)
                for (int i = 0; i < result.Count; i++)
                    if (result[i] == v1 && result[i + 1] == v2 || result[i] == v2 && result[i + 1] == v1)
                    {
                        List<int> res1 = new List<int>();
                        for (int j = i + 1; j < result.Count; j++)
                            res1.Add(result[j]);
                        for (int j = 1; j <= i; j++)
                            res1.Add(result[j]);
                        result = res1;
                        break;
                    }
            R = result;
            for (int i = 0; i < graph.VertexCount; i++)
                for (int j = 0; j < graph.VertexCount; j++)
                    if (matrix[i, j] == 1)
                        bad = true;  
            return bad;
        }



        public void BronKerbosh(List<VertexGraph> R, List<VertexGraph> P, List<VertexGraph> X, Graph graph,  List<List<VertexGraph>> MaxCliques)
        {

            if (!P.Any() && !X.Any())
            {
                if (R.Count >= 3)
                    MaxCliques.Add(R);
                return;
            }
            else
            {
                for (int i = 0; i < P.Count; i++)
                {
                    VertexGraph v = P[i];

                    List<VertexGraph> intersectionP = new List<VertexGraph>();
                    List<VertexGraph> intersectionX = new List<VertexGraph>();

                    // Пересечение с P
                    foreach (var u in graph.GetVertexLists(v))
                    {
                        for (int j = 0; j < P.Count; j++)
                        {
                            VertexGraph w = P[j];
                            if (u == w)
                            {
                                intersectionP.Add(u);
                            }
                        }

                        // Пересечение с Х
                        for (int k = 0; k < X.Count; k++)
                        {
                            VertexGraph l = X[k];
                            if (u == l)
                                intersectionX.Add(u);
                        }
                    }
                    List<VertexGraph> R_new = new List<VertexGraph>(R);
                    R_new.Add(v);
                    BronKerbosh(R_new, intersectionP, intersectionX, graph,  MaxCliques);
                    P.Remove(v);
                    X.Add(v);
                }
            }
        }

        int bfs (VertexGraph I,VertexGraph S, out int[] parent,Graph graph, int[,] capacity, int[,] legalFlows)
        {
            parent = new int [graph.VertexCount];
            for (int i = 0; i < graph.VertexCount; i++)
            {
                parent[i] = -1;
            }
            parent[I.Number] = -2;
            int[] m = new int[graph.VertexCount];
            m[I.Number] = int.MaxValue;
            Queue<VertexGraph> q = new Queue<VertexGraph>();
            
            q.Enqueue(I);
            while(q.Any())
            {
                VertexGraph cur = q.Dequeue();
                foreach (var next in graph.GetVertexLists(cur))
                {
                    if (capacity[cur.Number, next.Number] - legalFlows[cur.Number, next.Number] > 0 && parent[next.Number] == -1)
                    {
                        parent[next.Number] = cur.Number;
                        m[next.Number] = Math.Min(m[cur.Number], capacity[cur.Number, next.Number] - legalFlows[cur.Number, next.Number]);

                        if (next != S) q.Enqueue(next);
                        else return m[S.Number];
                    }
                }
            }
            return 0;
        }
        public int EdmondsKarp(VertexGraph I, VertexGraph S, Graph graph, int[,] capacity, out int[,] legalFlows)
        {
            int flow = 0;
            legalFlows = new int[graph.VertexCount, graph.VertexCount];
        
            
            while(true)
            {
                int[] parent;
                int new_flow = bfs(I, S, out parent, graph, capacity, legalFlows);

                if (new_flow == 0) break;
                flow += new_flow;
                int v = S.Number;
                while ( v!= I.Number)
                {
                    int prev = parent[v];
                    legalFlows[prev, v] += new_flow;
                    legalFlows[v, prev] -= new_flow;
                    v = prev;
                }
            }
            return flow;
        }

        public void BronKerbosh_MIS(List<VertexGraph> R, List<VertexGraph> P, List<VertexGraph> X, Graph graph, List<List<VertexGraph>> MaxCliques)
        {

            if (!P.Any() && !X.Any())
            {
                if (R.Count >= 3)
                    MaxCliques.Add(R);
                return;
            }
            else
            {
                for (int i = 0; i < P.Count; i++)
                {
                    VertexGraph v = P[i];

                    List<VertexGraph> intersectionP = new List<VertexGraph>();
                    List<VertexGraph> intersectionX = new List<VertexGraph>();

                    // Пересечение с P
                    foreach (var u in graph.GetVertexLists(v))
                    {
                        for (int j = 0; j < P.Count; j++)
                        {
                            VertexGraph w = P[j];
                            if (u == w)
                            {
                                intersectionP.Add(u);
                            }
                        }

                        // Пересечение с Х
                        for (int k = 0; k < X.Count; k++)
                        {
                            VertexGraph l = X[k];
                            if (u == l)
                                intersectionX.Add(u);
                        }
                    }
                    List<VertexGraph> R_new = new List<VertexGraph>(R);
                    R_new.Add(v);
                    BronKerbosh(R_new, intersectionP, intersectionX, graph, MaxCliques);
                    P.Remove(v);
                    X.Add(v);
                }
            }
        }
    }
}
