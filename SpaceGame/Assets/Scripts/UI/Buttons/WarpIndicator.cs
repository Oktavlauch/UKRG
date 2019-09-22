using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarpIndicator : MonoBehaviour
{
    public TextMeshProUGUI wp;
    
    // Update is called once per frame
    void Update()
    {
        string timescale = Time.timeScale.ToString();
        wp.text = timescale + "x"; 
    }
}
