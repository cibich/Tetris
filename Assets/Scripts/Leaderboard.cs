using Dan.Main;
using System.Collections.Generic;

public static class Leaderboard
{
    //public static List<Progress> GetLeaderboard()
    //{
    //    SaveLoadService.LoadProgress().Sort();
    //    return SaveLoadService.LoadProgress().ProgressList;
    //}

    //public static void SetLeaderboard(Progress progress)
    //{
    //    ProgressDataList progressDataList = new ProgressDataList(SaveLoadService.LoadProgress().ProgressList);

    //    if (IsNameSimilarityCheck(progressDataList.ProgressList, progress) == false)
    //    {
    //        progressDataList.ProgressList.Add(progress);
    //        progressDataList.Sort();
    //        SaveLoadService.SaveProgress(progressDataList);
    //    }
    //    else
    //    {
    //        progressDataList.Sort();
    //        SaveLoadService.SaveProgress(progressDataList);
    //    }
    //}

    //private static bool IsNameSimilarityCheck(List<Progress> savedProgresses, Progress newProgress)
    //{
    //    for (int i = 0; i < savedProgresses.Count; i++)
    //    {
    //        if (newProgress.Username == savedProgresses[i].Username && newProgress.Score <= savedProgresses[i].Score)
    //            return true;
    //        else if (newProgress.Username == savedProgresses[i].Username && newProgress.Score > savedProgresses[i].Score)
    //        {
    //            savedProgresses[i].Score = newProgress.Score;
    //            return true;
    //        }
    //    }
    //    return false;
    //}
}
