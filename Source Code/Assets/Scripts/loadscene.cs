using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loadscene : MonoBehaviour {

    public Button myButton;

    void OnEnable()
    {
        myButton.onClick.AddListener(MyFunction);//adds a listener for when you click the button
    }

    void MyFunction()// your listener calls this function
    {
        Application.LoadLevel("page1");
    }  
}
