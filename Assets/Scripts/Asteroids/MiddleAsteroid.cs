using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleAsteroid : Asteroid, IObstacle
{
    [SerializeField] GameObject litleAsteroidPrefab;
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

        Debug.Log(transform.localRotation.eulerAngles);

        Destroy(transform.gameObject);
    }

    void CreateAsteroid(float angle)
    {
        var littleAsteroid = Instantiate(litleAsteroidPrefab);
        
        var asteroidTransform = littleAsteroid.transform;
        asteroidTransform.position = transform.position;
        asteroidTransform.parent = null;

        var newAngles = transform.localEulerAngles;
        newAngles.z += angle;
        asteroidTransform.localEulerAngles = newAngles;
    }

    float GetAngle()
    {
        var angle = Mathf.Tan(direction.x / direction.y * 180 / Mathf.PI);
        Debug.Log(angle);
        return 0;
    }
}
