using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_Controller : MonoBehaviour
{
    public Universal_Varible_Holder Outside_Variables;
    public GameObject player;
    public Camera mainCamera;
    void Start(){
        Outside_Variables = GameObject.Find("Universal_Variable_Holder").GetComponent<Universal_Varible_Holder>();
        player = GameObject.FindWithTag("Player");
    }

    void Update(){
        
    }
}
