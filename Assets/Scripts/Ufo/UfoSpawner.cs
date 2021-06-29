using UnityEngine;

public class UfoSpawner : MonoBehaviour
{
    [SerializeField] GameObject ufoPrefab;
    [SerializeField, Range(5, 10)] float timeForSpawn = 8f;

    int direction;
    Vector3 movementDirectoion;
    float timer = 0;
    void Start()
    {
        SetDirection();
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer >= timeForSpawn)
        {
            timer = 0;
            SetDirection();
            CreateUfo();
        }        
    }
    public Vector3 MovementDirection => movementDirectoion;

    public float Direction => direction;
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

    void CreateUfo()
    {
        var ufo = Instantiate(ufoPrefab, transform);
        var ufoPosition = ufo.transform.position;
        var newPosition = ufoPosition;
        if (direction == 1)
        {
            newPosition.x = Camera.main.ViewportToWorldPoint(new Vector3(0, ufoPosition.y, ufoPosition.z)).x;
        }
        else if (direction == -1)
        {
            newPosition.x = Camera.main.ViewportToWorldPoint(new Vector3(1, ufoPosition.y, ufoPosition.z)).x;
        }

        ufo.transform.position = newPosition;
    }
}
