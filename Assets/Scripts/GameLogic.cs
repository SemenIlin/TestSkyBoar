using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] int startQuantityAsteroids;
    [SerializeField] AsteroidPool asteroidPool;

    [SerializeField] float minDistancefromShip = 2f;
    [SerializeField] float maxDistancefromShip = 7f;

    Transform player;
    void Start()
    {
        player = FindObjectOfType<ShipMovement>().transform;
        OnInitAsteroids();
    }


    void OnInitAsteroids()
    {
        for (int i = 0; i < startQuantityAsteroids; ++i)
        {
            var asteroid = asteroidPool.BigAsteroidsPool.GetFreeElement();
            asteroid.transform.position = GeneratePosition(i);
        }
    }

    Vector3 GeneratePosition(int numberAsteroid)
    {
        numberAsteroid %= 4;

        var newPosition = Vector3.zero;
        switch (numberAsteroid){
            case 0:
                newPosition.x = Random.Range(player.position.x - minDistancefromShip, player.position.x - maxDistancefromShip);
                newPosition.y = Random.Range(player.position.y - minDistancefromShip, player.position.y - maxDistancefromShip);
                break;

            case 1:
                newPosition.x = Random.Range(player.position.x - minDistancefromShip, player.position.x - maxDistancefromShip);
                newPosition.y = Random.Range(player.position.y + minDistancefromShip, player.position.y + maxDistancefromShip);
                break;

            case 2:
                newPosition.x = Random.Range(player.position.x + minDistancefromShip, player.position.x + maxDistancefromShip);
                newPosition.y = Random.Range(player.position.y + minDistancefromShip, player.position.y + maxDistancefromShip);
                break;

            case 3:
                newPosition.x = Random.Range(player.position.x + minDistancefromShip, player.position.x + maxDistancefromShip);
                newPosition.y = Random.Range(player.position.y - minDistancefromShip, player.position.y - maxDistancefromShip);
                break;
        }

        return newPosition;
    }
}
