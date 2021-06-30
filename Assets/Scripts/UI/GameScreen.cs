using UnityEngine;
using UnityEngine.UI;
public class GameScreen : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text quantityLifeText;

    public void UpdateScoreText(float score)
    {
        scoreText.text = "Score " + score.ToString();
    }

    public void UpdateQuantityLifeText(float quantity)
    {
        quantityLifeText.text = "Lifes " + quantity.ToString();
    }
}
