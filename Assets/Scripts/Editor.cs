using UnityEngine;
using UnityEngine.InputSystem;

public class EditorMenu : MonoBehaviour
{
    [SerializeField] private GameObject _Menu;
    [SerializeField] private GameObject _MbuttonO;
    [SerializeField] private GameObject _MbuttonC;

    //objects to be placed
    [SerializeField] public GameObject _Object1;
    
    private GameObject buildingPrefab;

    public GameObject currentBuilding;
    // private bool placing;

    // Method for a singular Object
    // add different method and change "_Object1" to Object Added
    public void Object1()
    {
        buildingPrefab = _Object1;
        StartPlacing(buildingPrefab);
    }


    public void StartPlacing(GameObject buildingPrefab)
    {
        currentBuilding = buildingPrefab;

        if (buildingPrefab != null)
        Destroy(buildingPrefab);
        

        currentBuilding = Instantiate(buildingPrefab);
        Collider2D col = currentBuilding.GetComponent<Collider2D>();
        col.enabled = false;
    }


    void Update()
    {
        if (currentBuilding == null)
            return;

        // Follow mouse
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(
            Mouse.current.position.ReadValue()
        );

        MousePos.z = 0;
        currentBuilding.transform.position = MousePos;

        // Place building
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Instantiate(
                buildingPrefab,
                currentBuilding.transform.position,
                currentBuilding.transform.rotation
            );
        }

        // Cancel placement
        if (Mouse.current.middleButton.wasPressedThisFrame)
        {
            Destroy(currentBuilding);
            currentBuilding = null;
        }
    }


    public void eMenuOpen()
    {
        _Menu.SetActive(true);
        _MbuttonO.SetActive(false);
        _MbuttonC.SetActive(true);
    }
    public void eMenuClose()
    {
        _Menu.SetActive(false);
        _MbuttonO.SetActive(true);
        _MbuttonC.SetActive(false);
    }
}
