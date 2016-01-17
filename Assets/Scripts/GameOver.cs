using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Image image;
    private bool isGameOver = false;
    public AudioClip startSound;

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
        if (!gameObject)
        {
            SoundManager.instance.PlaySingle(startSound);
        }
        isGameOver = gameOver;
        image.enabled = gameObject;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
