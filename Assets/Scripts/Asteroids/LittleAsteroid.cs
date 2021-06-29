using UnityEngine;

public class LittleAsteroid : Asteroid, IObstacle
{
    [SerializeField] float damage;
    public float ToDamage => damage;

    public void FullDestoy()
    {
        transform.gameObject.SetActive(false);
    }

    public void GetBihaviour()
    {
        transform.gameObject.SetActive(false);
    }    
}
