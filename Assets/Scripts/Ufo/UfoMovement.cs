using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoMovement : MonoBehaviour
{
    [SerializeField] float timeOfMovement;

    int direction;
    float speedMovement;
    Vector3 movementDirectoion;
    void Start()
    {
        if (timeOfMovement > 0) 
        {
            speedMovement = Screen.WidthScreen / timeOfMovement;
        }
        SetDirection();
    }

    void FixedUpdate()
    {
        transform.Translate(movementDirectoion * Time.fixedDeltaTime * speedMovement);
    }

    

    void SetDirection()
    {
        direction = Random.Range(-1, 1);
        if (direction == 0)
        {
            direction = 1;
        }


        switch (direction)
        {
            case -1:
                movementDirectoion = -transform.right;
                break;
            case 1:
                movementDirectoion = transform.right;
                break;
        }
    }
}
