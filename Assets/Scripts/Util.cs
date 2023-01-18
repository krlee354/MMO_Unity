using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component // �ش� Component�� ������ �޾ƿ���, ������ �߰��϶�� �Լ� // ������ �Է������ AddComponent<T>�� ���� �߻����� ����
    {
        T component = go.GetComponent<T>(); // TŸ���� component�� ã��
        if (component == null) // �ش� component�� ������
        {
            component = go.AddComponent<T>(); // TŸ���� component�� �߰��ϰ� component ������ �޾ƿ���
        }
        return component;
    }

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false) // GameObject ���� ���� // Generic ������ �ƴ϶� T������ ���ǹ��� �ʿ����
    {
        Transform transform = FindChild<Transform>(go, name, recursive); // ��� Object�� Transform component�� ������ �־��� ������ Transform���� ȣ��
        if (transform == null) // ��ã�Ҵٸ�
        {
            return null; // null�� return
        }
        return transform.gameObject; // ã������ transform�� ����, �� transform�� component�� �������ִ� Object return
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object // (�ֻ��� �θ�, �̸�, ��������� ã���� ����)�� �޾� TŸ���� component�� ���� object�� ã�� �Լ� // �̸��� �Է����� ������ �̸��� �������ʰ� TŸ�Կ��� �ش��ϸ� return, recursive - �ڽ��� �ڽı��� ã�� ������ ���� // T�� Object�� ����
    {
        if (go == null) // �ֻ��� ��ü�� null�̸�
        {
            return null; // null�� return
        }

        if (recursive == false) // ���� �ڽĸ� ã��
        {
            for (int i = 0; i < go.transform.childCount; i++) // gameObject�� �ڽ� ������ŭ ��ȸ
            {
                Transform transform = go.transform.GetChild(i); // gameObject�� �ڽ��� i��°�� �ش��ϴ� �ڽ��� ã��
                if (string.IsNullOrEmpty(name) || transform.name == name) // �̸��� �Է����� �ʾҰų�, transform�� �̸��� ã����� �̸��� ������
                {
                    T component = transform.GetComponent<T>(); // TŸ���� component�� ����ִ��� Ȯ��
                    if (component != null) // ������ TŸ���� component�� ����־�����
                    {
                        return component; // component�� return
                    }
                }
            }
        }
        else // �ڽ��� �ڽı��� ã��
        {
            foreach (T component in go.GetComponentsInChildren<T>()) // GameObject�� �����ִ� TŸ���� Object���� ��� ã��, ������ ��ȸ
            {
                if (string.IsNullOrEmpty(name) || component.name == name) // �̸��� �Է����� �ʾҰų�, component�� �̸��� ã����� �̸��� ������
                {
                    return component; // component�� return
                }
            }
        }

        return null; // ���������� ��ã������ null�� return
    }
}