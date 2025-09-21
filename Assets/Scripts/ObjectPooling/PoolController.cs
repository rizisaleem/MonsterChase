using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 8;

    [SerializeField] private Transform availableContainer;
    [SerializeField] private Transform usedContainer;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    void Start()
    {
        FillPool();
    }

    void FillPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.name = prefab.name;
            obj.SetActive(false);
            obj.transform.SetParent(availableContainer);

            PooledObject pooled = obj.GetComponent<PooledObject>();
            if (pooled != null)
                pooled.SetPool(this);

            availableObjects.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        GameObject obj;

        if (availableObjects.Count > 0)
            obj = availableObjects.Dequeue();
        else
        {
            obj = Instantiate(prefab);
            obj.name = prefab.name;
            PooledObject pooled = obj.GetComponent<PooledObject>();
            if (pooled != null)
                pooled.SetPool(this);
        }

        obj.transform.SetParent(usedContainer);
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(availableContainer);
        availableObjects.Enqueue(obj);
    }
}
