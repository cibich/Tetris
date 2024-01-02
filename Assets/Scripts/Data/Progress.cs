using System;

[Serializable]
public struct Progress
{
    public string Username { get; set; }
    public int Score { get; set; }
    public string CompletionTime { get; set; }

    public Progress(string name, int score, string completionTime)
    {
        Username = name;
        Score = score;
        CompletionTime = completionTime;
    }
}
