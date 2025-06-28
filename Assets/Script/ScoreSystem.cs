using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
public class ScoreSystem : MonoBehaviour
{

    [SerializeField] TMP_Text ScoreText;
    private float score;
    private float scoreMultiplier=1;
    public bool shouldCount=true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shouldCount = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldCount)
        {
            score += Time.deltaTime * scoreMultiplier;

            ScoreText.text = "score :" + (int)score;

        }
      
    }


    public int EndTimer()
    {
        shouldCount = false;

        ScoreText.text = string.Empty;
        return (int)score;

    }

    public  void StartTimer()
    {
        shouldCount=true;
    }
}
