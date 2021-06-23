using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float quantityBulletInSecond = 3;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPoint;

    GameObject bullet;

    float timerForBullet;
    float currentQuantityShootBullet;
   
    void Update()
    {
       // timerForBullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBullet();
        }
    }
    void CreateBullet()
    {
        ++currentQuantityShootBullet;

        bullet = Instantiate(bulletPrefab);
        bullet.transform.position = shootPoint.position;

        var bulletScript = bullet.GetComponent<Bullet>();

        bulletScript.SetDirection(transform.localEulerAngles);
    }


}
