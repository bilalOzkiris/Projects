using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class PQueDouble
    {
        private int maxSize;
        private List<double> pqArray;
        private int front;
        private int rear;
        private int nItems;

        public PQueDouble(int s)
        {
            maxSize = s;
            pqArray = new List<double>(maxSize);
            front = 0;
            rear = -1;
            nItems = 0;
        }

        public void insert(double j)
        {
            if (rear == maxSize - 1)
            {
                rear = -1;
            }
            pqArray.Add(j);
            rear++;
            nItems++;
        }

        public double remove()
        {
            double min = pqArray[0];
            int minIndex = 0;
            for (int i = 1; i < nItems; i++)
            {
                if (pqArray[i] < min)
                {
                    min = pqArray[i];
                    minIndex = i;
                }

            }
            pqArray.RemoveAt(minIndex);
            nItems--;
            return min;
        }

        public double peekFront()
        {
            return pqArray[front];
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
