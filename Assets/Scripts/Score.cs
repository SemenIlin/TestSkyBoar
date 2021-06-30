using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] int quantityLifes = 4;
    float points = 0;

    public float Points => points;

    public int QuantityLifes => quantityLifes;

    public void DecreaseQuantityLifes()
    {
        --quantityLifes;
    }
    public void AddPoints(float reward)
    {
        points += reward;
    }
}
