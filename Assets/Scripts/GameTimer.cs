using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timeText;

    private float elapsedTime = 0f;

    void Update()
    {
        if (Game_Manager.instance.gameOver) return;
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        timeText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    //so it can be retrieved for scoring system
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
