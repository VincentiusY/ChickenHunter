using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI text;
    int nilai;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }

    public void changeScore(int chickenValue) {
        nilai = nilai+chickenValue;
        text.text = nilai.ToString();
    }
}
