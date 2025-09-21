using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private Vector3 pos;

    [SerializeField] private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
            return;

        pos = transform.position;
        pos.x = player.position.x;

        transform.position = pos;

        if (pos.x < minX)
            pos.x = minX;
        else if (pos.x > maxX)
            pos.x = maxX;

        transform.position = pos;
    }
}
