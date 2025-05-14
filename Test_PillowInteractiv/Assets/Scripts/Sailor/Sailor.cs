using System;
using UnityEngine;
using UnityEngine.AI;

public class Sailor : MonoBehaviour
{
    [Header("NavMesh")]
    private NavMeshAgent _agent;
    
    
    [Header("SailorComponent")]
    public GameObject SelectionCircle;
    
    

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void SetSelected(bool b)
    {
        SelectionCircle.SetActive(b);
    }

    public void MoveTo(Vector3 hitInfoPoint)
    {
        if (_agent != null)
        {
            _agent.SetDestination(hitInfoPoint);
        }
    }
}
