using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Members
    public GameObject enemy;
    #endregion;

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    /// <summary>
    /// Spawn a new enemy every 5 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject.Instantiate(enemy, new Vector3(Player.Instance.transform.position.x, Player.Instance.transform.position.y + 10, Player.Instance.transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }

    }
    #endregion
}
