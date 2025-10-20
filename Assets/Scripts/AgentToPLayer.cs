using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentToPLayer : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("stats")]
    public float speed;


    [Header("GameObjects, and transforms")]
    public GameObject target;
    // Update is called once per frame
   
    void Start()
    {
       
    }
    void Update()
    {
        ToPLayer();
    }
    
    private void ToPLayer()
    {
          NavMeshAgent agent;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.transform.position * speed;
    }
}
