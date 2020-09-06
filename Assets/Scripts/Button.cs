using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public string buttonName;
    
    public static Action<string> OnButtonClicked = delegate(string s) {  };

    void OnClicked() => OnButtonClicked(buttonName);

}
