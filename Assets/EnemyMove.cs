using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyMove : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent myNavMeshAgent;
    public Transform[] points;
    int currentPoint = 0;
    public float chaseRange = 10;
    bool isChasing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        myNavMeshAgent.SetDestination(points[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        //myNavMeshAgent.SetDestination(player.transform.position);
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < chaseRange)
        {
            myNavMeshAgent.SetDestination(player.transform.position);
            isChasing = true;

        }
        else if (isChasing)
        {
            myNavMeshAgent.SetDestination(points[currentPoint].position);       
            isChasing = false;
        }

        if (myNavMeshAgent.remainingDistance < 0.5f & !isChasing)
        {
            GoToNextPoint();
        }
       
    }
    
    void GoToNextPoint()
    {
        currentPoint = (currentPoint + 1) % points.Length;
        myNavMeshAgent.SetDestination(points[currentPoint].position);
    }
    
}
