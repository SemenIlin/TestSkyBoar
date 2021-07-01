using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] Text keyboardText;
    [SerializeField] Text keyboardPlusMouseText;

    [SerializeField] Button ContinueButton;

    [SerializeField] GameScreen gameScreen;
    [SerializeField] Score score;

    bool isStartGame;
    bool isChange;

    private void Start()
    {
        GameSettings.Instance.SetControlType(ControlType.Keyboard);
        Time.timeScale = 0;
        ContinueButton.interactable = false;
    }

    public GameScreen GameScreen => gameScreen;
    public Score Score => score;

    public void Restart()
    {
        ShowScreen();
        score.ResetQuantityLife();
        gameScreen.UpdateScoreText(0);
        GameSettings.Instance.SetControlType(ControlType.Keyboard);
        Time.timeScale = 0;
        ContinueButton.interactable = false;
    }
    public void SelectContinueGame()
    {
        HideScreen();
        Time.timeScale = 1;        
    }

    public void NewGame()
    {
        GameSettings.Instance.SetIsGameOver(false);
        HideScreen();
        Time.timeScale = 1;

        ResetUIText();

        if (!isStartGame)
        {
            isStartGame = true;
            ContinueButton.interactable = isStartGame;
        }
    }

    public void ChangeControl()
    {
        ChangeText(isChange);
        isChange = !isChange;
        GameSettings.Instance.SetControlType(isChange);
    }
    public void Pause()
    {
        ShowScreen();
        Time.timeScale = 0;
    }
    public void HideScreen()
    {
        gameObject.SetActive(false);
    }

   
    public void ShowScreen()
    {
        gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void ChangeText(bool isKeyboard)
    {
        keyboardText.enabled = isKeyboard;
        keyboardPlusMouseText.enabled = !isKeyboard;
    }

    void ResetUIText()
    {
        gameScreen.UpdateScoreText(0);
        gameScreen.UpdateQuantityLifeText(score.QuantityLifes);
    }
}
