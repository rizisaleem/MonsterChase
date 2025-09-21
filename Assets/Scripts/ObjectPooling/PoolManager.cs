using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    [SerializeField] private List<PoolController> poolController = new();

    private Dictionary<string, PoolController> poolDictionary = new();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        InitializeDictionary();
    }

    void InitializeDictionary()
    {
        foreach (var controller in poolController)
        {
            if (controller != null)
            {
                string key = controller.gameObject.name;
                if (!poolDictionary.ContainsKey(key))
                    poolDictionary.Add(key, controller);
                else
                    Debug.LogWarning($"Duplicate pool controller name '{key}' detected.");
            }
        }
    }

    public GameObject GetObject(string poolName)
    {
        if (poolDictionary.TryGetValue(poolName, out var controller))
            return controller.GetObject();

        Debug.LogError($"No pool found with GameObject name '{poolName}'");
        return null;
    }

    public void ReturnObject(string poolName, GameObject obj)
    {
        if (poolDictionary.TryGetValue(poolName, out var controller))
            controller.ReturnObject(obj);
        else
            Debug.LogWarning($"Trying to return to unknown pool '{poolName}'");
            Destroy(obj);
    }
}
