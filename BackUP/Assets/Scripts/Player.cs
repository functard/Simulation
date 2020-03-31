using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool npcNearby;

    private bool interactPressed;

    // Update is called once per frame
    void Update()
    {
       

        //if near npc and e pressed
        if (npcNearby && Input.GetKeyDown(KeyCode.E))
        {
            //if evening
            if (DayNightCycle.time / 6 >= 17)
                NpcInteractionManager.showEveningSpeechText = true;

            //if night
            else if (DayNightCycle.time / 6 <= 5)
                NpcInteractionManager.showNightSpeechText = true;

            //if morning
            else
                NpcInteractionManager.showMorningSpeechText = true;

            //close interact text
            NpcInteractionManager.showInteractText = false;
            interactPressed = true;
        }

        //if npc nearby
        if (npcNearby && !interactPressed)
        {
            //show interact text
            NpcInteractionManager.showInteractText = true;

            npcNearby = true;
        }

        //if both npc and guidenpc is not nearby
        if(!npcNearby && !GuideNpc.playerNearby)
        {   
            //reset texts
            NpcInteractionManager.showInteractText = false;
            NpcInteractionManager.showMorningSpeechText = false;
            NpcInteractionManager.showEveningSpeechText = false;
            NpcInteractionManager.showNightSpeechText = false;
            NpcInteractionManager.showSpeechText = false;

        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        //if near player
        if (other.tag == "Npc")
        {
            //show speech bubble
            other.GetComponent<SpeechBubble>().speechBuubleText.gameObject.SetActive(true);

            npcNearby = true;
        }

        //if pizzaa taken
        if(other.tag == "Pizza" && !MySceneManager.gameLost)
        {
            //WON
            MySceneManager.gameWon = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if player not near
        if (other.tag == "Npc")
        {
            //close speech bubble
            other.GetComponent<SpeechBubble>().speechBuubleText.gameObject.SetActive(false);

            npcNearby = false;

            interactPressed = false;
        }

        

    }
}