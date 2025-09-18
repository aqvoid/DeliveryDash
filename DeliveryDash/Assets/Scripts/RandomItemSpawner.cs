using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    private void Start()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        RandomItemManager manager = FindAnyObjectByType<RandomItemManager>();
        if (manager == null) return;

        GameObject prefab = manager.GetRandomPrefab();
        if (prefab != null)
            Instantiate(prefab, transform.position, transform.rotation, transform.parent);

        Destroy(gameObject);
    }
}
