using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keytoPress;

    public GameObject hiteffect, goodeffect, perfecteffect, misseffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keytoPress))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);

                //GameManger.instance.NoteHit();

                if(Mathf.Abs( transform.position.y) > 0.25)
                {
                    Debug.Log("Hit");
                    GameManger.instance.NormalHit();
                    Instantiate(hiteffect, transform.position, hiteffect.transform.rotation);
                }
                else if(Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("Good");
                    GameManger.instance.GoodHit();
                    Instantiate(goodeffect, transform.position, goodeffect.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect");
                    GameManger.instance.PerfectHit();
                    Instantiate(perfecteffect, transform.position, perfecteffect.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;

            GameManger.instance.NoteMissed();
            Instantiate(misseffect, transform.position, misseffect.transform.rotation);
        }
    }
}
