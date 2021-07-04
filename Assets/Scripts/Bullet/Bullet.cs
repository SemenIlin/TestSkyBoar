using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody rb;

    Vector3 currentPosition;
    Vector3 previousPosition;
    float progress = 0f;

    private void OnEnable()
    {
        progress = 0;
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }
    public void Short(Quaternion direction, Vector3 shootPoint)
    {
        OnInit(shootPoint);
        transform.localRotation = direction;        

        rb.AddForce(transform.up * speed, ForceMode.Impulse);
    }

    public void Short(Vector3 direction, Vector3 shootPoint)
    {
        OnInit(shootPoint);
        transform.localEulerAngles = direction;

        rb.AddForce(transform.up * speed, ForceMode.Impulse);
    }

    void OnInit(Vector3 shootPoint)
    {
        transform.position = shootPoint;
        currentPosition = previousPosition = transform.position;
    }

    void FixedUpdate()
    {
        DestroyBullet();
    }    

    float CalculateDistanceFlyBullet()
    {        
        currentPosition = transform.position;
        var step = Vector3.Distance(currentPosition, previousPosition);
        Debug.Log(step);
        if (step < 0.8f) 
        { 
            progress += step;
        }
        previousPosition = currentPosition;

        return progress;
    }

    void DestroyBullet()
    {
        if (CalculateDistanceFlyBullet() >= Screen.WidthScreen)
        {
            gameObject.SetActive(false);
        }
    }
}
