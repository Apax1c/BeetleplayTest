using TMPro;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;

    [SerializeField] private TextMeshProUGUI levelScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int Score { get; private set; }
    public int CurrentLevelScore { get; private set; }
    public int LevelMaxScore;

    public static UIBehaviour Instance;
    private void Awake()
    {
        Instance = this;
        CurrentLevelScore = 0;
        Score = PlayerPrefs.GetInt("Score", 0);
    }

    private void Update()
    {
        scoreText.text = "Score: " + (Score* 100);
    }

    public void AddScore()
    {
        Score++;
        CurrentLevelScore++;
        PlayerPrefs.SetInt("Score", Score);
    }

    public void LevelWin()
    {
        Time.timeScale = 0f;
        winUI.SetActive(true);
        levelScoreText.text = "Gems scored: " + CurrentLevelScore + "/" + LevelMaxScore;
        scoreText.gameObject.SetActive(false);
    }

    public void LevelLose()
    {
        Time.timeScale = 0f;
        loseUI.SetActive(true);
        scoreText.gameObject.SetActive(false);
        PlayerPrefs.SetInt("Score", 0);
    }
}
