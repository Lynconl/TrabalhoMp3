using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoMP3.Model;

namespace TrabalhoMP3.Controller
{
    class List
    {
        private Node begin = null, end = null;

        internal Node Begin { get => begin; set => begin = value; }
        internal Node End { get => end; set => end = value; }


        //Adiciona músicas
        public void InsertMusic(string Name, string Duraction, string Bitrate)
        {
            Node newNode = new Node(Name, Duraction, Bitrate);
            newNode.Name = Name;
            newNode.Duraction = Duraction;
            newNode.Bitrate = Bitrate;

            if (Begin == null)
            {
                Begin = newNode;
                End = newNode;
            }
            else
            {
                End.Next = newNode;
            }
            End = newNode;
        }
    }
}
