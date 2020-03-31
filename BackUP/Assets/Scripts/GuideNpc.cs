using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GuideNpc : MonoBehaviour
{
    private GameObject player;

    private bool followAceepted;

    [SerializeField]
    private GameObject pizza;

    NavMeshAgent agent;

    [HideInInspector]
    public static bool playerNearby;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //move to player
        if (!followAceepted)
            agent.SetDestination(player.transform.position);

        //if player found and player interacted
        if(playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            //set speech bubble
            GetComponent<SpeechBubble>().speechBuubleText.text = " Follow me";

            //go to destination
            agent.SetDestination(new Vector3(90,1,100));

            //move agent
            agent.isStopped = false;

            //player following
            followAceepted = true;
        }

        //if destination reached
        if (agent.transform.position.x == 90 && agent.transform.position.z == 100)
        {
            //change bubble text
            GetComponent<SpeechBubble>().speechBuubleText.text = " Eat this";

            //set offset
            Vector3 tmpOffSet = new Vector3(5, 0, 5);

            //spawn pizza
            Instantiate(pizza,transform.position + tmpOffSet,Quaternion.identity);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //if player near
        if (other.gameObject.tag == "Player")
        {
            //show speech bubble
            GetComponent<SpeechBubble>().speechBuubleText.gameObject.SetActive(true);

            //if player isnt following yet
            if(!followAceepted)
            {
                //stop
                 agent.isStopped = true;

                //show interact text
                 NpcInteractionManager.showInteractText = true;

            }
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if player is not nearby
        if (other.gameObject.tag == "Player")
        {
            //remove speech bubble
            GetComponent<SpeechBubble>().speechBuubleText.gameObject.SetActive(false);

            //remove interact text
            NpcInteractionManager.showInteractText = false;
            playerNearby = false;


            if (!followAceepted)
                agent.isStopped = false;
        }
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1f);    
    }
}
