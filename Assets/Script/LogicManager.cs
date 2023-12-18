using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq; 

public class LogicManager : MonoBehaviour
{
    public Text scoreText; // Giao diện hiển thị điểm số
    public float timeSpawn = 0f;
    public int scoreIncreaseRate = 1; // Tốc độ tăng điểm
    public GameObject GameOverScreen;
    public GameObject PauseMenu;
    public GameObject displayChangeScene;
    public GameObject spawnEnemy;
    public GameObject volumeSetting;
    public static bool GameIsPaused = false;
    private CharaterController player;
    private ScoreManager scoreManager;
    private CameraMovement cameraMovement;
    private VolumeSetting volume;



    private void Start()
    {
        
    }
    private void Awake()
    {
        player = FindObjectOfType<CharaterController>();
        scoreManager = FindObjectOfType<ScoreManager>();
        xmlManager = FindObjectOfType<XMLManager>();
        cameraMovement = FindObjectOfType<CameraMovement>();
        volume = FindObjectOfType<VolumeSetting>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


        if (player.IsAlive && !GameIsPaused)
        {
            scoreManager.IncreaseScore(scoreIncreaseRate);
        }
        if (!player.IsAlive)
        {
            GameOver();
        }
        if (cameraMovement.elapsedTime >= 100.0f)
        {
            DisplayChangeScene();
        }
        if (cameraMovement.elapsedTime >= timeSpawn)
        {
            spawnEnemy.SetActive(true);
        }
    }

    public void GameOver()
    {
        //PlayerPrefs.DeleteKey("PlayerScore");
        GameOverScreen.SetActive(true);
    }
    public void DisplayChangeScene()
    {
        displayChangeScene.SetActive(true);
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Option()
    {
        PauseMenu.SetActive(false);
        volumeSetting.SetActive(true);
    }
    public void SaveOption()
    {
        PauseMenu.SetActive(true);
        volumeSetting.SetActive(false);
    }
    public void BackMainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    HighScoreEntry newHighScore = new HighScoreEntry();
    private XMLManager xmlManager;
    public void EndGame()
    {
        newHighScore.score = scoreManager.score;
        List<HighScoreEntry> currentScores = xmlManager.LoadScores();
        // Thêm điểm số mới vào danh sách hiện tại
        currentScores.Add(newHighScore);
        currentScores.Sort((a, b) => b.score.CompareTo(a.score));
        int maxEntries = 5; // Số lượng tối đa của điểm số bạn muốn giữ trong danh sách
        while (currentScores.Count > maxEntries)
        {
            // Xóa điểm số cuối cùng trong danh sách (điểm số thấp nhất)
            currentScores.RemoveAt(currentScores.Count - 1);
        }
        xmlManager.SaveScores(currentScores);
        PlayerPrefs.SetInt("LastScore", scoreManager.score);
        PlayerPrefs.Save();

        SceneManager.LoadScene("MainMenu");
    }
    

}
