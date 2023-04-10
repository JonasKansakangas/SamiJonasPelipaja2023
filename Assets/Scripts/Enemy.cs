using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Members
    public float Speed = 1000;
    public GameObject EnemyExplosion;
    #endregion

    // Update is called once per frame
    void Update()
    {
        //Move towards the player
        if(Player.Instance != null)
        transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, Speed * Time.deltaTime);

    }

    /// <summary>
    /// Kill the enemiy and spawn an explosion
    /// </summary>
    public void Die()
    {
        GameObject.Destroy(GameObject.Instantiate(EnemyExplosion, transform.position, Quaternion.identity), 5);
        Destroy(this.gameObject);
    }
}
