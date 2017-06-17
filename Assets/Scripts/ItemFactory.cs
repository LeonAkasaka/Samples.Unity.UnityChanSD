using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    [SerializeField]
    private Item[] _itemPrefabs = null;

    void Start()
    {
        var r = 3.1F;
        for (var x = -3; x <= 3; x++)
        {
            var z = Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow(x, 2));

            var item1 = Instantiate(_itemPrefabs[Random.Range(0, _itemPrefabs.Length)]);
            item1.transform.Translate(x, 0, z, Space.World);
            item1.transform.parent = transform;

            var item2 = Instantiate(_itemPrefabs[Random.Range(0, _itemPrefabs.Length)]);
            item2.transform.Translate(x, 0, -z, Space.World);
            item2.transform.parent = transform;
        }
    }
}
