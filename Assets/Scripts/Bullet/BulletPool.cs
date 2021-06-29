using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [Header("Player bullet")]
    [SerializeField] int quantityPlayerBullet = 40;
    [SerializeField] bool autoExpandPlaererBullet = true;
    [SerializeField] Bullet playerBulletPrefab;

    [Header("UFO bullet")]
    [SerializeField] int quantityUFOBullet = 10;
    [SerializeField] bool autoExpandUFOBullet = true;
    [SerializeField] Bullet UFOBulletPrefab;


    PoolMono<Bullet> playerBulletPool;
    PoolMono<Bullet> uFOBulletPool;
    void Awake()
    {
        playerBulletPool = new PoolMono<Bullet>(playerBulletPrefab, quantityPlayerBullet, transform);
        uFOBulletPool = new PoolMono<Bullet>(UFOBulletPrefab, quantityUFOBullet, transform);

        playerBulletPool.autoExpand = autoExpandPlaererBullet;
        uFOBulletPool.autoExpand = autoExpandUFOBullet;
    }

    public PoolMono<Bullet> PlayerBulletPool => playerBulletPool;
    public PoolMono<Bullet> UFOBulletPool => uFOBulletPool;
}
