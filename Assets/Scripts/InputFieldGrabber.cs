using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InputFieldGrabber : MonoBehaviour
{
    // Start is called before the first frame update

    static TMP_InputField inputField;
    
    void Start()
    {
        inputField = this.GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReadInput()
    {
        if (inputField != null)
        {
            string inputText = inputField.text;
            Debug.Log(inputText);
   
        }
        else
        {
            Debug.LogError("Input Field is null");
        }
    }
}
