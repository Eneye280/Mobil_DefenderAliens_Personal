using System;
using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    internal static event Action<Rect, Camera> OnSelectUnits;

    [SerializeField] private Camera myCamera;

    [SerializeField] private RectTransform rectBoxVisual;

    private Rect selectionBox;

    private Vector2 startPosition;
    private Vector2 endPosition;
    private Vector2 extents;
    private Vector2 boxCenter;
    private Vector2 boxSize;

    private void Start()
    {
        myCamera = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;

        DragVisual();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            selectionBox = new Rect();
        }

        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            DragVisual();
            DrawSelection();
        }

        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DragVisual();
        }
    }

    private void DragVisual()
    {
        boxCenter = (startPosition + endPosition) / 2;
        rectBoxVisual.position = boxCenter;

        boxSize = new Vector2(Mathf.Abs(startPosition.x - endPosition.x), Mathf.Abs(startPosition.y - endPosition.y));
        rectBoxVisual.sizeDelta = boxSize;

        extents = boxSize / 2;
    }
    private void DrawSelection()
    {
        selectionBox.min = boxCenter - extents;
        selectionBox.max = boxCenter + extents;
        //if(Input.mousePosition.x < startPosition.x)
        //{
        //    selectionBox.xMin = Input.mousePosition.x;
        //    selectionBox.xMax = startPosition.x;
        //}
        //else
        //{
        //    selectionBox.xMin = startPosition.x;
        //    selectionBox.xMax = Input.mousePosition.x;
        //}

        //if (Input.mousePosition.y < startPosition.y)
        //{
        //    selectionBox.yMin = Input.mousePosition.y;
        //    selectionBox.yMax = startPosition.y;
        //}
        //else
        //{
        //    selectionBox.yMin = startPosition.y;
        //    selectionBox.yMax = Input.mousePosition.y;
        //}
    }

    private void SelectUnits()
    {
        OnSelectUnits?.Invoke(selectionBox, myCamera);
    }
} 
