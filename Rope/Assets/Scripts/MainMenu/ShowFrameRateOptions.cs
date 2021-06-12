using UnityEngine;
using UnityEngine.UI;

// Description of the Script:
// This Script grabs the label text of the Frame Rate Settings and changes it depending on the slider


public class ShowFrameRateOptions : MonoBehaviour
{

    public Text Label;

    // Update is called once per frame
    void Update()
    {
        string Text = Label.text;
    }
}
