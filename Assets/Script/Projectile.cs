using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 moveSpeed = new Vector2(3f, 0);
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // Nếu bạn muốn đường đạn được tác động bởi lực hấp dẫn theo mặc định, hãy đặt nó ở chế độ dynamic ở rigidbody
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
