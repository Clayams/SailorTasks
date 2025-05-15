using System;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    [Header("Task Components")]
    public GameObject HoverCircle;
    private Tasks_SO taskSO;
    
    [Header("Task Variables")]
    public float TaskDuration = 5f;


    public void SetCircle(bool b)
    {
        HoverCircle.SetActive(b);
    }
    
    
}
