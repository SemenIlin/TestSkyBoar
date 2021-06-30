using UnityEngine;

public class Score : MonoBehaviour
{
    float points = 0;

    public float Points => points;
    public void SetPoints(float reward)
    {
        points += reward;
    }
}
