using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float smashingSpeed = 10f;


    bool mfActive = true;

    GameObject movingSpace;
    Rigidbody2D rBody;

    

    void Start()
    {
        movingSpace = GameObject.FindGameObjectWithTag("movingSpace");

        rBody = gameObject.GetComponent<Rigidbody2D>();
        //Debug.Log("Height: " + movingSpace.GetComponent<RectTransform>().sizeDelta.y + " Width: " + movingSpace.GetComponent<RectTransform>().sizeDelta.x);
    }

    void Update()
    {
        

        if (mfActive)
        {
            FollowCursor();
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            mfActive = false;

            Smash();
        }
    }

    void FollowCursor () {

        float movingSpaceHeight = movingSpace.GetComponent<RectTransform>().sizeDelta.y;
        float movingSpaceWidth = movingSpace.GetComponent<RectTransform>().sizeDelta.x;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 mouseFollow = Vector2.Lerp(transform.position, mousePosition, 10f);

        //float clampX = Mathf.Clamp(mouseFollow.x, movingSpaceWidth / 2 * -1, movingSpaceWidth / 2);
        //float clampY = Mathf.Clamp(mouseFollow.y, movingSpaceHeight / 2 * -1, movingSpaceHeight / 2);

        float clampX = Mathf.Clamp(mouseFollow.x, -6.8f, 6.8f);
        float clampY = Mathf.Clamp(mouseFollow.y, -2.9f, 2.9f);

        transform.position = new Vector3(clampX, clampY);
     
    }

    void Smash()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rBody.velocity = Vector2.up * smashingSpeed;

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            rBody.velocity = Vector2.left * smashingSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            rBody.velocity = Vector2.down * smashingSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rBody.velocity = Vector2.right * smashingSpeed;
        }

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "Border")
        {
            mfActive = true;
        }
    }
}
