using System.Collections.Generic;
using UnityEngine;

public class FigureSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _classicTetrisFigures;
    [SerializeField] private GameObject[] _hardModeFigures;
    private Queue<Figure> _figures = new Queue<Figure>();
    private int _capacity = 10;
    private bool _isHardMode = false;

    private void Awake()
    {
        _isHardMode = GameInfo.IsHardMode;
        Debug.Log(_isHardMode);
        Initialize();
    }

    public Figure GetNextFigure()
    {
        if (_figures.Count < _capacity)
            Initialize();

        return _figures.Dequeue();
    }

    public Figure GetSpriteNextFigure()
    {
        return _figures.Peek();
    }

    private void Initialize()
    {
        int count = _figures.Count;

        while (count < _capacity)
        {
            _figures.Enqueue(SpawnNewFigure());
            count++;
        }
    }

    private Figure SpawnNewFigure()
    {
        if (_isHardMode)
            return GetNewFigure(_hardModeFigures);
        else
            return GetNewFigure(_classicTetrisFigures);
    }

    private Figure GetNewFigure(GameObject[] figureArray)
    {
        GameObject gameObject = Instantiate(figureArray[GetRandomIndex()], transform.position, Quaternion.identity);
        Figure figure = gameObject.GetComponent<Figure>();
        figure.AsignBlockColor();
        return figure;
    }

    private int GetRandomIndex()
    {
        if (_isHardMode)
            return Random.Range(0, _hardModeFigures.Length);
        else return Random.Range(0, _classicTetrisFigures.Length);
    }
}
