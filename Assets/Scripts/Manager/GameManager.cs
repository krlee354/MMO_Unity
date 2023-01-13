using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ---------------------------
    // �̱��� ���� ����
    //----------------------------
    static GameManager Instance; // static ���� ������ ���� ���ϼ� ����
    public static GameManager GetInstance { get{ return Instance; } } // GetInstance ������Ƽ�� ���� �ٸ� ��ũ��Ʈ���� Instance�� ���� �� �� �ִ�.
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void Init() // 
    {
        if (Instance == null)
        {
            GameObject go = GameObject.Find("GameManager");
            if (go == null)
            {
                go = new GameObject { name = "GameManager" };
                go.AddComponent<GameManager>();
            }
            DontDestroyOnLoad(go);
            Instance = go.GetComponent<GameManager>();
        }
        
    }
}
