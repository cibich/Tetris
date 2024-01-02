using System;
using System.Collections.Generic;

[Serializable]
public class ProgressDataList
{
    public List<Progress> ProgressList;

    public ProgressDataList(List<Progress> progressList)
    {
        ProgressList = progressList;
    }

    public void Sort()
    {
        ProgressList.Sort((p1, p2) =>
        {
            int compareScore = p2.Score.CompareTo(p1.Score);
            if (compareScore != 0)
                return compareScore;

            int compareCompletionTime = p1.CompletionTime.CompareTo(p2.CompletionTime);
            if (compareCompletionTime != 0)
                return compareCompletionTime;

            return string.Compare(p1.Username, p2.Username, StringComparison.Ordinal);
        });
    }
}
