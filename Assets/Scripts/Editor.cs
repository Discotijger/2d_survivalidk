using UnityEngine;
using UnityEngine.InputSystem;

public class EditorMenu : MonoBehaviour
{
    [SerializeField] private GameObject _Menu;
    [SerializeField] private GameObject _MbuttonO;
    [SerializeField] private GameObject _MbuttonC;

    //objects to be placed
    [SerializeField] public GameObject _Triangle;
    [SerializeField] public GameObject _Square;
    [SerializeField] public GameObject _Floor;
    
    private GameObject _buildingPrefab;

    public GameObject _currentBuilding;

    // Method for a singular Object
    // add different method and change "_Triangle" to Object Added
    public void Triangle()
    {
        _buildingPrefab = _Triangle;
        StartPlacing(_buildingPrefab);
    }
    public void Square()
    {
        _buildingPrefab = _Square;
        StartPlacing(_buildingPrefab);
    }
    public void WoodFloor()
    {
        _buildingPrefab = _Floor;
        StartPlacing(_buildingPrefab);
    }


    public void StartPlacing(GameObject buildingPrefab)
    {
        _currentBuilding = buildingPrefab;

        if (buildingPrefab != null)
        Destroy(buildingPrefab);
        

        _currentBuilding = Instantiate(buildingPrefab);
        Collider2D col = _currentBuilding.GetComponent<Collider2D>();
        if(col != null)
        col.enabled = false;
    }


    void Update()
    {

        if (_currentBuilding == null)
            return;

        // Follow mouse
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        // makes the ghost and placement on a grid

        MousePos.x = Mathf.Round(MousePos.x);
        MousePos.y = Mathf.Round(MousePos.y);
        MousePos.z = 0;

        _currentBuilding.transform.position = MousePos;

        // Place building
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Instantiate(_buildingPrefab, MousePos, _currentBuilding.transform.rotation);
        }

        // Cancel placement
        if (Mouse.current.middleButton.wasPressedThisFrame)
        {
            Destroy(_currentBuilding);
            _currentBuilding = null;
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
