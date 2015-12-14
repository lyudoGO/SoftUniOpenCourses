namespace RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Dictionary<int, List<int>> roundDance = new Dictionary<int, List<int>>();
        private static List<int> visited = new List<int>();
        private static int longestDance;

        static void Main()
        {
            int numberOfFriendships = int.Parse(Console.ReadLine());
            int numberOfLeader = int.Parse(Console.ReadLine());

            roundDance = ReadFriendships(numberOfFriendships);
            FindLongestDanceDFS(numberOfLeader);
            Console.WriteLine(longestDance);
        }

        private static void FindLongestDanceDFS(int friendValue)
        {
            if (!visited.Contains(friendValue))
            {
                visited.Add(friendValue);
                longestDance = 0;

                foreach (var friend in roundDance[friendValue])
                {
                    FindLongestDanceDFS(friend);
                }

                longestDance++;
            }
        }

        private static Dictionary<int, List<int>> ReadFriendships(int numberOfFriendships)
        {
            var roundDance = new Dictionary<int, List<int>>();
            for (int i = 0; i < numberOfFriendships; i++)
            {
                var friendship = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int keyFriend = int.Parse(friendship[0]);
                int valueFriend = int.Parse(friendship[1]);

                if (!roundDance.ContainsKey(keyFriend))
                {
                    roundDance[keyFriend] = new List<int> { valueFriend };
                }
                else
                {
                    roundDance[keyFriend].Add(valueFriend);
                }

                if (!roundDance.ContainsKey(valueFriend))
                {
                    roundDance[valueFriend] = new List<int> { keyFriend };
                }
                else
                {
                    roundDance[valueFriend].Add(keyFriend);
                }
            }

            return roundDance;
        }
    }
}
