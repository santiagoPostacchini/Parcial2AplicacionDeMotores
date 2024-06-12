using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class AutoAI : Auto
{
    void Start()
    {
        _input = new InputAI();
    }
}
