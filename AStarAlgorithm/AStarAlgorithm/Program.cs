using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;


namespace Algorithim
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();
            board.Initialize(25, player);
            player.Initialize(1, 1, board);
            Console.CursorVisible = false;
            
            int lastTick = 0;
            const int WAIT_TICK = 1000 / 30;
            
            while(true)
            {
                #region 프레임관리
                int currentTick = System.Environment.TickCount;
                //경과한 시간이 1/30초보다 작으면
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                int deltaTick = currentTick - lastTick;//현재tick과 마지막tick의 값 차
                lastTick = currentTick;
                #endregion
                //FPS 프레임(60 Ok)
                //입력

                //로직
                player.Update(deltaTick);
                //렌더링

                Console.SetCursorPosition(0,0);
                board.Render();
                                
            }
            
        }
    }
}
//시간 복잡도 big-o 