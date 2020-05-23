using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class VertexGraph : IEquatable<VertexGraph>
    {
        public int Number{get; set;}
        public VertexGraph (int number)
        {
            Number = number;
        }

       public bool Equals(VertexGraph other)
        {
            if (other == null)
                return false;

            if (this.Number == other.Number)
                return true;
            else 
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            VertexGraph vertexObj = obj as VertexGraph;
            if (vertexObj == null)
                return false;
            else
                return (Equals(vertexObj));
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }

        public static bool operator == (VertexGraph v1,VertexGraph v2)
        {
            if (((object)v1) == null || ((object)v2) == null)
                return Object.Equals(v1, v2);
            return v1.Equals(v2);
        }

        public static bool operator != (VertexGraph v1, VertexGraph v2)
        {
            if (((object)v1) == null || ((object)v2) == null)
                return !Object.Equals(v1, v2);
            return !(v1.Equals(v2));
        }        
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
