using System;
using System.Collections;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] GameScreen gameScreen;
    [SerializeField] Score score;

    [SerializeField] int startQuantityAsteroids;
    [SerializeField] AsteroidPool asteroidPool;
    [SerializeField] float timeBetweenLoadLevel = 2f;

    [SerializeField] float minDistancefromShip = 2f;
    [SerializeField] float maxDistancefromShip = 7f;


    Transform player;
    void Start()
    {        
        gameScreen.UpdateScoreText(0);
        gameScreen.UpdateQuantityLifeText(score.QuantityLifes);


        player = FindObjectOfType<ShipMovement>().transform;
        OnInitAsteroids();
    }

    public void RestartPlayer(Collider other)
    {     
        score.DecreaseQuantityLifes();
        if (score.QuantityLifes == 0)
        {
            other.gameObject.SetActive(false);
        }

        gameScreen.UpdateQuantityLifeText(score.QuantityLifes);
    }
    public void LoadNextLevel(bool hasObstacles)
    {
        if (!hasObstacles)
        {
            StartCoroutine(GetNextLevel());
        }
    }


    void OnInitAsteroids()
    {
        for (int i = 0; i < startQuantityAsteroids; ++i)
        {
            var asteroid = asteroidPool.BigAsteroidsPool.GetFreeElement();
            asteroid.transform.position = GeneratePosition(i);
        }
    }


    IEnumerator GetNextLevel()
    {
        yield return new WaitForSeconds(timeBetweenLoadLevel);

        ++startQuantityAsteroids;
        OnInitAsteroids();
    }
    Vector3 GeneratePosition(int numberAsteroid)
    {
        numberAsteroid %= 4;

        var newPosition = Vector3.zero;
        switch (numberAsteroid){
            case 0:
                newPosition.x = UnityEngine.Random.Range(player.position.x - minDistancefromShip, player.position.x - maxDistancefromShip);
                newPosition.y = UnityEngine.Random.Range(player.position.y - minDistancefromShip, player.position.y - maxDistancefromShip);
                break;

            case 1:
                newPosition.x = UnityEngine.Random.Range(player.position.x - minDistancefromShip, player.position.x - maxDistancefromShip);
                newPosition.y = UnityEngine.Random.Range(player.position.y + minDistancefromShip, player.position.y + maxDistancefromShip);
                break;

            case 2:
                newPosition.x = UnityEngine.Random.Range(player.position.x + minDistancefromShip, player.position.x + maxDistancefromShip);
                newPosition.y = UnityEngine.Random.Range(player.position.y + minDistancefromShip, player.position.y + maxDistancefromShip);
                break;

            case 3:
                newPosition.x = UnityEngine.Random.Range(player.position.x + minDistancefromShip, player.position.x + maxDistancefromShip);
                newPosition.y = UnityEngine.Random.Range(player.position.y - minDistancefromShip, player.position.y - maxDistancefromShip);
                break;
        }

        return newPosition;
    }
}
