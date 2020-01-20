using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject movingSpace;

    void Start()
    {
        movingSpace = GameObject.FindGameObjectWithTag("movingSpace");

        //Debug.Log("Height: " + movingSpace.GetComponent<RectTransform>().sizeDelta.y + " Width: " + movingSpace.GetComponent<RectTransform>().sizeDelta.x);
    }

    void Update()
    {
        FollowCursor();
    }

    void FollowCursor () {

        float movingSpaceHeight = movingSpace.GetComponent<RectTransform>().sizeDelta.y;
        float movingSpaceWidth = movingSpace.GetComponent<RectTransform>().sizeDelta.x;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 mouseFollow = Vector2.Lerp(transform.position, mousePosition, 10000000f);

        //float clampX = Mathf.Clamp(mouseFollow.x, movingSpaceWidth / 2 * -1, movingSpaceWidth / 2);
        //float clampY = Mathf.Clamp(mouseFollow.y, movingSpaceHeight / 2 * -1, movingSpaceHeight / 2);

        float clampX = Mathf.Clamp(mouseFollow.x, -6.8f, 6.8f);
        float clampY = Mathf.Clamp(mouseFollow.y, -2.9f, 2.9f);

        transform.position = new Vector3(clampX, clampY);
     
    }
}
