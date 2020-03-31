using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{
    public Camera cam;

    private Vector3 destination;

    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        destination = new Vector3(Random.Range(-20, 40),0, Random.Range(-20, 40));
        
    }
    

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destination);
       // if(Input.GetMouseButton(0))
       // {
       //     Ray ray  =cam.ScreenPointToRay(Input.mousePosition);
       //     RaycastHit hit;
       //
       //     if(Physics.Raycast(ray,out hit))
       //     {
       //         agent.SetDestination(hit.point);
       //     }
       // }
    }
}
