using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{

    public float cameraVelocity = 1.0f;
    public GameObject player;
   // public 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0,2.95f, -5);
        transform.position = new Vector3(player.transform.position.x, 2.95f, -5); // player.transform.position + new Vector3(0, 2.95f, -5);

        //transform.position = new Vector3(transform.position.x+(cameraVelocity*Time.deltaTime), transform.position.y, transform.position.z);

    }
}
