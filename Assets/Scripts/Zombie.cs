
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Zombie : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navAgent;
    private Transform targetPos;
    private Animator anim;
    public float attackDistance = 1f;
    public float speed = 2f; 
    private float moveInterval = 5f; // 방향 변경 주기
    public float moveIntervalMin = 3f; // 최소 방향 변경 주기
    public float moveIntervalMax = 7f;
    private float timer; 
    private Vector3 randomDirection; 
    public float moveRadius = 10f; 
    private bool isPlayer;
    private bool isAttacking = false; 
    public float attackInterval = 2f; //  공격 간격

    void Start()
    {
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        SetRandomDestination();
        moveInterval = Random.Range(moveIntervalMin, moveIntervalMax);
    }

    void Update()
    {
        if (targetPos != null)
        {
            navAgent.SetDestination(targetPos.position);
            anim.SetBool("Walk", true);
            if (navAgent.remainingDistance <= attackDistance)
            {
                if (!isPlayer && !isAttacking) // 수정된 부분: isAttacking 체크 추가
                {
                    StartCoroutine(AttackRoutine()); // 수정된 부분: 코루틴 시작
                }
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
        }
        else
        {
            anim.SetBool("Walk", true);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Block"))
        {
            targetPos = collider.transform;
            isPlayer = false;
        }
        if (collider.CompareTag("Player"))
        {
            targetPos = collider.transform;
            isPlayer = true;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Block"))
        {
            targetPos = collider.transform;
            isPlayer = false;
        }

        if (collider.CompareTag("Player"))
        {
            targetPos = collider.transform;
            isPlayer = true;
        }
    }

    IEnumerator AttackRoutine() // 추가된 부분: 공격을 간격을 두고 반복하는 코루틴
    {
        isAttacking = true;
        anim.SetBool("Attack", true);

        while (targetPos != null)
        {
            Debug.Log("Attacking " + targetPos.name);
            Block block = targetPos.gameObject.GetComponent<Block>();
            block.Attacked();

            yield return new WaitForSeconds(attackInterval); // 공격 간격 대기

            if (targetPos.gameObject == null)
            {
                anim.SetBool("Attack", false);
                isAttacking = false;
                yield break;
            }
        }

       // anim.SetBool("Attack", false);
        isAttacking = false;
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