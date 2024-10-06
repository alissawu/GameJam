using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelImageManager : MonoBehaviour
{
    public Image panelImage; // Reference to the UI Image component
    public Sprite[] stageImages; // Array to store images for each stage

    public void SetPanelImage(int stageIndex) {
        if (stageIndex >= 0 && stageIndex < stageImages.Length) {
            panelImage.sprite = stageImages[stageIndex]; // Change the image based on the stage
        } else {
            Debug.LogWarning("Invalid stage index for image");
        }
    }
}
