using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcInteractionManager : MonoBehaviour
{
    [HideInInspector]
    public static bool showInteractText;

    [HideInInspector]
    public static bool showSpeechText;

    [HideInInspector]
    public static bool showNightSpeechText;

    [HideInInspector]
    public static bool showEveningSpeechText;

    [HideInInspector]
    public static bool showMorningSpeechText;

    [SerializeField]
    private Text interactText;

    [SerializeField]
    private Text nightSpeechText;

    [SerializeField]
    private Text eveningSpeechText;

    [SerializeField]
    private Text morningSpeechText;

   

    // Update is called once per frame
    void Update()
    {
        if (showInteractText)
            interactText.gameObject.SetActive(true);
        else
            interactText.gameObject.SetActive(false);


        if (showEveningSpeechText)
            eveningSpeechText.gameObject.SetActive(true);
        else
            eveningSpeechText.gameObject.SetActive(false);


        if (showMorningSpeechText)
            morningSpeechText.gameObject.SetActive(true);
        else
            morningSpeechText.gameObject.SetActive(false);


        if (showNightSpeechText)
            nightSpeechText.gameObject.SetActive(true);
        else
            nightSpeechText.gameObject.SetActive(false);


    }
}
