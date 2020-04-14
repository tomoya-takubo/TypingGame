using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public char chr = 'a';

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = chr.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
