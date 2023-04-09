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

    void Update()
    {
        distanceUI.text = "Time Survived: " + distance.ToString("F2");
        timer += Time.deltaTime;

        distance += Time.deltaTime;
    }
}