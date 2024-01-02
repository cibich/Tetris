using System.Collections.Generic;
using UnityEngine;

public enum FigureType
{
    O, L, J, S, Z, T, I,
}

public class Figure : MonoBehaviour
{
    public Sprite Sprite;
    public Color Color;
    public FigureType Type;

    [SerializeField] private List<Transform> _blocks = new List<Transform>();

    private void Awake()
    {
        AddBlocksTransform();
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction, Space.World);
    }

    public void Rotate(Vector3 rotateDir)
    {
        transform.Rotate(rotateDir, Space.World);
    }

    public void AsignBlockColor()
    {
        Color = GetRandomColor();

        foreach (var block in _blocks)
        {
            block.GetComponent<SpriteRenderer>().color = Color;
        }
    }

    public List<Transform> GetBlocksTransform()
    {
        if (transform.childCount > 0)
            _blocks.Clear();

        AddBlocksTransform();

        return _blocks;
    }

    private void AddBlocksTransform()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform block = transform.GetChild(i);
            if (block != null)
                _blocks.Add(block);
        }
    }

    private Color GetRandomColor() => new Color(Random.value, Random.value, 1f);
}
