using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object // ��ο��� Object�� �ҷ��ͼ� �ֱ� // �Ϲ�ȭ // T�� Object�� �ȴٴ� ���� // �ܼ� ����
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null) // Instance ���� �޼ҵ� // �޼ҵ� ����
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null) // prefab�� ã�� �� �����ٸ�
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null; // null ��ȯ
        }

        GameObject go = Object.Instantiate(prefab, parent);
        int index = go.name.IndexOf("(Clone)"); // (Clone) ���ڿ��� �ִ��� ã��, �� �ε����� ��ȯ
        if (index > 0) // (Clone) ���ڿ��� �־��ٸ�
        {
            go.name = go.name.Substring(0, index); // 0������ index ������ �߶� �̸��� ����
        }

        return go;
    }

    public void Destroy(GameObject go, float f = 0.0f) // Object ���� �޼ҵ�
    {
        if (go == null) // ���� Object���ٸ�
        {
            return; // �׳� return
        }

        Object.Destroy(go, f);
    }
}