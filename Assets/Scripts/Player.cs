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

    float jumpForce = 2000;
    public int MaxAirTimeSeconds = 5;
    private float currentAirTime = 0;
    private bool canFly = true;


    // Bit shift the index of the layer (7) to get a bit mask
    int layerMask = 1 << 7;
    [SerializeField] GameOverManager gameOverManager;
    #endregion

    #region Properties
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

    #endregion

    #region Methods
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
        if (Input.GetButton("Jump") && canFly)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce*Time.deltaTime), ForceMode2D.Force);

        }
        transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
        Speed += (PlayerSpeedUpSpeed * Time.deltaTime);

        if (!Grounded)
        {
            currentAirTime += Time.deltaTime;
            if(currentAirTime < MaxAirTimeSeconds)
                Shield.Instance.SetSize((1 - (currentAirTime / MaxAirTimeSeconds)) * Shield.Instance.OriginalSize);

        }
        else
        {
            canFly = true;
            currentAirTime = 0;
            Shield.Instance.ResetSize();

        }
        if (currentAirTime >= MaxAirTimeSeconds)
            canFly = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player touched an enemy or a spike
        if(collision.gameObject.tag == "Spike" || collision.gameObject.tag == "Enemy")
        {
            //Show game over screen and destroy player
            Debug.Log("Game Over");
            gameOverManager.SetGameOver();
            Destroy(gameObject);        
        }
        
    }
    #endregion

}


