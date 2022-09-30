using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueue
{
    class PriorityQueue<T> where T : IComparable<T>
{
    List<T> _heap = new List<T>();

    //시간 복잡도 0(logN)
    public void Push(T data)
    {
        //힙의 맨 끝에 새로운 데이터를 삽입
        _heap.Add(data);
        int now = _heap.Count - 1;
        while (now > 0)
        {
            int next = (now - 1) / 2;
            if (_heap[now].CompareTo(_heap[next]) < 0)
                break;
            //두값 교체
            T temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp;
            //검사 위치 이동
            now = next;
        }
    }
    //시간 복잡도 0(logN)
    public T Pop()
    {
        //반환 데이터 따로 저장
        T ret = _heap[0];
        //마지막 데이터를 루트로
        int lastIndex = _heap.Count - 1;
        _heap[0] = _heap[lastIndex];
        _heap.RemoveAt(lastIndex);
        lastIndex--;

        //역으로 값비교
        int now = 0;
        while (true)
        {
            int left = 2 * now + 1;
            int right = 2 * now + 2;

            int next = now;
            //왼쪽 값이 현재보다 크면 왼쪽으로 이동
            if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                next = left;
            //오른쪽 값이 현재값(왼쪽포함)보다 크면, 오른쪽으로 이동
            if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                next = right;
            //왼쪽, 오른쪽 모두 현재값보다 작으면 종료
            if (next == now)
                break;
            //두값 교체
            T temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp;
            now = next;


        }
        return ret;
    }
    public int Count()
    {
        return _heap.Count;
    }
}

class Knight : IComparable<Knight>
{
    public int Id { get; set; }

    public int CompareTo(Knight other)
    {
        if (Id == other.Id)
            return 0;
        return Id > other.Id ? 1 : -1;//내아이디가 상대 아이디 보다 크면 1 아니면 -1반환
    }

 }
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<Knight> q = new PriorityQueue<Knight>();
            q.Push(new Knight() { Id = -20 });
            q.Push(new Knight() { Id = -100 });
            q.Push(new Knight() { Id = -500 });
            q.Push(new Knight() { Id = -40 });
            q.Push(new Knight() { Id = -10 });

            while (q.Count() > 0)
            {
                Console.WriteLine(-q.Pop().Id);
            }
        }
    }
}

