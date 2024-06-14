

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navAgent;
    private Transform targetPos;
    private Animator anim;
    public float attackDistance = 1f;

    public float speed = 2f; 
    private float moveInterval = 5f; //방향변경주기
    public float moveIntervalMin = 3f; //최소 방향변경 주기
    public float moveIntervalMax = 7f;

    private float timer; 
    private Vector3 randomDirection; 
     public float moveRadius = 10f; 

    void Start()
    {
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
         SetRandomDestination();
         moveInterval = Random.Range(moveIntervalMin, moveIntervalMax);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (targetPos != null)
        {
            navAgent.SetDestination(targetPos.position);
            anim.SetBool("Walk", true);
            if (navAgent.remainingDistance <= attackDistance)
            {
                Attack();
            }
        }
        
        timer += Time.deltaTime;
        if (timer >= moveInterval)
        {
            SetRandomDestination();
            timer = 0f;
        }
       
       if (navAgent.velocity.magnitude <= 0.1f)
        {
          
          anim.SetBool("Walk", false);
        }else{
          anim.SetBool("Walk", true);
        }
   
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Block"))
        {
            targetPos = collider.transform;
           
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Block"))
        {
            targetPos = collider.transform;
           
        }
    }

    void Attack()
    {
        if (targetPos != null)
        {
            Debug.Log("Attacking " + targetPos.name);
            anim.SetBool("Attack", true);
            //anim.SetBool("Walk", false);
            Destroy(targetPos.gameObject);
            if(targetPos.gameObject==null){
                
                anim.SetBool("Attack", false);
            }
        }
    }

   
     void SetRandomDestination()
    {
        anim.SetBool("Walk", true);
        anim.SetBool("Attack", false);
        Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
        randomDirection += transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, moveRadius, 1);
        Vector3 finalPosition = hit.position;
        navAgent.SetDestination(finalPosition);
    }
}