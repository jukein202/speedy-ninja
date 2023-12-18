using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float minY = -4f; // Độ chệch tối thiểu của vị trí y
    public float maxY = 4f;  // Độ chệch tối đa của vị trí y
    public float spawnInterval = 2f; // Khoảng thời gian giữa các lần spawn

    private float currentX; // Giá trị x khởi đầu
    private float cameraWidth;
    void Start()
    {
        cameraWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        // Bắt đầu hàm SpawnObject lặp đi lặp lại
        InvokeRepeating("SpawnObject", 1f, spawnInterval);
    }

    void Update()
    {

    }

    void SpawnObject()
    {
        // Chọn một vị trí y ngẫu nhiên trong khoảng minY đến maxY
        float randomY = Random.Range(minY, maxY);
        float cameraX = Camera.main.transform.position.x;
        // Đặt vị trí của game object
        Vector3 spawnPosition = new Vector3(cameraX + 13f, randomY, 0f);



        // Spawn game object
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

    }
}
