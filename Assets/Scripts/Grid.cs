using System;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static event Action OnCollision;

    public int Height { get; } = 20;
    public int Width { get; } = 12;
    public float CellSize { get; } = 0.5f;
    public float BoundX { get; } = -2.75f;
    public float BoundY { get; } = -4.75f;

    [SerializeField] private List<Row> _rows;
    private float _shift = 0.5f;

    public bool IsValidMove(List<Transform> blocks, Vector3 direction)
    {
        foreach (var block in blocks)
        {
            Vector3 pos = block.transform.position + direction;

            if (Mathf.Abs(pos.x) >= Mathf.Abs(BoundX))
                return false;

            if (pos.y >= Mathf.Abs(BoundY) || CheckCollisionBlocks(pos))
            {
                OnCollision?.Invoke();
                return false;
            }
        }
        return true;
    }

    public bool IsValidRotate(Transform parent, Vector3 rotateAngle)
    {
        Quaternion originalRotate = parent.rotation;
        parent.Rotate(rotateAngle);

        for (int i = 0; i < parent.childCount; i++)
        {
            Vector2 blockPos = parent.GetChild(i).position;

            if (Mathf.Abs(blockPos.x) >= Mathf.Abs(BoundX))
            {
                parent.rotation = originalRotate;
                return false;
            }

            if (blockPos.y >= Mathf.Abs(BoundY) || CheckCollisionBlocks(blockPos))
            {
                parent.rotation = originalRotate;
                OnCollision?.Invoke();
                return false;
            }
        }
        parent.rotation = originalRotate;
        return true;
    }

    public void AddRows(List<Transform> blocks)
    {
        foreach (var row in _rows)
        {
            row.AddBlock(blocks);
        }
    }

    public void CheckRows()
    {
        foreach (var row in _rows)
        {
            row.RemoveBlocks();
        }
    }

    public bool CheckCollisionBlocks(Vector2 position)
    {
        foreach (var row in _rows)
        {
            if (Mathf.Approximately(row.transform.position.y, position.y))
            {
                return row.CheckCollision(position);
            }
        }
        return false;
    }

    private void OnEnable()
    {
        Row.OnRowFull += ChangeRowPosition;
        RowIndexation();
    }

    private void OnDisable()
    {
        Row.OnRowFull -= ChangeRowPosition;
    }

    private void ChangeRowPosition(int indexRow)
    {
        foreach (var row in _rows)
        {
            if (row.IndexRow == indexRow)
            {
                row.transform.position = new Vector2(row.transform.position.x, -(Mathf.Abs(BoundY) - _shift));
                row.ChangeBlockPosition(_rows.Count - 1);
            }
            else if (row.IndexRow > indexRow)
            {
                row.transform.position = (Vector2)row.transform.position + new Vector2(0, _shift);
                row.ChangeBlockPosition(row.IndexRow - 1);
            }
        }
    }

    private void RowIndexation()
    {
        for (int i = 0; i < _rows.Count; i++)
        {
            _rows[i].IndexRow = i;
        }
    }
}
