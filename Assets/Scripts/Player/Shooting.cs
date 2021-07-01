using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float quantityBulletInSecond = 3;
    [SerializeField] Transform shootPoint;

    [SerializeField] BulletPool bulletPool;

    GameObject bullet;
    bool isStartShoot;

    float timerForBullet;
    float currentQuantityShootBullet;
   
    void Update()
    {
        if (GameSettings.Instance.ControlType == ControlType.Keyboard)
        {
            ShootKeySpace();
        }

        if (GameSettings.Instance.ControlType == ControlType.KeyboardWithMouse)
        {
            ShootKeySpace();

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
    }

    void Shoot()
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
    void ShootKeySpace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        OnLimitForShootBullet();
    }

    void OnLimitForShootBullet()
    {
        if (isStartShoot)
        {
            timerForBullet += Time.deltaTime;
            if (timerForBullet >= 1)
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
