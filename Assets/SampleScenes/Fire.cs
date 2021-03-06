using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    Ray ray; //射線
    float raylength = 200f; //射線最大長度
    RaycastHit hit; //被射線打到的物件
    public int count = 9;
    public Text countText; 

    // Start is called before the first frame update
    void Start()
    {
        print("Hello");
        displayCount();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        //由攝影機射到是畫面正中央的射線

        if (Physics.Raycast(ray, out hit, raylength))
        // (射線,out 被射線打到的物件,射線長度)，out hit 意思是：把"被射線打到的物件"帶給hit
        {
            hit.transform.SendMessage("HitByRaycast", gameObject, SendMessageOptions.DontRequireReceiver);
            //向被射線打到的物件呼叫名為"HitByRaycast"的方法，不需要傳回覆

            string pattern = @"sun_";

            if (Input.GetMouseButtonDown(0) && hit.transform.name != "Terrain") { 
            //if (Match match in Regex.Matches(hit.transform.name, pattern)) {
                hit.transform.gameObject.SetActive(false);
                print(pattern);
                count--;
                displayCount();
                
            }
            
            
            Debug.DrawLine(ray.origin, hit.point, Color.yellow);
            //當射線打到物件時會在Scene視窗畫出黃線，方便查閱

            print(hit.transform.name);
            //在Console視窗印出被射線打到的物件名稱，方便查閱                       
        }
        else
        {
        }
    }

    public void displayCount()
    {
        countText.text = count.ToString();
    }

    void HitByRaycast() //被射線打到時會進入此方法
    {
        hit.transform.gameObject.SetActive(false);
        print("HitByRaycast");
    }
}
