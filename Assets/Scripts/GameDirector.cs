using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//enumを使うために必要
using System;

public class GameDirector : MonoBehaviour
{
    public Text inputText;

    void Update()
    {
        //DownKeyCheck();

        GetInputString();
    }


    /***
    void DownKeyCheck()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    //処理を書く
                    //Debug.Log(code);
                    inputText.text += code.ToString();
                    break;
                }
            }
        }
    }
    ***/

    void GetInputString()
    {
        if (Input.anyKeyDown)
        {
            inputText.text += Input.inputString;
        }
    }

}