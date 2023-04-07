using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Properties
    public float Speed = 1000;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move towards the player
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, Speed * Time.deltaTime);

    }
}
