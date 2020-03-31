using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    private Vector3 destination;

    [SerializeField]
    private NavMeshAgent agent;

    void Start()
    {
        //set destination
        destination = GenerateRandomDestination();

        //move
        agent.SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        //if agent stopped for some reason
        if(agent.velocity == Vector3.zero && !Player.npcNearby)
        {
            //set new destination
            destination = GenerateRandomDestination();
            
            //move
            agent.SetDestination(destination);
        }

        //if destination reached
        if(transform.position.z == destination.z && transform.position.x == destination.x)
        {
            
            //set destination
            destination = GenerateRandomDestination();
            //move
            agent.SetDestination(destination);
        }

        // if player interacts
        if(NpcInteractionManager.showSpeechText)
            transform.LookAt(GameObject.Find("Player").transform);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if near player
        if(other.tag == "Player")
        {
            //set angular speed to 0 to make sure npc doesnt turn back
            agent.angularSpeed = 0;
            //stop
            agent.isStopped = true;
            //look at player
            transform.LookAt(GameObject.Find("Player").transform);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if player not near
        if(other.tag == "Player")
        {
            //set angular speed back to normal
            agent.angularSpeed = 120;
            //move
            agent.isStopped = false;

        }
    }

    
    Vector3 GenerateRandomDestination()
    {
        return new Vector3(Random.Range(0, 75), 1, Random.Range(0, 75));
    }
}
