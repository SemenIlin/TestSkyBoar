using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Range(0.01f, 0.1f)] public float speed = 0.05f;
    [SerializeField, Range(0.01f, 1)] float offsetY = 0.2f;
    [SerializeField, Range(0.01f, 1)] float offsetX = 0.2f;

    protected AsteroidPool pool;

    protected Vector3 direction;
         
    Camera mainCamera;
    private void OnEnable()
    {
        if (pool == null)
        {
            pool = transform.parent.GetComponent<AsteroidPool>();
        }

        direction = new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), 0);
    }
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        transform.Translate(direction.normalized * speed);
        MoveInScreenLocation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("UFO"))
        {
            other.GetComponent<IObstacle>().GetBihaviour();
            FullDestoy();
            var gameLogic = FindObjectOfType<GameLogic>();
            gameLogic.LoadNextLevel(HasAsteroidsOnLocation());

            return;
        }

        if (other.CompareTag("Player"))
        {
            var flashing = other.GetComponent<Flashing>();
            flashing.DisableCollider();
            flashing.ResetTimers();

            FullDestoy();
            var gameLogic = FindObjectOfType<GameLogic>();
            gameLogic.LoadNextLevel(HasAsteroidsOnLocation());

            FindObjectOfType<GameLogic>().RestartPlayer(other);
        }
    }

    void FullDestoy()
    {
        transform.gameObject.SetActive(false);
    }

    public bool HasAsteroidsOnLocation()
    {
        if (!pool.BigAsteroidsPool.HasActiveElement() &&
            !pool.MiddleAsteroidsPool.HasActiveElement() &&
            !pool.LittleAsteroidsPool.HasActiveElement())
        {
            return false;
        }

        return true;
    }

    void MoveInScreenLocation()
    {
        var newPosition = transform.position;

        var point = mainCamera.WorldToViewportPoint(transform.position); //Записываем положение объекта к границам камеры, X и Y это будут как раз верхние и нижние границы камеры

        if (point.y < 0f - offsetY)
        {
            newPosition.y = mainCamera.ViewportToWorldPoint(new Vector3(point.x, 1, point.z)).y;
            transform.position = newPosition;
        }
        else if (point.y > 1 + offsetY)
        {
            newPosition.y = mainCamera.ViewportToWorldPoint(new Vector3(point.x, 0, point.z)).y;
            transform.position = newPosition;
        }
        else if (point.x > 1f + offsetX)
        {
            newPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(0, point.y, point.z)).x;
            transform.position = newPosition;
        }
        if (point.x < 0f - offsetX)
        {
            newPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(1, point.y, point.z)).x;
            transform.position = newPosition;
        }
    }

    public void SetDirection(Vector3 direction, float deltaAngle)
    {
        this.direction = direction;
        var angle = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        var gipotenusa = 0.0f;
        angle += deltaAngle;

        if (angle > 90)
        {
            angle = 180 - angle;
            gipotenusa = this.direction.x / Mathf.Cos(angle * Mathf.PI / 180);
            this.direction.x *= -1;
        }

        else if (angle < 0)
        {
            gipotenusa = this.direction.x / Mathf.Cos(angle * Mathf.PI / 180);

            this.direction.y = Mathf.Sqrt(gipotenusa * gipotenusa - this.direction.x * this.direction.x);
            this.direction.y *= -1;
        }

        else
        {
            gipotenusa = this.direction.x / Mathf.Cos(angle * Mathf.PI / 180);
            this.direction.y = Mathf.Sqrt(gipotenusa * gipotenusa - this.direction.x * this.direction.x);
        }
    }
}
