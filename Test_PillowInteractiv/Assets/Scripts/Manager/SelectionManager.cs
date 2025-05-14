using System;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Camera camera;
    private Sailor selectedSailor;
    private Tasks lastTaskHover;
    

    private void Update()
    {
        GetSailorUnderCursor();
        MakeSelectedSailorMove();
        GetTaskUnderCursor();
    }

    private void GetSailorUnderCursor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Sailor sailor = hit.transform.GetComponentInChildren<Sailor>();
                if (sailor != null)
                {
                    SelectSailor(sailor);
                }
                else
                {
                    DeselectSailor();
                }
            }
            else
            {
                DeselectSailor();
            }
        }
    }

    private void MakeSelectedSailorMove()
    {
        
        if (Input.GetMouseButtonDown(1) && selectedSailor != null)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                selectedSailor.MoveTo(hit.point);
            }
        }
    }

    private void SelectSailor(Sailor sailor)
    {
        if (selectedSailor != null && selectedSailor != sailor)
        {
            selectedSailor.SetSelected(false);
        }

        selectedSailor = sailor;
        selectedSailor.SetSelected(true);
    }

    private void DeselectSailor()
    {
        if (selectedSailor != null)
        {
            selectedSailor.SetSelected(false);
            selectedSailor = null;
        }
    }

    private void GetTaskUnderCursor()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit);
        if(hit.collider.TryGetComponent<Tasks>(out Tasks task))
        {
            if (lastTaskHover != null && lastTaskHover != task)
            {
                lastTaskHover.SetCircle(false);
            }
            lastTaskHover = task;
            task.SetCircle(true);
        }
        else if (lastTaskHover != null)
        {
            lastTaskHover.SetCircle(false);
        }
        
        
    }
}