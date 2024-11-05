using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
      GameController gameController;

    public TextMeshProUGUI scoreText;

    public float score = 0f;

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
