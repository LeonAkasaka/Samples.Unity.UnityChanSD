using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField]
    private Game _game = null;

    private void OnCollisionEnter(Collision collision)
    {
        var item = collision.gameObject.GetComponent<Item>();
        if (item == null) { return; }

        _game.TotalScore += item.Score;
        Destroy(item.gameObject);
    }
}
