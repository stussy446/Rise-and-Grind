using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{

    public float moveSpeed;
    public GameObject character;

    Rigidbody2D characterRigidBody;
    float screenWidth;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        characterRigidBody = character.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.touchCount);
        int i = 0;
        while(i < Input.touchCount)
        {
            Debug.Log(Input.GetTouch(i).position.x);
            if (Input.GetTouch(i).position.x > screenWidth / 2)
            {
                RunCharacter(1.0f);
            }

            if (Input.GetTouch(i).position.x < screenWidth / 2)
            {
                RunCharacter(-1.0f);
            }
            ++i;
        }
    }

    //void FixedUpdate()
    //{
    //    #if UNITY_EDITOR
    //    RunCharacter(Input.GetAxis("Horizontal"));
    //    #endif
    //}


    void RunCharacter(float horizontalInput)
    {
        characterRigidBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));
    }
}
