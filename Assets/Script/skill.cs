using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skill : MonoBehaviour
{
    public Image skillImage;
    public float coolDown = 5;
    bool isCoolDown = false;
    private CharaterController player;

    // Start is called before the first frame update
    void Start()
    {
        skillImage.fillAmount = 1;
    }
    private void Awake()
    {
        player = FindObjectOfType<CharaterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Skill1();
    }
    void Skill1()
    {
        if(Input.GetKey(KeyCode.Space) && isCoolDown == false)
        {
            isCoolDown = true;
            skillImage.fillAmount = 0;
            player.UseSkill();
        }
        if (isCoolDown)
        {
            skillImage.fillAmount += 1 / coolDown * Time.deltaTime;
            if (skillImage.fillAmount <= 0)
            {
                skillImage.fillAmount = 0;
                isCoolDown = false;
            }
        }
    }
}
