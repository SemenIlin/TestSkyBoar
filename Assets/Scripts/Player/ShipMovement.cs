using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{
    [Header("Ship characteristics")]
    [SerializeField] float maxSpeed;
    [SerializeField] float maxRotateSpeed;
    [SerializeField] float acceleration;

    [SerializeField, Range(0.05f, 1f)] float stepForStop = 0.3f;

    float horizontalRotate;
    float verticalMove;

    Rigidbody rb;
    bool isStopMove;
    Vector3 direction;

    public Vector3 Direction => direction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = Vector3.zero;
    }

    void Update()
    {
        horizontalRotate = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        MoveShip(verticalMove);
        ChangeRotate(horizontalRotate);
    }

    void FixedUpdate()
    {
        ToLimitSpeed();
        ChangeSpeed();
    }

    void ToLimitSpeed()
    {
        var newSpeed = rb.velocity;
        newSpeed.y = Mathf.Clamp(newSpeed.y, -maxSpeed, maxSpeed);
        newSpeed.x = Mathf.Clamp(newSpeed.x, -maxSpeed, maxSpeed);
        rb.velocity = newSpeed;       
    }

    void MoveShip(float verticalMove)
    {  
        if (verticalMove == 0)
        {
            isStopMove = true;
        }
        else
        {
            isStopMove = false;
        }


        if (verticalMove > 0)
        {
            direction = transform.up;
        }

        rb.AddForce(direction * acceleration);
    }

    void ChangeSpeed()
    {
        var newSpeed = rb.velocity;
        if (isStopMove)
        {
            if (newSpeed.y > 0) 
            {
                newSpeed.y -= stepForStop;
                newSpeed.y = Mathf.Clamp(newSpeed.y, 0, maxSpeed);
            }
            else if (newSpeed.y < 0)
            {
                newSpeed.y += stepForStop;
                newSpeed.y = Mathf.Clamp(newSpeed.y,-maxSpeed, 0);
            }

            if (newSpeed.x > 0)
            {
                newSpeed.x -= stepForStop;
                newSpeed.x = Mathf.Clamp(newSpeed.x, 0, maxSpeed);
            }
            else if (newSpeed.x < 0)
            {
                newSpeed.x += stepForStop;
                newSpeed.x = Mathf.Clamp(newSpeed.x, -maxSpeed, 0);
            }

            if(Vector3.Distance(Vector3.zero, newSpeed) < 0.001f)
            {
                direction = Vector3.zero;
            }
        }

        rb.velocity = newSpeed;
    }

    void ChangeRotate(float horizontalRotate)
    {
        var newRotate = transform.localEulerAngles;
        if(horizontalRotate < 0)
        {
            newRotate.z += maxRotateSpeed;
        }
        else if (horizontalRotate > 0)
        {
            newRotate.z -= maxRotateSpeed;
        }

        transform.localEulerAngles = newRotate;
    }
}
