using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Inventory_UI;
    public GameObject Challenge_Text;

    public Universal_Varible_Holder Outside_Variables;
    void Start(){
        Inventory_UI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Outside_Variables = GameObject.Find("Universal_Variable_Holder").GetComponent<Universal_Varible_Holder>();
        if(Input.GetKeyDown(KeyCode.V)){
            Inventory_UI.SetActive(true);
            Debug.Log("Inventory Open");
            Outside_Variables.Is_In_Inventory = true;
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Inventory_UI.SetActive(false);
            Debug.Log("Inventory Close");
            Outside_Variables.Is_In_Inventory = false;
        }
    }

}
