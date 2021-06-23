using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody rb;
    float widthScreen;
    float progressMove;
    public void SetDirection(Vector3 direction)
    {
        transform.localEulerAngles = direction;
    }

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();

        var startPoint = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        var endPoint = Camera.main.ViewportToWorldPoint(Vector3.one).x;
        widthScreen = endPoint - startPoint;
        Debug.Log("widthScreen " + widthScreen);          
    }

    void FixedUpdate()
    {
        //transform.Translate(transform.up * speed);
        rb.AddForce(transform.up * speed, ForceMode.Impulse);
        ToLimitSpeed();
        bulletMove(Time.fixedDeltaTime);
    }
    void ToLimitSpeed()
    {
        var newSpeed = rb.velocity;
        newSpeed.y = Mathf.Clamp(newSpeed.y, -speed, speed);
        newSpeed.x = Mathf.Clamp(newSpeed.x, -speed, speed);
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

    void bulletMove(float deltaTime)
    {
        var totalSpeed = Mathf.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y);
        progressMove += totalSpeed * deltaTime;
        if (widthScreen <= progressMove)
        {
            Destroy(transform.gameObject);
        }
    }
}
