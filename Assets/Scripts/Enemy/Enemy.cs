using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public float speed;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.velocity = new Vector2(speed, body.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collector"))
        {
            PooledObject pooled = GetComponent<PooledObject>();
            if (pooled != null)
                pooled.ReturnToPool();
            else
                PoolManager.Instance.ReturnObject(gameObject.name, gameObject);
        }
    }
}
