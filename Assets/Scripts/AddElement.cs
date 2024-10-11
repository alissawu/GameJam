using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddElement : MonoBehaviour
{
    public GameObject[] objects;
    int clickNum = -1;
    public int numQuestions;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()

    {
        
        //if (Input.GetMouseButtonDown(0)){
            //clickNum = (clickNum + 1) % numQuestions;
        //}
        if (clickNum >= 0) {
            objects[clickNum].SetActive(true);
        }

    }
    void TaskOnClick()
    {
        clickNum = (clickNum + 1) % numQuestions;
    }
}
