using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object // �Ϲ�ȭ�� ���� ���Ļ���
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null) // ������Ʈ ����
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        return Object.Instantiate(prefab, parent);
    }

    public void Destroy(GameObject go, float f) // ������Ʈ �Ҹ�
    {
        if (go == null)
        {
            return;
        }

        Object.Destroy(go, f);
    }
}