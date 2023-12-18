using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speedIncreaseAmount = 1f; 
    public float maxSpeed = 50f; 
    public float timeToIncreaseSpeed = 30f; 

    public float speed = 8; // Tốc độ hiện tại
    public float elapsedTime; // Thời gian đã trôi qua từ khi bắt đầu trò chơi
    private float timeSinceLastIncrease; // Thời gian kể từ lần tăng tốc độ cuối cùng
    public CharaterController player;
    private LogicManager logicManager;

    private void Start()
    {
        elapsedTime = 0f;
        timeSinceLastIncrease = 0f;
    }
    private void Awake()
    {
        if (PlayerPrefs.HasKey("PlayerSpeed"))
        {
            speed = PlayerPrefs.GetFloat("PlayerSpeed");
        }

        player = FindObjectOfType<CharaterController>();
        logicManager = FindObjectOfType<LogicManager>();
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime; // Tăng thời gian đã trôi qua
        timeSinceLastIncrease += Time.deltaTime; // Tăng thời gian kể từ lần tăng tốc độ cuối cùng
        if (!player.IsAlive)
        {
            speed = 0;
        }else if (timeSinceLastIncrease >= timeToIncreaseSpeed)
        {
            speed += speedIncreaseAmount;
            Debug.Log("Tốc độ mới: " + speed);

            // Giới hạn tốc độ tối đa
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }

            // Đặt lại thời gian kể từ lần tăng tốc độ cuối cùng
            timeSinceLastIncrease = 0f;
        }
       

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
