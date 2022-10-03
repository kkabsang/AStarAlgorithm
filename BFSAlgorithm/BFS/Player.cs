using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Algorithim
{
    class Pos
    {
        public Pos(int y, int x) { Y = y; X = x; }
        public int Y;
        public int X;
    }
    class Player
    {
        public int PosY { get; private set; }
        public int PosX { get; private set; }
        Random _random = new Random();

        Board _board;
        enum Dir
        {
            Up = 0,
            Left = 1,
            Down = 2,
            Right = 3
        }
        int _dir = (int)Dir.Up;
        List<Pos> _points = new List<Pos>();
        public void Initialize(int posY, int posX, Board board)
        {
            PosY = posY;
            PosX = posX;

            _board = board;
            BFS();
            

        }
        struct PQNode: IComparable<PQNode>
        {
            public int F;
            public int G;
            public int Y;
            public int X;

            public int CompareTo( PQNode other)
            {
                if (F == other.F)
                    return 0;
                return F < other.F ? 1 : -1;
            }
        }
       
        void BFS()
        {
            int[] deltaY = new int[] {-1,0,1,0 };
            int[] deltaX = new int[] {0,-1,0,1 };
            bool[,] found = new bool[_board.Size, _board.Size];
            Pos[,] parent = new Pos[_board.Size, _board.Size];

            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(new Pos(PosY, PosX));
            found[PosY, PosX] = true;
            parent[PosY, PosX] = new Pos(PosY, PosX);

            while(q.Count>0)
            {
                Pos pos = q.Dequeue();
                int nowY = pos.Y;
                int nowX = pos.X;

                for(int i=0; i<4; i++)
                {
                    int nextY = nowY + deltaY[i];
                    int nextX = nowX + deltaX[i];
                    if (nextX < 0 || nextX >= _board.Size || nextY < 0 || nextY >= _board.Size)
                        continue;
                    if (_board.Tile[nextY, nextX] == Board.TileType.Wall)
                        continue;
                    if (found[nextY, nextX])
                        continue;

                    q.Enqueue(new Pos(nextY, nextX));
                    found[nextY, nextX] = true;
                    parent[nextY, nextX] = new Pos(nowY, nowX);

                }
            }
            CalcPathFromParent(parent);
        }
        void CalcPathFromParent(Pos[,] parent)
        {
            int y = _board.DestY;
            int x = _board.DestX;
            while (parent[y, x].Y != y || parent[y, x].X != x)
            {
                _points.Add(new Pos(y, x));
                Pos pos = parent[y, x];
                y = pos.Y;
                x = pos.X;
            }
            _points.Add(new Pos(y, x));//시작점 add
            _points.Reverse();
        }
        

        const int MOVE_TICK = 50;
        int _sumTick = 0;
        int _lastIndex = 0;
        public void Update(int deltaTick)
        {
            if (_lastIndex >= _points.Count)
            {
                _lastIndex = 0;
                _points.Clear();
                _board.Initialize(_board.Size, this);
                Initialize(1, 1, _board);
            }
            _sumTick += deltaTick;
            if(_sumTick>=MOVE_TICK)
            {
                _sumTick = 0;
                PosY = _points[_lastIndex].Y;
                PosX = _points[_lastIndex].X;
                _lastIndex++;
            }

        }
    }
}
