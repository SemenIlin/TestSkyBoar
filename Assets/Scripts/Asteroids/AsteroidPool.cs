using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    [Header("Little asteroid")]
    [SerializeField] int quantityLittleAsteroids = 80;
    [SerializeField] bool autoExpandLittle = true;
    [SerializeField] LittleAsteroid littleAsteroidPrefab;

    [Header("Middle asteroid")]
    [SerializeField] int quantityMiddleAsteroids = 40;
    [SerializeField] bool autoExpandMiddle = true;
    [SerializeField] MiddleAsteroid middleAsteroidPrefab;

    [Header("Big asteroid")]
    [SerializeField] int quantityBigAsteroids = 20;
    [SerializeField] bool autoExpandBig = true;
    [SerializeField] BigAsteroid bigAsteroidPrefab;

    PoolMono<LittleAsteroid> littleAsteroidsPool;
    PoolMono<MiddleAsteroid> middleAsteroidsPool;
    PoolMono<BigAsteroid> bigAsteroidsPool;

    private void Awake()
    {
        littleAsteroidsPool = new PoolMono<LittleAsteroid>(littleAsteroidPrefab, quantityLittleAsteroids, transform);
        middleAsteroidsPool = new PoolMono<MiddleAsteroid>(middleAsteroidPrefab, quantityMiddleAsteroids, transform);
        bigAsteroidsPool = new PoolMono<BigAsteroid>(bigAsteroidPrefab, quantityBigAsteroids, transform);

        littleAsteroidsPool.autoExpand = autoExpandLittle;
        middleAsteroidsPool.autoExpand = autoExpandMiddle;
        bigAsteroidsPool.autoExpand = autoExpandBig;
    }

    public PoolMono<LittleAsteroid> LittleAsteroidsPool => littleAsteroidsPool;
    public PoolMono<MiddleAsteroid> MiddleAsteroidsPool => middleAsteroidsPool;
    public PoolMono<BigAsteroid> BigAsteroidsPool => bigAsteroidsPool;
}
