using UnityEngine;

public class GameSettings : MonoBehaviour
{
    ControlType controlType;
    bool isGameOver;
    public static GameSettings Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    public ControlType ControlType => controlType;

    public bool IsGameOver => isGameOver;

    public void SetIsGameOver(bool isGameOver)
    {
        this.isGameOver = isGameOver;
    }
    public void SetControlType(bool value)
    {
        controlType = (ControlType)(value ? 1 : 0);
    }

    public void SetControlType(ControlType value)
    {
        controlType = value;
    }

}
