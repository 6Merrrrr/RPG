using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle,
    Patrol,
    Chase,
    Attack,
    Dead
}
[RequireComponent(typeof(NavMeshAgent))]

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    
    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

}
