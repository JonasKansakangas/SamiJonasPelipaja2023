using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shield : MonoBehaviour
{

    #region Members
    public float OriginalSize;
    public static Shield Instance;
    #endregion

    #region Methods
    public void Awake()
    {
        Instance = this;
        OriginalSize = this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos = Input.mousePosition - mousePos;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    /// <summary>
    /// When the shield touches something
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            (collision.GetComponent<Enemy>()).Die();

        }
    }

    /// <summary>
    /// Sets the size of the shield
    /// </summary>
    /// <param name="size">Size to set</param>
    public void SetSize(float size)
    {
        transform.localScale = new Vector3(size, transform.localScale.y, transform.localScale.z);

    }

    /// <summary>
    /// Resets the size of the shield to its original size
    /// </summary>
    public void ResetSize()
    {
        transform.localScale = new Vector3(OriginalSize, transform.localScale.y, transform.localScale.z);
    }

    /// <summary>
    /// Gets the current size of the shield
    /// </summary>
    /// <returns></returns>
    public float GetSize()
    {
        return transform.localScale.x;
    }
    #endregion
}
