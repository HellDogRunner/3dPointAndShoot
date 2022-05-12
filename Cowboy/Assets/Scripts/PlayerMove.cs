using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private int stopRange = 5;

    private float _distance;
    private NavMeshAgent _agent;
    private Animator _anim;
     private int _currentWP;

    private void Awake()
    {
        _agent = player.GetComponent<NavMeshAgent>();
        _anim = player.GetComponent<Animator>();
        _currentWP = 0;
    }
    private void FixedUpdate()
    {
        move(); 
    }


    private void move()
    {
        _distance = Vector3.Distance(FindClosestEnemy().transform.position, player.transform.position);
        if (_distance <= stopRange&& _distance != 0)
        {
            _agent.isStopped = true;
            Idle();
        }
        else
        {
            Run();
            _agent.isStopped = false;
        if (waypoints.Length == 0) return;
        if (Vector3.Distance(waypoints[_currentWP].transform.position,
                            player.transform.position) < 1.0f)
        {
                if (_currentWP + 1 >= waypoints.Length)
                {
                    _agent.isStopped = true;
                    Idle();
                }
                else _currentWP++;

        }
                _agent.SetDestination(waypoints[_currentWP].transform.position);
        }
    }
    private void Idle() {
        _anim.ResetTrigger("Run");
        _anim.SetTrigger("Idle");

    }
    private void Run()
    {
        _anim.SetTrigger("Run");
        _anim.ResetTrigger("Idle");

    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            _distance = 0;
            return player;
        }
        GameObject closest;
        if (enemies.Length == 1)
        {
            closest = enemies[0];
            return closest;
        }

        // Otherwise: Take the enemies
        closest = enemies
            // Order them by distance (ascending) => smallest distance is first element
            .OrderBy(go => (player.transform.position - go.transform.position).sqrMagnitude)
            // Get the first element
            .First();
        return closest;
    }

}
