using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject boss;
    public GameObject broomSymbol;
    private Animator animator;
    [SerializeField] Broom br;
    public Transform srOut;
    Vector3 srOutR;
    // Start is called before the first frame update
    void Start()
    {
        animator = boss.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        srOutR = srOut.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (br.bossPoint)
        {
            broomSymbol.SetActive(false);
            animator.SetBool("enter", true);
            agent.SetDestination(srOutR);
        }
    }
}

