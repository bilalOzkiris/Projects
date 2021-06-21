using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class StackX
    {
        private int maxSize;
        private int[] stackArray;
        private int top;

        public StackX(int s)
        {
            maxSize = s;
            stackArray = new int[maxSize];
            top = -1;
        }

        public void push(int j)
        {
            stackArray[++top] = j;
        }

        public int pop()
        {
            return stackArray[top--];
        }

        public int peek()
        {
            return stackArray[top];
        }

        public bool isEmpty()
        {
            return top == -1;
        }

        public bool isFull()
        {
            return top == maxSize - 1;
        }
    }
}
