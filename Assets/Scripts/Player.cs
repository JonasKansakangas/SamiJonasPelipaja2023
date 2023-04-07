using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private Rigidbody2D _rigidbody;

    public static Player Instance;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
       // _rigidbody.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0.05f, 0, 0));
       // _rigidbody.MovePosition(transform.position + (new Vector3(1, 0, 0)*Time.deltaTime));
       //_rigidbody.velocity = new Vector2(
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spike")
        {
            //Game over
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
