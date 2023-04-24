using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    #region Members
    public float cameraVelocity = 1.0f;
    public GameObject player;
    public bool followPlayer = true;
    #endregion


    #region Methods
    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        //Whether camera should follow player (obsolete)
        if (followPlayer)
        {
            transform.position = player.transform.position + new Vector3(0, 2.95f, -5);
            transform.position = new Vector3(player.transform.position.x, 2.95f, -5);

        }
        else
        {
            transform.position = transform.position + (new Vector3(cameraVelocity * Time.deltaTime, 0,0));
        }
        cameraVelocity += (Player.Instance.PlayerSpeedUpSpeed * Time.deltaTime);
    }
    #endregion
}
