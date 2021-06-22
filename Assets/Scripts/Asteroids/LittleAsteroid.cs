using UnityEngine;

public class LittleAsteroid : Asteroid, IObstacle
{
    [SerializeField] float damage;
    public float ToDamage => damage;

    public void GetBihaviour()
    {
        Destroy(transform.gameObject);
    }
}
