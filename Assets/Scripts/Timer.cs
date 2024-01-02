using UnityEngine;

public class Timer : MonoBehaviour
{
    public float Time { get; private set; }
    private bool _isFinished = false;

    private void OnEnable()
    {
        GameManager.OnGameOver += StopTimer;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= StopTimer;
    }

    private void Update()
    {
        if (_isFinished == false)
            Time += UnityEngine.Time.deltaTime;
    }

    private void StopTimer()
    {
        _isFinished= true;
    }
}
