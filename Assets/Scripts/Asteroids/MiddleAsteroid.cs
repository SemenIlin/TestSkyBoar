using UnityEngine;

public class MiddleAsteroid : Asteroid, IObstacle
{
    [SerializeField] GameObject littleAsteroidPrefab;
    [SerializeField] float reward;

    [SerializeField] float[] anglesForAsteroids;
    public float Reward => reward;

    public void FullDestoy()
    {
        transform.gameObject.SetActive(false);
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

        transform.gameObject.SetActive(false);
    }

    void CreateAsteroid(float angle)
    {
        //var littleAsteroid = Instantiate(littleAsteroidPrefab);
        var littleAsteroid = pool.LittleAsteroidsPool.GetFreeElement();
        var asteroidTransform = littleAsteroid.transform;

        littleAsteroid.GetComponent<LittleAsteroid>().SetDirection(direction, angle);

        asteroidTransform.position = transform.position;
        //asteroidTransform.parent = null;
    }
}