using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoMP3.Model
{
    class Node
    {
        private string name;
        private string duraction;
        private string bitrate;

        private Node next;
        public Node(string name, string duraction, string bitrate)
        {
            name = Name;
            duraction = Duraction;
            bitrate = Bitrate;
            next = null;

        }



        public string Name { get => name; set => name = value; }
        public string Duraction { get => duraction; set => duraction = value; }
        public string Bitrate { get => bitrate; set => bitrate = value; }
        internal Node Next { get => next; set => next = value; }
    }
}
