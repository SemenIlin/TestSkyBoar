using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] int quantityLifes = 4;
    int startQuaintityLifes;

    float points = 0;

    private void Start()
    {
        startQuaintityLifes = quantityLifes;
    }
    public float Points => points;

    public int QuantityLifes => quantityLifes;

    public void ResetQuantityLife()
    {
        quantityLifes = startQuaintityLifes;
    }

    public void DecreaseQuantityLifes()
    {
        --quantityLifes;
    }
    public void AddPoints(float reward)
    {
        points += reward;
    }
}
