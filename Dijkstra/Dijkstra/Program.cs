using System;

namespace Dijkstra
{
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            { -1, 15, -1, 35, -1, -1 },
            { 15, -1, 05, 10, -1, -1 },
            { -1, 05, -1, -1, -1, -1 },
            { 35, 10, -1, -1, 05, -1 },
            { -1, -1, -1, 05, -1, 05 },
            { -1, -1, -1, -1, 05, -1 }
        };

        public void Dijkstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];
            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = start;

            while (true)
            {
                //가장 가까운 거리를 찾는다

                //가장 유력한 후보의 거리와 번호 저장
                int closest = Int32.MaxValue;
                int now = -1;
                for (int i = 0; i < 6; i++)
                {
                    //이미 방문한 곳 스킵
                    if (visited[i])
                        continue;
                    //아직 예약 안된 곳이거나 기존 후보보다 멀리 있으면 스킵
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest)
                        continue;
                    //가장 가까운 후보이므로 정보 갱신
                    closest = distance[i];
                    now = i;
                }
                //다음 후보 없다->종료
                if (now == -1)
                    break;

                //제일 좋은 후보 찾앗으니 방문
                visited[now] = true;
                //방문한 정점과 인접한 정점들을 조사
                //상황에 따라 발견한 최단거리를 갱신
                for (int next = 0; next < 6; next++)
                {
                    //연결되지 않은 정점 스킵
                    if (adj[now, next] == -1)
                        continue;
                    if (visited[next])//이미 방문했으면 스킵
                        continue;

                    //새로 조사된 정점의 최단거리를 계산
                    int nextDist = distance[now] + adj[now, next];
                    //기존 거리가 새로 조사된 거리보다 크면 정보를 갱신
                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }
            }


        }
        class Program
        {
            static void Main(string[] args)
            {
                Graph graph = new Graph();
                graph.Dijkstra(0);
            }
        }
    }
}
