using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPowerup : MonoBehaviour
{
    private float duration = 3f;
    private float timer=0f;
    private string text;
    public Text textBox;

    private void Start()
    {
        textBox.enabled = false;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            textBox.enabled = false;
        } 
    }

    public void popup(string desc)
    {
        textBox.text = desc;
        textBox.enabled = true;
        timer = duration;
    }
}
