using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saphire_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Universal_Varible_Holder Outside_Variables;
    public GameObject player;

    void Start()
    {
        Outside_Variables = GameObject.Find("Universal_Variable_Holder").GetComponent<Universal_Varible_Holder>();
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
