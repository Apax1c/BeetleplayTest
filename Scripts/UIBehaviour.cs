using TMPro;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;

    [SerializeField] private TextMeshProUGUI levelScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int Score { get; private set; }
    public int LevelMaxScore;

    public static UIBehaviour Instance;
    private void Awake()
    {
        Instance = this;
        Score = 0;
    }

    private void Update()
    {
        scoreText.text = "Score: " + (Score* 100);
    }

    public void AddScore()
    {
        Score++;
    }

    public void LevelWin()
    {
        Time.timeScale = 0f;
        winUI.SetActive(true);
        levelScoreText.text = "Gems scored: " + Score + "/" + LevelMaxScore;
        scoreText.gameObject.SetActive(false);
    }

    public void LevelLose()
    {
        Time.timeScale = 0f;
        loseUI.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }
}
