using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class PQueProvince
    {
        private int maxSize;
        private List<Province> pqArray;
        private int front;
        private int rear;
        private int nItems;

        public PQueProvince(int s)
        {
            maxSize = s;
            pqArray = new List<Province>(maxSize);
            front = 0;
            rear = -1;
            nItems = 0;
        }

        public void insert(Province item)
        {
            if (rear == maxSize - 1)
            {
                rear = -1;
            }
            pqArray.Add(item);
            rear++;
            nItems++;
        }

        public Province remove()
        {
            Province max = pqArray[0];
            int maxIndex = 0;
            for (int i = 1; i < nItems; i++)
            {
                int compValue = string.Compare(pqArray[i].getProvinceName(), max.getProvinceName());
                if (compValue > 0)
                {
                    max = pqArray[i];
                    maxIndex = i;
                }
                
            }
            pqArray.RemoveAt(maxIndex);
            nItems--;
            return max;
        }

        public Province peekFront()
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
