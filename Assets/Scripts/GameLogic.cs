using System.Collections;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] MenuScreen menuScreen;
    [SerializeField] UfoSpawner ufoSpawner;

    [SerializeField] int startQuantityAsteroids;
    [SerializeField] AsteroidPool asteroidPool;
    [SerializeField] BulletPool bulletPool;
    [SerializeField] float timeBetweenLoadLevel = 2f;

    [SerializeField] float minDistancefromShip = 2f;
    [SerializeField] float maxDistancefromShip = 7f;

    int quantityAsteroids;
    Transform player;
    Vector3 startPosition;

    
    void Start()
    {
        quantityAsteroids = startQuantityAsteroids;

        menuScreen.GenerateAsteroidEvent += OnInitAsteroids;
        menuScreen.ClearScreenEvent += ClearScreen;
        player = FindObjectOfType<ShipMovement>().transform;
        startPosition = player.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuScreen.Pause();
        }        
    }
    public void RestartPlayer()
    {
        menuScreen.Score.DecreaseQuantityLifes();
        if (menuScreen.Score.QuantityLifes == 0)
        {
            GameSettings.Instance.SetIsGameOver(true);
            menuScreen.Restart();
            ClearScreen();
        }

        menuScreen.GameScreen.UpdateQuantityLifeText(menuScreen.Score.QuantityLifes);
    }

    void ClearScreen()
    {
        asteroidPool.BigAsteroidsPool.SetAllDisactive();
        asteroidPool.MiddleAsteroidsPool.SetAllDisactive();
        asteroidPool.LittleAsteroidsPool.SetAllDisactive();

        bulletPool.UFOBulletPool.SetAllDisactive();
        bulletPool.PlayerBulletPool.SetAllDisactive();

        ufoSpawner.ResetTimer();

        var ufo = FindObjectOfType<UfoMovement>();
        if(ufo != null)
        {
            Destroy(ufo.gameObject);
        }

        startQuantityAsteroids = quantityAsteroids;
        player.position = startPosition;
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
