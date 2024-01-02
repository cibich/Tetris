using System.Collections.Generic;
using UnityEngine;

public static class SaveLoadService
{
    private const string KEY = "Progress";

    public static void SaveProgress(ProgressDataList progressDataList)
    {
        string progressListJson = JsonUtility.ToJson(progressDataList);
        PlayerPrefs.SetString(KEY, progressListJson);
        PlayerPrefs.Save();
    }

    public static ProgressDataList LoadProgress()
    {
        string progressListJson = PlayerPrefs.GetString(KEY);
        if (progressListJson == string.Empty)
        { return new ProgressDataList(new List<Progress>()); }

        ProgressDataList savedProgressList = JsonUtility.FromJson<ProgressDataList>(progressListJson);
        return savedProgressList;
    }
}
