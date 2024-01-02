using Assets.Scripts;
using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameOver;
    public float Tempo = 0.6f;

    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private LeaderboardView _leaderboard;
    [SerializeField] private ViewController _view;
    [SerializeField] private InputService _inputService;
    [SerializeField] private FigureSpawner _spawner;
    [SerializeField] private Figure _currentFigure;
    [SerializeField] private Grid _grid;
    [SerializeField] private Timer _timer;
    [SerializeField] private float[] _startPositionX;
    [SerializeField] private float _startPositionY;

    private void OnEnable()
    {
        Grid.OnCollision += NewIteration;
    }

    private void OnDisable()
    {
        Grid.OnCollision -= NewIteration;
    }

    private void Start()
    {
        _inputService.IsActiveInputService = true;
        NewFigure();
        StartCoroutine(FigureMoveToTop());
    }

    private void NewIteration()
    {
        StopAllCoroutines();
        _grid.AddRows(_currentFigure.GetBlocksTransform());
        _grid.CheckRows();
        NewFigure();
        if (_currentFigure != null)
            StartCoroutine(FigureMoveToTop());
    }

    private void NewFigure()
    {
        Vector2 spawnPosition = new Vector2(GetRandomXPoint(), _startPositionY);

        if (_grid.CheckCollisionBlocks(spawnPosition) == false)
        {
            _currentFigure = _spawner.GetNextFigure();
            _currentFigure.transform.position = spawnPosition;
            _inputService.CurrentFigure = _currentFigure;
            _view.ChangeCurrentFigureSprite(_currentFigure);
        }
        else
            StopGame();
    }

    private IEnumerator FigureMoveToTop()
    {
        while (_grid.IsValidMove(_currentFigure.GetBlocksTransform(), Direction.Up))
        {
            _currentFigure.Move(Direction.Up);
            yield return new WaitForSeconds(Tempo);
        }
    }

    public void StopGame()
    {
        StopAllCoroutines();
        OnGameOver?.Invoke();
        Grid.OnCollision -= NewIteration;
        _inputService.IsActiveInputService = false;
        _leaderboard.SetLeaderboard(GameInfo.Username, _scoreManager.Score, _timer.Time);
    }

    private float GetRandomXPoint()
    {
        return _startPositionX[UnityEngine.Random.Range(0, _startPositionX.Length)];
    }
}
