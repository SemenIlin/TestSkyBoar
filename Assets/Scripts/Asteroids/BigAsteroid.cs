using UnityEngine;

public class BigAsteroid : Asteroid, IObstacle
{
    [SerializeField] GameObject middleAsteroidPrefab;
    [SerializeField] float damage;

    [SerializeField] float[] anglesForAsteroids;
    public float ToDamage => damage;

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
        var middleAsteroid = Instantiate(middleAsteroidPrefab);

        var asteroidTransform = middleAsteroid.transform;

        middleAsteroid.GetComponent<MiddleAsteroid>().SetDirection(direction, angle);

        asteroidTransform.position = transform.position;
        asteroidTransform.parent = null;
    }
}
