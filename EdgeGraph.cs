using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class EdgeGraph
    {
        public VertexGraph From { get; set; }
        public VertexGraph To { get; set; }
        public bool Oriented { get; set; }
        public int Weight { get; set; }
        public EdgeGraph(VertexGraph from, VertexGraph to,int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"({From}; {To}; {Weight})";
        }
    }
}
