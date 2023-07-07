using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Seeker))]
public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float updateRate = 2f;  //pentru updatat path

    private Seeker seeker;
    private Rigidbody2D rb;

    //calculator path
    public Path path;

    //viteza AI/secunda
    public float speed = 300f;
    public ForceMode2D fMode;  //forta->impuls

    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWaypointDistance = 3;  //cat de aproape de la AI la waypoint pentru a continua

    private int currentWaypoint = 0;  //waypoint-ul catre care merg ??cred??

    private bool searchingForPlayer = false;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if(target == null)
        {
           if(!searchingForPlayer) 
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        StartCoroutine(UpdatePath());
    }

    IEnumerator SearchForPlayer() 
    {
        GameObject sResult = GameObject.FindGameObjectWithTag("Player");
        if(sResult == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchForPlayer());
        }
        else
        {
            target = sResult.transform;
            searchingForPlayer = false;
            StartCoroutine (UpdatePath());
            yield return false;
        }
    }

    IEnumerator UpdatePath() 
    {
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            yield return false;
        }
        //path now si returneaza-l la functia OPC
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }
    public void OnPathComplete(Path p)
    {
        Debug.Log("Avem un path." + p.error);
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }
        if(currentWaypoint >= path.vectorPath.Count)
        {
            if(pathIsEnded)
            {
                return;
            }
            Debug.Log("End of path");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if(dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }    
}
