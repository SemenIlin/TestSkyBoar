using UnityEngine;

public class BulletPlayerListenner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }

        if (other.CompareTag("UFO"))
        {
            other.GetComponent<IObstacle>().GetBihaviour();
        }

        if (other.CompareTag("Asteroid"))
        {
            var asteroid = other.GetComponent<IObstacle>();
            asteroid.GetBihaviour();
            gameObject.SetActive(false);

            var gameLogic = FindObjectOfType<GameLogic>();
            gameLogic.LoadNextLevel(other.GetComponent<Asteroid>().HasAsteroidsOnLocation());            
        }
    }
}
