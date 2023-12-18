using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.UI;

public class XMLManager : MonoBehaviour
{
    public static XMLManager instance;
    public Leaderboard leaderboard;
    public Text leaderboardText; // Gán UI Text vào đây từ Editor
    void Start()
    {
        LoadAndDisplayXML();
    }

    private void LoadAndDisplayXML()
    {
        List<HighScoreEntry> scores = LoadScores();

        // Hiển thị thông tin trong UI Text
        if (leaderboardText != null)
        {
            leaderboardText.text = "Bảng điểm:\n";

            foreach (HighScoreEntry entry in scores)
            {
                leaderboardText.text += $"{entry.name}: {entry.score}\n";
            }
        }
    }
    void Awake()
    {
        instance = this;
        if (!Directory.Exists(Application.persistentDataPath + "/HighScores/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/HighScores/");
        }
    }
    public void SaveScores(List<HighScoreEntry> scoresToSave)
    {
        leaderboard.list = scoresToSave;
        XmlSerializer serializer = new XmlSerializer(typeof(Leaderboard));
        FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Create);
        serializer.Serialize(stream, leaderboard);
        stream.Close();
    }
    public List<HighScoreEntry> LoadScores()
    {
        if (File.Exists(Application.persistentDataPath + "/HighScores/highscores.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Leaderboard));
            FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Open);
            leaderboard = serializer.Deserialize(stream) as Leaderboard;
        }
        if (leaderboard != null)
        {
            return leaderboard.list;
           
        }
        else
        {
            Debug.LogWarning("Leaderboard is null. Returning an empty list.");
            return new List<HighScoreEntry>();
        }

    }

}
[System.Serializable]
public class Leaderboard
{
    public List<HighScoreEntry> list = new List<HighScoreEntry>();
}
