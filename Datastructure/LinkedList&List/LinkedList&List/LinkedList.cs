using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithim1
{
    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;//다음방
        public MyLinkedListNode<T> Prev;//이전방
    }
    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null;
        public MyLinkedListNode<T> Tail = null;
        public int Count = 0;

        //O(1)
        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            //방이 없을때 새로 추가한 방이 head
            if (Head == null)
            { Head = newRoom; }
            //마지막 방과 새로 추가되는 방을 연결 
            if (Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }
            //새로추가된 방  tail
            Tail = newRoom;
            Count++;
            return newRoom;
        }
        //O(1)
        public void Remove(MyLinkedListNode<T> room)
        {
            //첫번째 다음방을 첫번째방으로 
            if (Head == room)
                Head = Head.Next;
            //마지막방 이전방을 마지막방으로 
            if (Tail == room)
                Tail = Tail.Prev;
            if (room.Prev != null)
                room.Prev.Next = room.Next;
            if (room.Next != null)
                room.Next.Prev = room.Prev;
            Count--;
        }
    }
    class Board
    {
        public int[] _data = new int[25];

        public MyLinkedList<int> _data3 = new MyLinkedList<int>();//연결리스트
        public void Initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);
        }
    }
}
