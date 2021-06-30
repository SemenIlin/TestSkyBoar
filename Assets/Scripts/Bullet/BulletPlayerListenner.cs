using UnityEngine;

public class BulletPlayerListenner : MonoBehaviour
{
    GameScreen gameScreen;
    private void Start()
    {
        gameScreen = FindObjectOfType<GameScreen>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UFO"))
        {
            var ufo = other.GetComponent<IObstacle>();
            ufo.GetBihaviour();
            UpdateScore(ufo.Reward);
        }

        if (other.CompareTag("Asteroid"))
        {
            var asteroid = other.GetComponent<IObstacle>();
            asteroid.GetBihaviour();
            gameObject.SetActive(false);

            var gameLogic = FindObjectOfType<GameLogic>();
            gameLogic.LoadNextLevel(other.GetComponent<Asteroid>().HasAsteroidsOnLocation());

            UpdateScore(asteroid.Reward);
        }
    }

    void UpdateScore(float reward)
    {
        var score = FindObjectOfType<Score>();
        score.AddPoints(reward);

        gameScreen.UpdateScoreText(score.Points);
    }

}
