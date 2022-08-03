using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    [SerializeField] internal List<GameObject> unitList;
    [SerializeField] internal List<GameObject> unitsSelected;

    private void Awake()
    {
        unitList = new List<GameObject>();
        unitsSelected = new List<GameObject>();
    }

    private void OnEnable()
    {
        Unit.OnAddUnitToList += AddUnitToList;
        Unit.OnRemoveUnitToList += RemoveUnitToList;
        UnitClick.OnDeselecAllUnit += DeselectAll;
        UnitClick.OnShiftClickSelect += ShiftClickSelect;
        UnitClick.OnClickSelect += ClickSelect;
        UnitDrag.OnSelectUnits += SelectUnits;
    }

    internal void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();

        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.GetComponent<UnitMovement>().enabled = true;
    }

    internal void ShiftClickSelect(GameObject unitToAdd)
    {
        if(!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
        else
        {
            unitToAdd.GetComponent<UnitMovement>().enabled = false;
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitsSelected.Remove(unitToAdd);
        }
    }

    internal void DragClickSelect(GameObject unitToAdd)
    {
        if(!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
    }

    private void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
            unit.GetComponent<UnitMovement>().enabled = false;
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }

        unitsSelected.Clear();
    }

    private void AddUnitToList(GameObject objectUnit) => unitList.Add(objectUnit);
    private void RemoveUnitToList(GameObject objectUnit) => unitList.Add(objectUnit);

    private void SelectUnits(Rect selectionBox, Camera myCamera)
    {
        foreach (var unit in unitList)
        {
            if (selectionBox.Contains(myCamera.WorldToScreenPoint(unit.transform.position)))
            {
                DragClickSelect(unit);
            }
        }
    }

    private void OnDisable()
    {
        Unit.OnAddUnitToList -= AddUnitToList;
        Unit.OnRemoveUnitToList -= RemoveUnitToList;
        UnitClick.OnDeselecAllUnit -= DeselectAll;
        UnitClick.OnShiftClickSelect -= ShiftClickSelect;
        UnitClick.OnClickSelect -= ClickSelect;
        UnitDrag.OnSelectUnits -= SelectUnits;
    }
}
