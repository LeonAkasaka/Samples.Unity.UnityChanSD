using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private int _score = 0;

    public int Score { get { return _score; } }

    private void Update()
    {
        transform.Rotate(0, 1, 0, Space.World);
    }
}
