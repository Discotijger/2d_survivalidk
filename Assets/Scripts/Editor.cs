using UnityEngine;
using UnityEngine.InputSystem;

public class EditorMenu : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject MbuttonO;
    [SerializeField] private GameObject MbuttonC;
    [SerializeField] private GameObject test;

    public Vector3 MousePos;

    void Update()
    {
        MousePos = Input.mousePosition;
    }


    public void eMenuOpen()
    {
        Menu.SetActive(true);
        MbuttonO.SetActive(false);
        MbuttonC.SetActive(true);
    }
    public void eMenuClose()
    {
        Menu.SetActive(false);
        MbuttonO.SetActive(true);
        MbuttonC.SetActive(false);
    }


    // // method used to run methods externaly
    // public void RunMethod(System.Action method)
    // {
    //     method?.Invoke();
    // }

    

    public void Object1()
    {
        Vector3 SpawnPos = new Vector3(MousePos.x, MousePos.y, 0f);
        Instantiate(test, SpawnPos, Quaternion.identity);
    }
}
