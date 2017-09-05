using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    //웨이브, 진행 방식
    //미리 생성하고 소환(이펙트)?
    //웨이브 구별
    //1단계, 2단계 ... 1단계 3마리  , 2단계 5마리
    //단계 구별?
    
    [SerializeField]
    List<DummyFireGolem> enemyList = new List<DummyFireGolem>();

    [SerializeField]
    GameObject obj;

	// Use this for initialization
	void Start() {
        enemyList.Add(obj.GetComponent<DummyFireGolem>());
        Debug.Log(enemyList[0].attribute.maxHitPoint);
        Debug.Log(enemyList[0].attribute.nameTag);
        Debug.Log(enemyList[0].transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(enemyList[0].transform.position);
    }


    
}
