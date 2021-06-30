using UnityEngine;

public class LittleAsteroid : Asteroid, IObstacle
{
    [SerializeField] float reward;
    public float Reward => reward;

    public void FullDestoy()
    {
        transform.gameObject.SetActive(false);
    }

    public void GetBihaviour()
    {
        transform.gameObject.SetActive(false);
    }    
}
