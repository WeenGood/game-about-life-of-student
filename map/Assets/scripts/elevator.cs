using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour {


    GameObject button;
    GameObject buttonUP;
    GameObject buttonDOWN;
    bool flag = true;
    public Animation anim;

    // Use this for initialization
    void Start () {
        buttonUP = GameObject.Find("buttonUp");
        buttonDOWN = GameObject.Find("buttonDown");
        anim = this.GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E)&&flag)//клик левой мышью
        {
                button = GetObjectFromMouseRaycast();//мы получили объект, в который попал луч из камеры через курсор    
                if (button == buttonUP)
                {
                    anim.CrossFade("elevatorUP");
                }
                else
                    if(button == buttonDOWN)
                    {
                        anim.CrossFade("elevatorDOWN");
                    }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            flag = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            flag = false;
        }
    }

    private GameObject GetObjectFromMouseRaycast()
    {
        GameObject gmObj = null;
        RaycastHit hitInfo = new RaycastHit();
        //mousePosition x,y курсора на экране
        //Raycast кастует луч, возвращает тру, если луч пересекся с коллайдером
        //Camera.main.ScreenPointToRay(Input.mousePosition) возвращает луч, который идет из камеры через курсор (начальная точка и направление луча)
        //hitInfo содержит какую-то информацию о месте, куда попал луч
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit)//если попало в коллайдер
        {
            gmObj = hitInfo.collider.gameObject;
        }
        return gmObj;
    }
}

