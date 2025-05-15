using UnityEngine;
using UnityEngine.AI;

public class Sailor : MonoBehaviour
{
    [Header("NavMesh")]
    private NavMeshAgent _agent;
    
    
    [Header("SailorComponent")]
    public GameObject selectionCircle;
    public Transform sleepPoint;
    
    [Header("Sailor Variables")]
    public float energy = 0;
    public float energyReduction = 5;
    
    private SailorState _currentState = SailorState.Idle;
    
    

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        switch (_currentState)
        {
            case SailorState.Idle:
                IdleUdpate();
                break;
            case SailorState.Tasking:
                TaskingUpdate();
                break;
            case SailorState.Resting:
                RestUpdate();
                break;
        }
    }


    public void SetSelected(bool b) // Set the circle active or not if the sailor is selected.
    {
        selectionCircle.SetActive(b);
    }

    public void MoveTo(Vector3 hitInfoPoint) //Move the sailor to the cursor position using the NavMeshAgent.
    {
        if (_agent != null)
        {
            _agent.SetDestination(hitInfoPoint);
        }
    }
    
    private void IdleUdpate()
    {
        // Do Nothing, TODO Patrolling
    }
    
    private void TaskingUpdate()
    {
        if (energy < 100)
        {
            _currentState = SailorState.Resting;
        }
        else 
        {
            // TODO Do Task
        }
    }
    
    private void RestUpdate()
    {
        GoToSleepPoint();
        if (energy < 0)
        {
            _currentState = SailorState.Idle;
        }
        else
        {
            energy -= energyReduction * Time.deltaTime;
            energy = Mathf.Clamp(energy, 0, 100);
        }
    }

    private void GoToSleepPoint()
    {
        _agent.SetDestination(sleepPoint.position);
    }
    
    // public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) 
    // {
    //     Vector3 randDirection = Random.insideUnitSphere * dist;
    //
    //     randDirection += origin;
    //
    //     NavMeshHit navHit;
    //
    //     NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
    //
    //     return navHit.position;
    // }
    
}


public enum SailorState
{
    Idle,
    Tasking,
    Resting,
}