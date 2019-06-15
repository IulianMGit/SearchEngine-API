using Accord.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine_DataService.Utils
{
    public static class CustomMergeSort
    {
        public static List<KeyValuePair<int, string>> MergeKSortedLists(Dictionary<string, List<int>> lists)
        {
            var result = new List<KeyValuePair<int, string>>();
            var pq = new PriorityQueue<KeyValuePair<int, string>>(lists.Count, PriorityOrder.Minimum);

            foreach (var list in lists)
                if (list.Value.Count > 0)
                    pq.Enqueue(new KeyValuePair<int, string>(0, list.Key), list.Value[0]);

            while (pq.Count != 0)
            {
                var curr = pq.Dequeue();

                var i = curr.Value.Value;
                var j = curr.Value.Key;

                result.Add(new KeyValuePair<int, string>(lists[i][j], i));

                if ((j + 1) < lists[i].Count)
                    pq.Enqueue(new KeyValuePair<int, string>(j + 1, i), lists[i][j + 1]);
            }

            return result;
        }
    }
}
