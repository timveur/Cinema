using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Node
    {
        private List<Node> _nodes = new List<Node>();

        public int IdSeat { get; set; }
        public int ParentId { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Дочерние элементы 
        /// </summary>
        public List<Node> Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }
    }
}
