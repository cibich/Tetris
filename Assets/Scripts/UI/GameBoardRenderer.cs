using UnityEngine;

public class GameBoardRenderer : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private GameObject _boundPrefab;

    private void Start()
    {
        DrawGameBoard();
    }

    private void DrawGameBoard()
    {
        Vector2 startPosition = (Vector2)transform.position - new Vector2((_grid.Width - 1) * _grid.CellSize / 2, (_grid.Height - 1) * _grid.CellSize / 2);

        for (int row = 0; row < _grid.Height; row++)
        {
            for (int col = 0; col < _grid.Width; col++)
            {
                Vector2 cellPosition = startPosition + new Vector2(col * _grid.CellSize, row * _grid.CellSize);

                if (Mathf.Abs(cellPosition.x) == Mathf.Abs(_grid.BoundX) || Mathf.Abs(cellPosition.y) == Mathf.Abs(_grid.BoundY))
                    SpawnCell(_boundPrefab, cellPosition);
                else
                    SpawnCell(_cellPrefab, cellPosition);
            }
        }
    }

    private void SpawnCell(GameObject cell,Vector2 cellPosition)
    {
        Instantiate(cell, cellPosition, Quaternion.identity, transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        float gridWidth = _grid.Width * _grid.CellSize;
        float gridHeight = _grid.Height * _grid.CellSize;
        Vector3 startPos = transform.position - new Vector3(gridWidth / 2, gridHeight / 2);

        for (int i = 0; i <= _grid.Width; i++)
        {
            Vector3 start = startPos + Vector3.right * i * _grid.CellSize;
            Vector3 end = start + Vector3.up * gridHeight;
            Gizmos.DrawLine(start, end);
        }

        for (int i = 0; i <= _grid.Height; i++)
        {
            Vector3 start = startPos + Vector3.up * i * _grid.CellSize;
            Vector3 end = start + Vector3.right * gridWidth;
            Gizmos.DrawLine(start, end);
        }
    }
}
