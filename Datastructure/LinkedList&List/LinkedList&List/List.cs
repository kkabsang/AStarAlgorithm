using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithim
{
    class MyList<T>
    {
        const int DEFAULT_SIZE = 1;
        T[] _data = new T[DEFAULT_SIZE];
        public int Count = 0;//실제로 사용중인 데이터 개수
        public int Capacity { get { return _data.Length; } }//예약된 데이터 개수

        //O(1) 예외케이스-이사비용 고려 x
        public void Add(T item)
        {
            //공간이 남았는지?
            if (Count >= Capacity)
            {
                //공간 늘리기
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = _data[i];
                }
                _data = newArray;
            }
            //공간에 데이터 삽입
            _data[Count] = item;
            Count++;
        }
        //O(1)
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }
        //O(N)
        public void RemoveAt(int index)
        {
            //
            for (int i = index; i < Count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _data[Count - 1] = default(T);//마지막 방 삭제
            Count--;
        }
    }
    class Board
    {
        public int[] _data = new int[25];
        public MyList<int> _data2 = new MyList<int>();//백터, 동적배열
        public LinkedList<int> _data3 = new LinkedList<int>();//연결리스트
        public void Initialize()
        {
            _data2.Add(101);
            _data2.Add(102);
            _data2.Add(103);
            _data2.Add(104);
            _data2.Add(105);

            int temp = _data2[2];

            _data2.RemoveAt(2);
        }
    }
}
//배열-연속된방 삽입,삭제x,  동적배열-삽입삭제O,N번째 접근 쉬움, 연결리스트-추가삭제 자유로움 N번째 접근힘듬 
//시간복잡도