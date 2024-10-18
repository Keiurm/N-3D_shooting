using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyMovement : MonoBehaviour
{
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.position);
    }
}
