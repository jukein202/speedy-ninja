using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    //private Vector3 startPosition;

    //private void Start()
    //{
    //    // Khởi tạo vị trí bắt đầu từ PlayerPrefs hoặc một vị trí mặc định
    //    startPosition = PlayerPrefs.HasKey("PlayerPositionX") ?
    //        new Vector3(PlayerPrefs.GetFloat("PlayerPositionX"), PlayerPrefs.GetFloat("PlayerPositionY"), PlayerPrefs.GetFloat("PlayerPositionZ")) :
    //        new Vector3(0f, 0f, 0f);

    //    // Đặt vị trí cho nhân vật
    //    SetPlayerPosition();
    //}

    //private void SetPlayerPosition()
    //{
    //    // Thiết lập vị trí cho nhân vật
    //    GameObject player = GameObject.FindGameObjectWithTag("Player");

    //    if (player != null)
    //    {
    //        player.transform.position = startPosition;
    //    }
    //}

    //public void SavePlayerPosition(Vector3 position)
    //{
    //    // Lưu vị trí vào PlayerPrefs
    //    PlayerPrefs.SetFloat("PlayerPositionX", position.x);
    //    PlayerPrefs.SetFloat("PlayerPositionY", position.y);
    //    PlayerPrefs.SetFloat("PlayerPositionZ", position.z);
    //    PlayerPrefs.Save();
    //}

    private Vector3 startPosition = new Vector3(0f, 0f, 0f);

    private void Start()
    {
        SetPlayerPosition();
    }

    private void SetPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            player.transform.position = startPosition;
        }
    }
}
