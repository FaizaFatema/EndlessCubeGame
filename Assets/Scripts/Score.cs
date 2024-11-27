using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }
      GameController gameController;

    public TextMeshProUGUI scoreText;

    public float score = 0f;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    private void Start()
    {
         gameController = FindObjectOfType<GameController>();
    }
    private void FixedUpdate()
    {

        if (!gameController.isGameOver)
        {
            score += Time.deltaTime;
        }
        scoreText.text = ((int)score).ToString();
    }
    void PlayerOut()
    {
        gameController.GameOver();
    }
}
