using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    //入力キーテーブル
    public static Dictionary<string, List<string>> keyTable
        = new Dictionary<string, List<string>>()
    {
        {"あ", new List<string>(){"a"} },
        {"い", new List<string>(){"i", "yi"} },
        {"う", new List<string>(){"u", "wu", "whu" } }
    };

    private int index = 0;  //現在問われている文字（初期値0）
    private List<string> nowQuestionH
        = new List<string>() {"う", "い", "う", "い", "あ" };

    // Start is called before the first frame update
    void InputCheck()
    {
        //入力文字を査定する
        foreach (string value in keyTable[nowQuestionH[index]])
        {
            //分解した文字を入れとく用のList型を用意
            List<string> chr = new List<string>();

            //valueを一文字づつに分解する
            for(int i=0; i < value.Length; i++)
            {
                chr.Add(value[i].ToString());
            }

            Debug.Log(Input.inputString);
            if (Input.inputString == value)   //"u"には入力文字が入る
            {
                Debug.Log(nowQuestionH[index]);
                if(index < nowQuestionH.Count)
                {
                    index++;
                }
                else
                {
                    Debug.Log("次の問題へ・・・");
                }
            }
            else
            {
                Debug.Log("間違いです");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            InputCheck();
        }
    }
}
