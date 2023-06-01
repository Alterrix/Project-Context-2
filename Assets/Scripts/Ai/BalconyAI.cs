using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class BalconyAI : MonoBehaviour
{
    public GameObject agentWorker;
    public GameObject boss;
    public GameObject workersPush;
    public GameObject carEnd;
    public GameObject camBalcony;


    NavMeshAgent agentAIBoss;
    NavMeshAgent workerAi;
    private Animator workerAnim;
    private Animator bossAnim;

    public Transform runToEnd;
    public Transform runBackWorker;
    public Transform bossWalkIn;
    public Transform workerWalkBackSlow;
    public Transform bossPush;


    public DeathRoom deathRoom;
    public bool navmeshOff = true;

    Vector3 targetAiWorker;
    Vector3 targetAiBoss;


    // Start is called before the first frame update
    void Start()
    {
        workerAi = agentWorker.GetComponent<NavMeshAgent>();
        workerAnim = agentWorker.GetComponent<Animator>();
        agentAIBoss = boss.GetComponent<NavMeshAgent>();
        bossAnim = boss.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( !navmeshOff)
        {
            Invoke("WorkerRun", 3f);
            Invoke("Idle", 8f);
            Invoke("BossRun", 14f);
            Invoke("WorkerRunBack", 14f);
            Invoke("Idle2", 16.5f);
            Invoke("BossPoint", 18f);
            Invoke("WorkerWalkBack", 20f);
            Invoke("BossRunToWorker", 21f);
            Invoke("Idle3", 23f);
            Invoke("RotateTowardsBoss", 23f);
            Invoke("BossPushing", 24f);
            Invoke("BossPush", 26f); //26
            Invoke("ReloadScene", 34f);
        }

        
        {
            Invoke("WorkerFall", 27f);
        }
    }
    void Idle()
    {
        workerAnim.SetBool("idle", true);
        workerAnim.SetBool("run", false);
    }

    void Idle2()
    {
        workerAnim.SetBool("idle2", true);
    }
    void Idle3()
    {
        workerAnim.SetBool("idle3", true);
    }
    void WorkerRun()
    {
        targetAiWorker = runToEnd.position;
        workerAi.SetDestination(targetAiWorker);
    }

    void WorkerRunBack()
    {
        targetAiWorker = runBackWorker.position;
        workerAi.SetDestination(targetAiWorker);
        workerAnim.SetBool("run2", true);
    }

    void BossRun()
    {
        targetAiBoss = bossWalkIn.position;
        agentAIBoss.SetDestination(targetAiBoss);
        bossAnim.SetBool("run", true);
    }

    void BossPoint()
    {
        bossAnim.SetBool("run", false);
        bossAnim.SetBool("point", true);
    }

    void WorkerWalkBack()
    {
        //Play slow back animation
        workerAnim.SetBool("idle", false);
        workerAnim.SetBool("run3", true);
        targetAiWorker = workerWalkBackSlow.position;
        workerAi.SetDestination(targetAiWorker);
    }

    void BossRunToWorker()
    {
        targetAiBoss = bossPush.position;
        agentAIBoss.SetDestination(targetAiBoss);
        bossAnim.SetBool("point", false);
        bossAnim.SetBool("run2", true);
    }

    void BossPush()
    {
        workerAnim.SetBool("idle", false);
        workerAnim.SetBool("false", true);
        workerAnim.SetBool("pushed", true);
    }

    void RotateTowardsBoss()
    {
        agentWorker.GetComponent<RotateLook>().enabled = true; 
    }

    void BossPushing()
    {
        bossAnim.SetBool("point", false);
        bossAnim.SetBool("run", false);
        bossAnim.SetBool("push", true);
    }

    void WorkerFall()
    {
        camBalcony.GetComponent<Animator>().enabled = true;
        workersPush.SetActive(true);
        agentWorker.SetActive(false);
        workerAnim.SetBool("fall", true);
        Debug.Log("AppelSap");
        navmeshOff = true;
        carEnd.SetActive(true);
        //Play fall animation
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
