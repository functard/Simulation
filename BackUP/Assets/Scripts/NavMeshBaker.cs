using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface surface;
    // Start is called before the first frame update
    void Start()
    {
        //build nav mesh on runtime
        surface.BuildNavMesh();
    }

}
