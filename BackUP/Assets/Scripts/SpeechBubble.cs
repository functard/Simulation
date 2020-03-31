using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField]
    private Transform namePos;

    [SerializeField]
    public Text speechBuubleText;


    // Update is called once per frame
    void Update()
    {
        //change to screen point
        Vector3 tmp = Camera.main.WorldToScreenPoint(namePos.transform.position);
        speechBuubleText.transform.position = tmp;

    }
}
