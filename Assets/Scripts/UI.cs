using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [SerializeField] Text scoreText;

    public void UpdateScoreText(float score)
    {
        scoreText.text = "Score " + score.ToString();
    }
}
