using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doors : MonoBehaviour
{

    public bool open;
    public Animation anim;
    bool iN;
    public AnimationClip[] anima;

    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && iN)
        {
            open = !open;
            if (iN)
                if (open)
                {
                    anim.CrossFade(anima[0].name);
                }
                else
                    anim.CrossFade(anima[1].name);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            iN = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iN = false;
        }
    }
}
