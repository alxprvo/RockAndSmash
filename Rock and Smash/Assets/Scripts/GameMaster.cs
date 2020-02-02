using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    
    public GameObject[] borders;
    public GameObject goodBorder;
    [SerializeField] GameObject loosingCanvas;
    public float invokeRate = 1f;
    int totalScore;

    [SerializeField] Text scorevaltxt;

    private void Awake()
    {
        loosingCanvas.SetActive(false);
        scorevaltxt.text = "0";   
    }


    void Start()
    {
        InvokeRepeating("ChooseBorder", 1f, invokeRate);

    }

 
    void ChooseBorder()
    {
        int indexNumber = Random.Range(0, borders.Length);

        foreach (GameObject border in borders)
        {
            if (border == borders[indexNumber])
            {
                border.GetComponent<Image>().color = Color.red;

                goodBorder = border;

            } else
            {
                border.GetComponent<Image>().color = Color.white;
        
            }
        }
    }

    public void ScoringPoints (int score)
    {
        totalScore += score;

        scorevaltxt.text = totalScore.ToString();
    }

    public void GameOver()
    {
        loosingCanvas.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
