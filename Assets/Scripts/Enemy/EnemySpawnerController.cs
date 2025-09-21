using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform leftPos, rightPos;

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

            spawned_monster = PoolManager.Instance.GetObject(enemies[randomindex].name);

            if (randomside == 1)
            {
                spawned_monster.transform.position = rightPos.position;
                spawned_monster.GetComponent<Enemy>().speed = -Random.Range(2, 5);
                spawned_monster.transform.localScale = new Vector3(-1, 1, 1);
                spawned_monster.SetActive(true);
            }
            else
            {
                spawned_monster.transform.position = leftPos.position;
                spawned_monster.GetComponent<Enemy>().speed = Random.Range(4, 10);
                spawned_monster.transform.localScale = new Vector3(1, 1, 1);
                spawned_monster.SetActive(true);
            }
        }
    }
}
