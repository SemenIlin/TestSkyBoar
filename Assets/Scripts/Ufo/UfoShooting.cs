using UnityEngine;

public class UfoShooting : MonoBehaviour
{
    [SerializeField, Range(0, 5)] float periodBetweenShootsMinValue = 2;
    [SerializeField, Range(2, 8)] float periodBetweenShootsMaxValue = 5;
    [SerializeField] Transform shootPoint;

    BulletPool bulletPool;
    Transform target;

    float min;
    float max;

    float timer;
    void Start()
    {
        var target = FindObjectOfType<ShipMovement>();
        if (target != null)
        {
            this.target = target.transform;
        }

        bulletPool = FindObjectOfType<BulletPool>();
       // Shoot();
        timer = GetPeriodBetweenShoot();
    }

    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
           // Shoot();
            timer = GetPeriodBetweenShoot();
        }
    }

    void Shoot()
    {
        var bullet = bulletPool.UFOBulletPool.GetFreeElement().gameObject;
        bullet.transform.position = shootPoint.position;
        var target = FindObjectOfType<ShipMovement>();
        if (target == null)
        {
            return;
        }

        var angle = Vector3.Angle(Vector3.up, target.transform.position);

        Debug.Log("angle " + angle);
       // bullet.GetComponent<BulletMovement>().Short(new Vector3(0, 0, angle));
    }

    float GetPeriodBetweenShoot()
    {
        min = periodBetweenShootsMaxValue > periodBetweenShootsMinValue ? periodBetweenShootsMinValue : periodBetweenShootsMaxValue;
        max = periodBetweenShootsMaxValue < periodBetweenShootsMinValue ? periodBetweenShootsMinValue : periodBetweenShootsMaxValue;

        return Random.Range(min, max);
    }
}
