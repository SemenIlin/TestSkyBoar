using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float quantityBulletInSecond = 3;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPoint;

    [SerializeField] BulletPool bulletPool;

    GameObject bullet;
    bool isStartShoot;

    float timerForBullet;
    float currentQuantityShootBullet;
   
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentQuantityShootBullet == 0)
            {
                isStartShoot = true;
            }

            if (isStartShoot && currentQuantityShootBullet < quantityBulletInSecond)
            {
                CreateBullet();
            }
        }

        if (isStartShoot)
        {
            timerForBullet += Time.deltaTime;
            if(timerForBullet >= 1)
            {
                timerForBullet = 0;
                isStartShoot = false;
                currentQuantityShootBullet = 0;
            }
        }
    }
    void CreateBullet()
    {
        ++currentQuantityShootBullet;

        //bullet = Instantiate(bulletPrefab);
        bullet = bulletPool.PlayerBulletPool.GetFreeElement().gameObject;
        bullet.transform.position = shootPoint.position;

        var bulletScript = bullet.GetComponent<Bullet>();

        bulletScript.Short(transform.localRotation);
    }
}
