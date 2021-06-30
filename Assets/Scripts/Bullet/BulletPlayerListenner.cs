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
            Destroy(other.gameObject);
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
