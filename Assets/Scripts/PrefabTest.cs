using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
   
    GameObject tank;

    // Start is called before the first frame update
    void Start()
    {
        tank = Managers.Resource.Instantiate("Tank"); // ResourceManager�� �ִ� �����Լ� ȣ��

        /*prefab = Resources.Load<GameObject>("Prefabs/Tank"); 
        tank = Instantiate(prefab); */


        Managers.Resource.Destroy(tank, 3.0f); //ResourceManager�� �ִ� �Ҹ��Լ� ȣ��
    }

  
}