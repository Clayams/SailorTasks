using UnityEngine;

[CreateAssetMenu(fileName = "Tasks_SO", menuName = "Tasks/Tasks_SO")]
public class Tasks_SO : ScriptableObject
{
    public string taskName;
    public string taskDescription;
    
    public int energyCost;
    public float duration;
    
}
