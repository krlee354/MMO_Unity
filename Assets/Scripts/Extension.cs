using System; // Action ����ϱ� ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // PointerEventData ����ϱ� ����

public static class Extension // Extension Method ����� // Extension class�� ���鶧�� static�� �ʿ�, MonoBehaviour�� �ʿ����
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component // �ش� Component�� ������ �޾ƿ���, ������ �߰��϶�� �Լ� // ������ �Է������ AddComponent<T>�� ���� �߻����� ����
    {
        /* ����� */
        //go.GetOrAddComponent<T>(go);
        // Extention �޼ҵ尡 �׳� static �޼ҵ尡 �ƴ� Ȯ�� �޼���� �νĵǴ� ������ ù��° �Ķ���Ϳ� this�� �ٱ� �����̴�.
        // ���⼭ this�� 2���� ������ �Ѵ�, 
        // 1. ��� Ŭ������ Ȯ�� �޼��尡 ���� �����Ѵ�.
        // 2. �ش�Ǵ� Ŭ������ ��ü�� �ҷ��´�.

        return Util.GetOrAddComponent<T>(go);
    }

    public static void BindEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click) // UI Event�� �߰����ִ� �Լ� ���� // (GameObject, ������ų �Լ�(CallBack), ������ ���� �̺�Ʈ(�⺻�� Ŭ������ ����))
    {
        /* ����� */
        //go.BindEvent(action);

        UI_Base.BindEvent(go, action, type);
    }
}