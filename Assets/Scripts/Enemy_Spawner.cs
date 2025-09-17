using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private Transform leftpos, rightpos;

    private GameObject spawned_monster;

    private int randomindex, randomside;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomindex = Random.Range(0, enemies.Length);
            randomside = Random.Range(0, 2);

            spawned_monster = Instantiate(enemies[randomindex]);

            if (randomside == 0)
            {
                spawned_monster.transform.position = leftpos.position;
                spawned_monster.GetComponent<Enemy>().speed = Random.Range(4, 10);
            }
            else
            {
                spawned_monster.transform.position = rightpos.position;
                spawned_monster.GetComponent<Enemy>().speed = -Random.Range(2, 5);
                spawned_monster.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

}
