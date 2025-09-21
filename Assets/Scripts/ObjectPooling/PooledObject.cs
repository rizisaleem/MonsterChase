using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private PoolController pool;
    private string poolName;

    public void SetPool(PoolController poolRef)
    {
        pool = poolRef;
        poolName = poolRef.gameObject.name;
    }

    public void ReturnToPool()
    {
        if (pool != null)
            pool.ReturnObject(this.gameObject);
        else if (!string.IsNullOrEmpty(poolName))
            PoolManager.Instance?.ReturnObject(poolName, this.gameObject);
        else
            Destroy(this.gameObject);
    }
}
