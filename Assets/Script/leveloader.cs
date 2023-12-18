using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leveloader : MonoBehaviour
{
    public Animator transition;
    public float transitiontime = 1f;
    public CharaterController player;
    public float delayBeforeLoad = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public IEnumerator loadlevel(int levelindex)
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(levelindex);
    }
}
