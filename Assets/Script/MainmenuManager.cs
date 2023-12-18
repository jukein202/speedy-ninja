using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainmenuManager : MonoBehaviour
{
    //public Text lastScoreText;
    public Text highScoreText;
    private List<int> highScores;
    void Start()
    {
      
        // Load danh sách điểm số từ PlayerPrefs
        LoadHighScores();

        // Hiển thị bảng thống kê
        DisplayHighScores();

    }
    public void AddScore(int score)
    {
        // Thêm điểm số mới vào danh sách và sắp xếp lại
        highScores.Add(score);
        highScores.Sort((a, b) => b.CompareTo(a));

        // Giữ chỉ 10 điểm số cao nhất
        if (highScores.Count > 10)
        {
            highScores.RemoveAt(10);
        }

        // Lưu danh sách mới vào PlayerPrefs
        SaveHighScores();

        // Hiển thị bảng thống kê cập nhật
        DisplayHighScores();
        Debug.Log($"Added score: {score}");
    }

    public void DisplayHighScores()
    {
        // Hiển thị điểm số trên UI Text
        highScoreText.text = "High Scores:\n";

        for (int i = 0; i < highScores.Count; i++)
        {
            highScoreText.text += $"{i + 1}. {highScores[i]}\n";
        }
    }

    public void LoadHighScores()
    {
        // Load danh sách điểm số từ PlayerPrefs
        if (PlayerPrefs.HasKey("HighScores"))
        {
            string json = PlayerPrefs.GetString("HighScores");
            highScores = JsonUtility.FromJson<List<int>>(json);
        }
        else
        {
            // Nếu không có danh sách, tạo mới
            highScores = new List<int>();
        }
    }

    public void SaveHighScores()
    {
        // Lưu danh sách điểm số vào PlayerPrefs
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("HighScores", json);
        PlayerPrefs.Save();
    }

}
