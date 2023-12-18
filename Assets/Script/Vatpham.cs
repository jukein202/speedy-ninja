using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vatpham : MonoBehaviour
{
    private ScoreManager score;
    private float pointsPerCollectable = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        score = FindObjectOfType<ScoreManager>();
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
            score.coin += pointsPerCollectable;
            gameObject.SetActive(false);
        }
    }
}
