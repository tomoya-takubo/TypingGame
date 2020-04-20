using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingSoft : MonoBehaviour
{
    public Text UIJ;    //日本語表示テキスト
    public Text UIR;    //ローマ字表示テキスト
    public Text UII;    //入力した文字列テキスト
    public Text UICorrectA; //正解数表示用テキストUI
    public Text UIMistake;  //間違い数表示用テキスト
    public Text UICorrectAR;    //正解率表示用テキスト

    private string[] qJ = { "問題", "テスト", "タイピング"};  //問題日本語分
    private string[] qR = { "monndai", "tesuto", "taipinngu" }; //問題ローマ字分
    private string nQJ; //日本語問題（ランダムで選ばれた１つ）
    private string nQR; //ローマ字問題（ランダムで選ばれあた１つ）
    private int num;    //問題番号
    private int index;  //問題の何文字目か
    private int correctN;   //正解数
    private int mistakeN;   //間違い数
    private float correctAR;    //正解率
    private string correctString;   //正解した文字列を格納

    // Start is called before the first frame update
    void Start()
    {
        //データ初期化処理
        Init();
               
        //問題出題
        OutputQ();
    }

    // Update is called once per frame
    void Update()
    {
        //キーを押しているかどうか
        if(Input.anyKey
            &&(!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2)))
        {
            //今見ている文字とキーボードから打った文字が同じかどうか
            if (Input.GetKey(nQR[index].ToString()))
            {
                //正解時の処理を呼び出す
                Correct();
            }
            else
            {
                //失敗時の処理を呼び出す
                Mistake();
            }

            //入力をリセット（Input.Getkey()の処理をすぐにしない（１フレームだけ0を挟む））
            Input.ResetInputAxes();
        }
    }

    /// <summary>
    /// 初期化関数
    /// </summary>
    void Init()
    {
        //正解数
        correctN = 0;   //初期化
        UICorrectA.text = correctN.ToString();  //表示

        //間違い数
        mistakeN = 0;   //初期化
        UIMistake.text = mistakeN.ToString();   //表示

        //正解率
        correctAR = 0;  //初期化
        UICorrectAR.text = correctAR.ToString();    //表示
    }

    /// <summary>
    /// 問題を出題する
    /// </summary>
    void OutputQ()
    {
        //各種初期化
        UIJ.text = "";
        UIR.text = "";
        UII.text = "";
        correctString = "";
        index = 0;
        
        //ランダムで問題を選ぶ
        num = Random.Range(0, qJ.Length);   //配列番号決定
        //選択した問題をテキストUIにセット
        nQJ = qJ[num];
        nQR = qR[num];
        UIJ.text = nQJ;
        UIR.text = nQR;

    }

    /// <summary>
    /// 正解時の処理
    /// </summary>
    void Correct()
    {
        //正解数を増やす
        correctN++;
        UICorrectA.text = correctN.ToString();
        //正解数の計算
        CorrectAnswerRate();
        //正解した文字を表示
        correctString += nQR[index].ToString();
        UII.text = correctString;
        //次の文字を指す
        index++;
        
        //問題を入力し終えたら次の問題を表示
        if(index >= nQR.Length)
        {
            OutputQ();
        }
    }

    /// <summary>
    /// 失敗時の処理
    /// </summary>
    void Mistake()
    {
        //間違い数更新
        mistakeN += Input.inputString.Length;   //間違い数を増やす
        UIMistake.text = mistakeN.ToString();

        //正解率計算・表示
        CorrectAnswerRate();

        //失敗した文字を表示
        if(Input.inputString != "")
        {
            UII.text = correctString
                + "<color=#ff0000ff>" + Input.inputString + "</color>";
        }
    }

    /// <summary>
    /// 正解率計算
    /// </summary>
    void CorrectAnswerRate()
    {
        correctAR
            = 100f * correctN / (correctN + mistakeN);    //正解率
        UICorrectAR.text = correctAR.ToString("0.00") + "%";     //表示（プレイスホルダー（"0.00"）は"F2"と同義））
    }
}
