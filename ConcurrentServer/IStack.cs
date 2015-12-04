using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentServer
{
    public interface IStack
    {
        void push(int No);
        int pop();
        string GetStackData();
        string Log();
    }
}
