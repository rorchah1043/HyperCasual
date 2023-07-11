using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;
    private int score;

    public void Score(int value)
    {
        textScore.text = value.ToString();
    }
}
