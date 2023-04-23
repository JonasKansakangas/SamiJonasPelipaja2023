using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDistance : MonoBehaviour
{
    #region Members
    public float timer;
    public TextMeshProUGUI distanceUI;
    private float distance;
    #endregion

    #region Methods
    void Update()
    {
        distanceUI.text = "SCORE: " + distance.ToString("F2");
        timer += Time.deltaTime;

        distance += Time.deltaTime;
    }
    #endregion
}
