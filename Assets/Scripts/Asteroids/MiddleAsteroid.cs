using UnityEngine;

public class MiddleAsteroid : Asteroid, IObstacle
{
    [SerializeField] GameObject littleAsteroidPrefab;
    [SerializeField] float damage;

    [SerializeField] float[] anglesForAsteroids;
    public float ToDamage => damage;

    public void FullDestoy()
    {
        Destroy(transform.gameObject);
    }

    public void GetBihaviour()
    {
        if (anglesForAsteroids == null)
        {
            return;
        }
        for (var i = 0; i < anglesForAsteroids.Length; ++i)
        {
            CreateAsteroid(anglesForAsteroids[i]);
        }

        Destroy(transform.gameObject);
    }

    void CreateAsteroid(float angle)
    {
        var littleAsteroid = Instantiate(littleAsteroidPrefab);


        var asteroidTransform = littleAsteroid.transform;

        littleAsteroid.GetComponent<LittleAsteroid>().SetDirection(direction, angle);

        asteroidTransform.position = transform.position;
        asteroidTransform.parent = null;
    }
}