using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float speedX;
    [SerializeField] float speedY;


    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = new Vector3(speedX, speedY, 0);
        rb.AddForce(transform.up * speed);
        ToLimitSpeed();
    }
    void ToLimitSpeed()
    {
        var newSpeed = rb.velocity;
        newSpeed.y = Mathf.Clamp(newSpeed.y, -speed, speed);
        newSpeed.x = Mathf.Clamp(newSpeed.x, -speed, speed);
        rb.velocity = newSpeed;
    }
}
