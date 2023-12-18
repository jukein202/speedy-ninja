using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    public GameObject volumeSetting;
    public GameObject character;
    public GameObject menu;
    public Text lastScoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("LastScore"))
        {
            int lastScore = PlayerPrefs.GetInt("LastScore");
            lastScoreText.text = "Last Score: " + lastScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    CharaterController characterController;
    private void Awake()
    {
        characterController = FindObjectOfType<CharaterController>();
    }
    public void Playgame()
    {
        if (characterController != null)
        {
            characterController.IsAlive = true;
            //characterController.Respawn();
        }
        PlayerPrefs.DeleteKey("PlayerScore");
        PlayerPrefs.DeleteKey("LastScore");
        PlayerPrefs.SetFloat("PlayerSpeed",8);
        SceneManager.LoadScene("PlayScenes");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void option()
    {
        volumeSetting.SetActive(true);
    }
    public void saveoption()
    {
        volumeSetting.SetActive(false);
    }
    public void Character()
    {
        menu.SetActive(false);
        character.SetActive(true);
    }
    public void BackCharacter()
    {
        menu.SetActive(true);
        character.SetActive(false);
    }
}
