using UnityEngine;

public class RandomItemManager : MonoBehaviour
{
    private const byte TOTALSPAWNERS = 20;

    private int count0 = 0;
    private int count1 = 0;

    [Header("=== Prefabs ===")]
    [SerializeField] private GameObject[] prefabs;
    // prefabs[0] and prefabs[1] in array are paired, others are independent

    [Header("=== Settings ===")]
    [SerializeField, Range(2, 10)] private int fixedCount;

    private void Awake()
    {
        CheckPossibleCount();
        RandomFixedCount();
    }

    private void RandomFixedCount() => fixedCount = Random.Range(2, 11);

    private void CheckPossibleCount()
    {
        int maxPossible = TOTALSPAWNERS / 2;
        int minPossible = 2;

        if (fixedCount > maxPossible)
        {
            Debug.LogWarning($"[RandomItemManager] {fixedCount} is too big!");
            fixedCount = maxPossible;
        }
        if (fixedCount < minPossible)
        {
            Debug.LogWarning($"[RandomItemManager] {fixedCount} is too small!");
            fixedCount = minPossible;
        }
    }

    public GameObject GetRandomPrefab()
    {
        if (count0 < fixedCount || count1 < fixedCount)
        {
            if (count0 < count1 && count0 < fixedCount)
            {
                count0++;
                return prefabs[0];
            }
            if (count1 < count0 && count1 < fixedCount)
            {
                count1++;
                return prefabs[1];
            }

            int choice = Random.Range(0, 2);
            if (choice == 0 && count0 < fixedCount)
            {
                count0++;
                return prefabs[0];
            }
            else if (choice == 1 && count1 < fixedCount)
            {
                count1++;
                return prefabs[1];
            }
        }

        int otherItems = Random.Range(2, prefabs.Length);
        return prefabs[otherItems];
    }
}
