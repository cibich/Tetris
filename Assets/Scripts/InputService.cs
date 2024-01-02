using Assets.Scripts;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public bool IsActiveInputService;
    public Figure CurrentFigure;

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Grid _grid;
    [SerializeField] private float _defaultTempo = 0.6f;
    [SerializeField] private float _fastTempo = 0.05f;

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (IsActiveInputService)
        {
            CheckMovementInput();
            CheckAccelerationInput();
            CheckRotationInput();
        }
    }

    private void CheckRotationInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && CurrentFigure.Type != FigureType.O)
        {
            if (_grid.IsValidRotate(CurrentFigure.transform, Direction.RightRotate))
                CurrentFigure.Rotate(Direction.RightRotate);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && CurrentFigure.Type != FigureType.O)
        {
            if (_grid.IsValidRotate(CurrentFigure.transform, Direction.LeftRotate))
                CurrentFigure.Rotate(Direction.LeftRotate);
        }
    }

    private void CheckAccelerationInput()
    {
        if (Input.GetKey(KeyCode.W))
            _gameManager.Tempo = _fastTempo;
        else
            _gameManager.Tempo = _defaultTempo;
    }

    private void CheckMovementInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_grid.IsValidMove(CurrentFigure.GetBlocksTransform(), Direction.Left))
                CurrentFigure.Move(Direction.Left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (_grid.IsValidMove(CurrentFigure.GetBlocksTransform(), Direction.Right))
                CurrentFigure.Move(Direction.Right);
        }
    }
}
