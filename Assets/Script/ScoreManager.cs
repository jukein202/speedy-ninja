using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText; // Giao diện hiển thị điểm số
    public int score = 0;
    public float coin;
    private PlayerPositionManager playerposition;
    CharaterController characterController;
    CameraMovement movement;
    // Start is called before the first frame update

    private void Awake()
    {
        //// Kiểm tra xem đã có thể hiện của GameManager nào chưa
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // Nếu đã có, hủy bỏ thể hiện hiện tại và giữ lại thể hiện đầu tiên
            Destroy(gameObject);
        }
        // Kiểm tra xem đã lưu trữ điểm trước đó hay chưa
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            score = PlayerPrefs.GetInt("PlayerScore");
            UpdateScore();
        }
        characterController = FindObjectOfType<CharaterController>();
        movement = FindObjectOfType<CameraMovement>();
    }
    private void Update()
    {

    }

    private void UpdateScore()
    {
        // Cập nhật hiển thị điểm trên UI
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        // Tăng điểm khi được gọi từ các phần tử khác trong game
        score += amount;
        UpdateScore();
    }
    public void ChangeScene(int sceneName)
    {

        // Lưu điểm vào PlayerPrefs để giữ lại giá trị khi chuyển scene
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.SetFloat("PlayerSpeed", movement.speed);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

}
