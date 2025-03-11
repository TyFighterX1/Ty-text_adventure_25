using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{

    public Image background;
    public Text displayText;
    public Text toggleText;

    private bool darkMode;

    // Start is called before the first frame update
    void Start()
    {
        Toggle toggle = GetComponent<Toggle>();
        darkMode = toggle.isOn;
        SetTheme();
    }

    // Update is called once per frame
    void SetTheme()
    {
        if(darkMode)
        {
            background.color = Color.black;
            displayText.color = Color.white;
            toggleText.color = Color.white;
        }
        else
        {
            background.color = Color.black;
            displayText.color = Color.white;
            toggleText.color = Color.white;
        }
    }
}
