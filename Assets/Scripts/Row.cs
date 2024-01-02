using System;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    public static event Action<int> OnRowFull;
    public static event Action<int> OnScoreUpdate;

    public int IndexRow;
    public int CountBlocks { get; private set; }

    [SerializeField] private List<Transform> _blocksContainer = new List<Transform>();
    private int _maxCountBlocks = 10;

    public void AddBlock(List<Transform> blocks)
    {
        _blocksContainer.RemoveAll(item => item == null);
        for (int i = 0; i < blocks.Count; i++)
        {
            if (Mathf.Approximately(transform.position.y, blocks[i].position.y))
            {
                blocks[i].tag = Constants.BLOCK_TAG;
                _blocksContainer.Add(blocks[i]);
                CountBlocks++;
            }
        }
    }

    public void RemoveBlocks()
    {
        if (CountBlocks >= _maxCountBlocks)
        {
            OnRowFull?.Invoke(IndexRow);
            OnScoreUpdate?.Invoke(CountBlocks);
            foreach (var item in _blocksContainer)
            {
                Destroy(item.gameObject);
            }
            _blocksContainer.Clear(); CountBlocks = 0;
        }
    }

    public bool CheckCollision(Vector2 position)
    {
        foreach (var block in _blocksContainer)
        {
            if (Mathf.Approximately(block.transform.position.x, position.x) && Mathf.Approximately(block.transform.position.y, position.y))
                return true;
        }
        return false;
    }

    public void ChangeBlockPosition(int indexRow)
    {
        IndexRow = indexRow;
        foreach (var block in _blocksContainer)
        {
            block.transform.position = new Vector2(block.position.x, transform.position.y);
        }
    }
}
