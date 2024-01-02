using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ViewController _view;
    public int Score { get; private set; } = 1;
    
    private void OnEnable()
    {
        Row.OnScoreUpdate += ScoreUpdate;
    }

    private void OnDisable()
    {
        Row.OnScoreUpdate -= ScoreUpdate;
    }

    private void ScoreUpdate(int score)
    {
        if (GameInfo.IsHardMode==false)
            score /= 5;

        Score += score;
        _view.ScoreUpdate(Score);
    }
}
