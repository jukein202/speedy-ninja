using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    LogicManager logicManager;
    [SerializeField]
    private bool isInvincible = false;
    public float skillInvincibleDuration = 5f;
    [SerializeField]
    private bool _isAlive = true;
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool("isAlive", value);
            Debug.Log("IsAlive Set " + value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Down") & IsAlive)
        {
            
            transform.localScale = new Vector2(1, -1);
            transform.position = new Vector3(transform.position.x, (float)-2.4, transform.position.z);
        }
        if (Input.GetButtonDown("Up") & IsAlive)
        {

            transform.localScale = new Vector2(1, 1);
            transform.position = new Vector3(transform.position.x, (float)-1, transform.position.z);
        }

    }
    public LayerMask layerVatPham; 
    public LayerMask layerVatPham2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(((layerVatPham.value & 1 << collision.gameObject.layer) > 0) || (layerVatPham2.value & 1 << collision.gameObject.layer) > 0)
        {
            
        }
        else
        {
            if (isInvincible == false)
            {
                IsAlive = false;
            }
        }
        
    }
    public void UseSkill()
    {      
            animator.SetTrigger("UseSkill");
        StartCoroutine(SkillInvincibility());
    }
    IEnumerator SkillInvincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(skillInvincibleDuration);
        isInvincible = false;
    }
    //public GameObject player;
    //private static CharaterController instance;
    //private Vector3 initialPosition;
    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);

    //        ////Đảm bảo rằng chỉ có một phiên bản duy nhất của nhân vật
    //        //if (player != null)
    //        //{
    //        //    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
    //        //    foreach (GameObject p in players)
    //        //    {
    //        //        if (p != player)
    //        //        {
    //        //            Destroy(p);
    //        //        }
    //        //    }
    //        //}
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //    initialPosition = transform.position;
    //}

}
