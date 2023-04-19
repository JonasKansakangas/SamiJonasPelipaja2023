using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    #region Members
    private Rigidbody2D _rigidbody;
    public static Player Instance;

    public float Speed = 1;
    public float PlayerSpeedUpSpeed = 1.0f;

    float jumpForce = 4;
    public int MaxAirTimeSeconds = 5;
    private float currentAirTime = 0;
    private bool canFly = true;


    // Bit shift the index of the layer (7) to get a bit mask
    int layerMask = 1 << 7;
    #endregion
    [SerializeField] GameOverManager gameOverManager;


    /// <summary>
    /// Returns true if player is touching ground
    /// </summary>
    bool Grounded
    {
        get
        {
            return Physics2D.Raycast(transform.position, Vector3.down, 1, layerMask).transform != null;
        }
    }
    
    public void Awake()
    {
        layerMask = ~layerMask;
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetButtonUp("Jump"))
         {
             if (Grounded)
             {
                 _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                 jumpForce = minJumpForce;
             }

         }

         if (Input.GetButton("Jump") && Grounded)
         {
             jumpForce += jumpForceMultiplier * Time.deltaTime;
             if (jumpForce >= maxJumpForce)
                 jumpForce = maxJumpForce;
         }
         else
         {
             jumpForce = minJumpForce;
         }*/

        if (Input.GetButton("Jump") && canFly)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);

        }
        transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
        Speed += (PlayerSpeedUpSpeed * Time.deltaTime);

        if (!Grounded)
            currentAirTime += Time.deltaTime;
        else
        {
            canFly = true;
            currentAirTime = 0;

        }

        if (currentAirTime >= MaxAirTimeSeconds)
            canFly = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spike" || collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Game Over");

            gameOverManager.SetGameOver();

            Destroy(gameObject);        }
        }    
}

    //private void OnBecameInvisible()
    //{
    //    GameOver();
    //}

    ///// <summary>
    ///// Game over logic here
    ///// </summary>
    //void GameOver()
    //{
    //    //Game over
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
