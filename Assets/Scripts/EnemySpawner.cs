using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    List<GameObject> spawnedEnemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject.Instantiate(enemy, new Vector3(Player.Instance.transform.position.x, Player.Instance.transform.position.y + 10, Player.Instance.transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }

    }
}
