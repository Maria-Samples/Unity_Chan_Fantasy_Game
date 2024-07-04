using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Bar_Controller : MonoBehaviour
{
    public GameObject[] Hearts;
    public GameObject Player;
    void Start(){
        
    }
    void Update(){
        
    }
    IEnumerator Damage(int amount){
        int i = 0;
        while(i < amount){
            for(int x = Hearts.Length-1; x > -1; x--){
                if(Hearts[x].activeSelf){
                    Hearts[x].SetActive(false);
                    break;
                }else if(Hearts[0].activeSelf == false){
                    Destroy(Player);
                }
            }
            i++;
        }
        yield return null;
    }
}
