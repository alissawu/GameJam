using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public Canvas[] canvases; // Array to store all the canvases

    public void SwitchCanvas(int canvasIndex)
    {
        // Loop through canvases and enable only the selected one
        for (int i = 0; i < canvases.Length; i++)
        {
            if (i == canvasIndex)
            {
                canvases[i].enabled = true; // Enable the canvas at the specified index
            }
            else
            {
                canvases[i].enabled = false; // Disable all other canvases
            }
        }
    }
}