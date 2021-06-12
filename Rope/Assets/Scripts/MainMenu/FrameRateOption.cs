using UnityEngine;

public class FrameRateOption : MonoBehaviour
{
    // Just a simple script for frame rate limit, I basically erase everything that had any relation on chaging the frame rate based on a slider
    // I made it so it was more than good enough for all PCs, I highly doubt that there is potato machine so bad 
    // that i cannot run this simple game, c'mon cut me some slack, I'm not like yandere dev. -Keniak1-G9 12/June/2021
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
