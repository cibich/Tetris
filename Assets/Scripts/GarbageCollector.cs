using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    private void OnEnable()
    {
        Grid.OnCollision += RemoveEmptyParent;
    }

    private void OnDisable()
    {
        Grid.OnCollision -= RemoveEmptyParent;
    }

    private void RemoveEmptyParent()
    {
        foreach (var figure in GameObject.FindGameObjectsWithTag(Constants.FIGURE_TAG))
        {
            if (figure.transform.childCount == 0)
                Destroy(figure);
        }
    }
}
