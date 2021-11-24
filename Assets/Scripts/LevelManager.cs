using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static float score;

    public Text timeText;
    public float time;


    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "Tme: \n" + Mathf.Round(time).ToString();
    }
}
