using UnityEngine;

public class Screen : MonoBehaviour
{
    static float widthScreen;
    void Awake()
    {
        GetWidthScreen();
    }

    public static float WidthScreen => widthScreen;
    void GetWidthScreen()
    {
        var startPoint = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        var endPoint = Camera.main.ViewportToWorldPoint(Vector3.one).x;
        widthScreen = endPoint - startPoint;
    }
}
