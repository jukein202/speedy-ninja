using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmByDis : MonoBehaviour
{
    public Transform Player;
    public float currentDis = 0f;
    public float limitDis = 100f;
    public float respawnDis = 166f;
    public GameObject coin;
    public List<GameObject> coinList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        this.GetDistance();
        this.Spawning();
        AddCoinsToList();
    }

    protected void Spawning()
    {
        if (this.currentDis < this.limitDis) return;
        Debug.Log("Spawning");
        ActivateAllCoins();
        Vector3 pos = transform.position;
        pos.x += this.respawnDis;
        transform.position = pos;
    }

    protected virtual void GetDistance()
    {
        this.currentDis = this.Player.position.x - transform.position.x;
    }
    private void AddCoinsToList()
    {
        GameObject[] allCoins = GameObject.FindGameObjectsWithTag("Coin");

        foreach (GameObject coin in allCoins)
        {
            coinList.Add(coin);
        }
    }
    private void ActivateAllCoins()
    {
        foreach (GameObject coin in coinList)
        {
            coin.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Spawning();
        GetDistance();
    }
}
