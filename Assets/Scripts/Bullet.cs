using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody rb;

    float widthScreen;
    float progressMove;

    Vector3 currentPosition;
    Vector3 previousPosition;
    float progress = 0f;
    public void Short(Quaternion direction)
    {
        transform.localRotation = direction;
        OnInit();
    }

    void OnInit()
    {
        currentPosition = previousPosition = transform.position;

        rb = GetComponent<Rigidbody>();

        var startPoint = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        var endPoint = Camera.main.ViewportToWorldPoint(Vector3.one).x;
        widthScreen = endPoint - startPoint;          
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.up * speed, ForceMode.Impulse);
        ToLimitSpeed();
        DestroyBullet();
    }
    void ToLimitSpeed()
    {
        var newSpeed = rb.velocity;
        var koeff = 0.0f;

        if (Mathf.Abs(rb.velocity.x) >= Mathf.Abs(rb.velocity.y))
        {
            if (rb.velocity.y != 0.0f)
            {
                koeff = rb.velocity.x / rb.velocity.y;
            }

            newSpeed.x = Mathf.Clamp(newSpeed.x, -speed, speed);
            if (koeff != 0)
            {
                newSpeed.y = newSpeed.x / koeff;
            }
            else
            {
                newSpeed.y = Mathf.Clamp(newSpeed.y, -speed, speed);
            }
        }

        else
        {
            if (rb.velocity.x != 0.0f)
            {
                koeff = rb.velocity.y / rb.velocity.x;
            }

            newSpeed.y = Mathf.Clamp(newSpeed.y, -speed, speed);
            if (koeff != 0)
            {
                newSpeed.x = newSpeed.y / koeff;
            }
            else
            {
                newSpeed.x = Mathf.Clamp(newSpeed.x, -speed, speed);
            }
        }

        rb.velocity = newSpeed; 
    }    



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }

        //if (other.CompareTag("Enemy"))
        //{
        //    return;
        //}

        var asteroid = other.GetComponent<IObstacle>();
        asteroid?.GetBihaviour();
    }

    float CalculateDistanceFlyBullet()
    {        
        currentPosition = transform.position;
        var deltaMove = currentPosition - previousPosition;
        var step = Vector3.Magnitude(deltaMove);

        if (step < 0.8f) 
        { 
            progress += step;
        }
        previousPosition = currentPosition;

        return progress;
    }

    void DestroyBullet()
    {
        if (CalculateDistanceFlyBullet() >= widthScreen)
        {
            Destroy(gameObject);
        }
    }
}
