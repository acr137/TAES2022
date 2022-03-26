using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{   
    public float timer = 0;
    public TextMeshProUGUI textTimer;

    void Update()
    {
        timer += Time.deltaTime;
        textTimer.text = "" + timer.ToString("f1");
    }
}
