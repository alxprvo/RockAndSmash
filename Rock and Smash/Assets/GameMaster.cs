using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    public GameObject[] borders;
    public float invokeRate = 1f;

    void Start()
    {
        InvokeRepeating("ChooseBorder", 1f, invokeRate);

    }

 
    void ChooseBorder()
    {
        int indexNumber = Random.Range(0, borders.Length);

        foreach (GameObject border in borders)
        {
            if (border.name == borders[indexNumber].name)
            {
                border.GetComponent<Image>().color = Color.green;
            } else
            {
                border.GetComponent<Image>().color = Color.red;

            }
        }
    }
}
