using UnityEngine;

public class UfoShooting : MonoBehaviour
{
    [SerializeField, Range(0, 5)] float periodBetweenShootsMinValue = 2;
    [SerializeField, Range(2, 8)] float periodBetweenShootsMaxValue = 5;
    [SerializeField] Transform shootPoint;

    BulletPool bulletPool;

    float min;
    float max;

    float timer;
    void Start()
    {    
        bulletPool = FindObjectOfType<BulletPool>();
        Shoot();
        timer = GetPeriodBetweenShoot();
    }

    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            Shoot();
            timer = GetPeriodBetweenShoot();
        }
    }

    void Shoot()
    {
        var bullet = bulletPool.UFOBulletPool.GetFreeElement().gameObject;
        var target = FindObjectOfType<ShipMovement>();
        if (target == null)
        {
            return;
        }

        var angle = Vector3.Angle(target.transform.position - shootPoint.position, shootPoint.up);
        if (target.transform.position.x > shootPoint.position.x)
        {
            angle = -angle;
        }

        bullet.GetComponent<Bullet>().Short(new Vector3(0, 0, angle), shootPoint.position);
    }

    float GetPeriodBetweenShoot()
    {
        min = periodBetweenShootsMaxValue > periodBetweenShootsMinValue ? periodBetweenShootsMinValue : periodBetweenShootsMaxValue;
        max = periodBetweenShootsMaxValue < periodBetweenShootsMinValue ? periodBetweenShootsMinValue : periodBetweenShootsMaxValue;

        return Random.Range(min, max);
    }
}
