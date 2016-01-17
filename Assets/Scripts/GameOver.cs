using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Image image;
    private bool isGameOver = false;

    void Awake()
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        image.enabled = false;
    }

    public void SetGameOver(bool gameOver)
    {
        isGameOver = gameOver;
        image.enabled = gameObject;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
