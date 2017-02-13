using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {
    public float amountStones;
    float perc;
    GameObject r_01;
    GameObject r_02;
    GameObject r_03;
    GameObject r_04;
    GameObject currentObj;
    public float stonesPerHit;
    void Start () {
        
        amountStones = Random.Range(100, 200);
        perc = amountStones;
        r_01 = transform.Find("rock_01").gameObject;
        r_02 = transform.Find("rock_02").gameObject;
        r_03 = transform.Find("rock_03").gameObject;
        r_04 = transform.Find("rock_04").gameObject;
        r_02.SetActive(false);
        r_03.SetActive(false);
        r_04.SetActive(false);
        currentObj = r_01;

        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
    }
	
    public void UpdateStone()
    {
        //currentObj.transform.localScale -= new Vector3(0.01F / perc, 0.01F / perc, 0.01F);
        if (amountStones <= perc * 0.8 && amountStones > perc * 0.6)
        {
            r_01.SetActive(false);
            r_02.SetActive(true);
            currentObj = r_02;
            
        }
        else if(amountStones <= perc * 0.6 && amountStones > perc * 0.4)
        {
            currentObj.SetActive(false);
            r_03.SetActive(true);
            currentObj = r_03;
        }
        else if (amountStones <= perc * 0.4)
        {
            currentObj.SetActive(false);
            r_04.SetActive(true);
            currentObj = r_04;
        }

        if (amountStones <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
