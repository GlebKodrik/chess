using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    interface IChess
    {
        void Print(string str);
    }
    class Line : IChess
    {
        public void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
