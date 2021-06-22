using UnityEngine;

public class LittleAsteroid : Asteroid, IObstacle
{
    [SerializeField] float damage;
    public float ToDamage => damage;

    public void GetBihaviour()
    {
        Destroy(transform.gameObject);
    }

    public void SetDirection(Vector3 direction, float deltaAngle)
    {
        this.direction = direction;
        var angle = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        var gipotenusa = 0.0f;
        angle += deltaAngle;       

        if (angle > 90)
        {
            angle = 180 - angle;
            gipotenusa = this.direction.x / Mathf.Cos(angle * Mathf.PI / 180);
            this.direction.x *= -1;          
        }

        else if(angle < 0)
        {
            gipotenusa = this.direction.x / Mathf.Cos(angle * Mathf.PI / 180);

            this.direction.y = Mathf.Sqrt(gipotenusa * gipotenusa - this.direction.x * this.direction.x);
            this.direction.y *= -1;
        }

        else
        {
            gipotenusa = this.direction.x / Mathf.Cos(angle * Mathf.PI / 180);
            this.direction.y = Mathf.Sqrt(gipotenusa * gipotenusa - this.direction.x * this.direction.x);
        }

        while (this.direction.y >= 1)
        {
            this.direction.y /= 2;
            this.direction.x /= 2;
        }
    }
}
