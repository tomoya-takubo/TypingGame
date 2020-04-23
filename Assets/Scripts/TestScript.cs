using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Text AnswerHiragana; //解答途中までのひらがなを表示
    //入力キーテーブル
    public static Dictionary<string, List<string>> keyTable
        = new Dictionary<string, List<string>>()
    {
        {"あ", new List<string>(){"a"} },
        {"い", new List<string>(){"i", "yi"} },
        {"う", new List<string>(){"u", "wu", "whu" } }
    };

    private int nowQuestionHIndex = 0;  //現在査定されているひらがな（初期値0）
    private int nowQuestionHRomajiIndex = 0;    //現在査定されているひらがなに含まれるローマ字のインデックス
    private List<string> nowQuestionH
        = new List<string>() {"う", "い", "う", "い", "あ" };
    private string inputWord;   //入力文字を保持する変数

    /*
     * Awake();
     * Start();
     * (自作関数)
     * Update();
     */

    // Start is called before the first frame update
    void InputCheck()
    {
        inputWord += Input.inputString;

        //入力文字を査定する
        foreach (string value in keyTable[nowQuestionH[nowQuestionHIndex]])
        {
            Debug.Log("Now Value is ; " + value);

            if(nowQuestionHRomajiIndex < value.Length)
            {
                //査定
                if (value[nowQuestionHRomajiIndex] == inputWord[nowQuestionHRomajiIndex])   //正解
                {
                    if (inputWord.Length < value.Length)      //未完答（途中）
                    {
                        Debug.Log("正解になりうる文字が入力されました");
                        nowQuestionHRomajiIndex++;
                        break;
                    }
                    //完答
                    else if(inputWord.Length == value.Length)
                    {
                        Debug.Log("正しいローマ字が入力されたので次のひらがなに移ります");
                        AnswerHiragana.text += nowQuestionH[nowQuestionHIndex];
                        nowQuestionHIndex++;    //次の問題へ・・・
                        inputWord = ""; //入力値初期化
                        nowQuestionHRomajiIndex = 0;    //インデックス初期化
                        break;
                    }
                }
            }
            else
            {
                //何もしない
            }


            /*
            //分解した文字を入れとく用のList型を用意
            List<string> chr = new List<string>();

            //valueを一文字づつに分解する
            for(int i=0; i < value.Length; i++)
            {
                chr.Add(value[i].ToString());   //"u"ならchr[0] = "u"のみ。 "whu"ならchr[0] = "w", chr[1] = "h", chr[2] = "u"。
            }
            */

            /*
            //Debug.Log(Input.inputString);
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
            */
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
