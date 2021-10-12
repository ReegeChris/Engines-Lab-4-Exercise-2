using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{

    private int _health = 100;
    private Text _text;

    public static HealthText Instance { get; private set; }

  
    private void Awake()
    {
        _text = GetComponent<Text>();
        Instance = this;
     
    }

    public void SubtractHealth(int value)
    {
        _health -= value;
        _text.text = _health.ToString();
    }
}
