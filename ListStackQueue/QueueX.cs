using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class QueueX
    {
        private int maxSize;
        private int[] queArray;
        private int front;
        private int rear;
        private int nItems;

        public QueueX(int s)
        {
            maxSize = s;
            queArray = new int[maxSize];
            front = 0;
            rear = -1;
            nItems = 0;
        }

        public void insert(int j)
        {
            if (rear == maxSize - 1)
            {
                rear = -1;
            }
            queArray[++rear] = j;
            nItems++;
        }

        public int remove()
        {
            int temp = queArray[front++];
            if (front == maxSize)
            {
                front = 0;
            }
            nItems--;
            return temp;
        }

        public int peekFront()
        {
            return queArray[front];
        }

        public bool isEmpty()
        {
            return nItems == 0;
        }

        public bool isFull()
        {
            return nItems == maxSize;
        }

        public int size()
        {
            return nItems;
        }

    }
}
