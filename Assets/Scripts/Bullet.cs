using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    Vector3 direction;
    void Start()
    {
        direction = Vector3.zero;   
    }

    void Update()
    {
        transform.Translate(direction.normalized * speed);
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction; 
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
