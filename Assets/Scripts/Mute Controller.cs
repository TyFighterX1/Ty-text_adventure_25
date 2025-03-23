using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool muteToggle;
    
    void Start()
    {
        Toggle toggle = GetComponent<Toggle>();
        muteToggle = toggle.isOn;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
