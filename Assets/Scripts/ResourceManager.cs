using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object // 경로에서 Object를 불러와서 넣기 // 일반화 // T는 Object면 된다는 조건 // 단순 랩핑
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null) // Instance 생성 메소드 // 메소드 랩핑
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null) // prefab을 찾을 수 없었다면
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null; // null 반환
        }

        GameObject go = Object.Instantiate(prefab, parent);
        int index = go.name.IndexOf("(Clone)"); // (Clone) 문자열이 있는지 찾고, 그 인덱스를 반환
        if (index > 0) // (Clone) 문자열이 있었다면
        {
            go.name = go.name.Substring(0, index); // 0번부터 index 전까지 잘라서 이름을 저장
        }

        return go;
    }

    public void Destroy(GameObject go, float f = 0.0f) // Object 삭제 메소드
    {
        if (go == null) // 없는 Object였다면
        {
            return; // 그냥 return
        }

        Object.Destroy(go, f);
    }
}