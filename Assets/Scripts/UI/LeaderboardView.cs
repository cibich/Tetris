using Dan.Main;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _names;
    [SerializeField] private List<TextMeshProUGUI> _scores;
    [SerializeField] private List<TextMeshProUGUI> _times;
    [SerializeField] private List<TextMeshProUGUI> _dates;

    private void Start()
    {
        GetLeaderboard();
    }

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(Constants.DB_KEY, msg =>
        {
            int lenght = 10;
            if (msg.Length <= lenght)
                lenght = msg.Length;

            for (int i = 0; i < lenght; ++i)
            {
                _names[i].text = msg[i].Username;
                _scores[i].text = msg[i].Score.ToString();
                _times[i].text = msg[i].Extra;
                _dates[i].text = DataExtension.FormatDate(msg[i].Date);
            }
        });
    }

    public void SetLeaderboard(string username, int score, float comlTime)
    {
        LeaderboardCreator.GetPersonalEntry(Constants.DB_KEY, dbProgress =>
        {
            if (score > dbProgress.Score)
            {
                LeaderboardCreator.UploadNewEntry(Constants.DB_KEY, username, score, DataExtension.FormatTime(comlTime), IsSuccessful =>
                {
                    if (IsSuccessful)
                        GetLeaderboard();
                });
            }
        });
    }
}
