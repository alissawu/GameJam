using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Quiz");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject startCanvas;  // Drag the start canvas in the inspector
    public GameObject nextCanvas;   // Drag the next canvas in the inspector

    // Link to the button's OnClick event


}
