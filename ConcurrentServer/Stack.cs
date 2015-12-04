using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentServer
{
    class Stack : IStack
    {
        int[] Array;
        int StackLength;
        int StackPointer;
        string Logs;

        public Stack(int StackLength)
        {
            this.StackLength = StackLength;
            Array = new int[this.StackLength];
            StackPointer = 0;            
        }

        public void push(int No)
        {
            if (StackPointer <= StackLength)
            {
                Array[StackPointer] = No;
                StackPointer++;
                CreateLog(">>PUSH " + StackLength);
            }
        }

        public int pop()
        {
            int NoToReturn = 0;
            if (Array.Length >= 0)
            {
                StackPointer--;
                NoToReturn = Array[StackPointer];
                Array[StackPointer] = 0;
                CreateLog(">>POP " + NoToReturn);
            }
            return NoToReturn;
        }

        public string GetStackData()
        {
            string ArrayData = string.Empty;
            for (int i = 0; i <= StackPointer; i++)
            {
                if (string.IsNullOrEmpty(ArrayData))
                {
                    ArrayData = Array[i].ToString();
                }
            }
            CreateLog(">>DATA SENT ON " + DateTime.Now );
            return ArrayData;            
        }

        public void CreateLog(string Message)
        {
            if (string.IsNullOrEmpty(Logs))
            {
                Logs = Message;
            }
            else
            {
                Logs = Logs + Environment.NewLine + Message;
            }
        }        

        public string Log()
        {
            CreateLog(">>LOGS PROVIDED ON " + DateTime.Now);
            return Logs;
        }      

    }
}
