using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vatphamchangeScene : MonoBehaviour
{
    private CharaterController player;
    ScoreManager score;

    // Start is called before the first frame update
    private void Awake()
    {
        player = FindObjectOfType<CharaterController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public LayerMask layerVatPham;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Invoke("CompleteLevel", 2f);
            CompleteLevel();
        }
    }
    private void CompleteLevel()
    {
        //score.SaveScore();
        ScoreManager.instance.ChangeScene(2);

        //SceneManager.LoadScene(3);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
