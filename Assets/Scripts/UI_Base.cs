using System; // Type ����ϱ� ����
using System.Collections;
using System.Collections.Generic;
using TMPro; // TMP_Text ����ϱ� ����
using UnityEngine;
using UnityEngine.EventSystems; // PointerEventData ����ϱ� ����
using UnityEngine.UI; // Text ����ϱ� ����

public class UI_Base : MonoBehaviour // UI Canvas�� �ٴ� Script Component���� �θ�
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>(); // Button Type�� Button�� ��ϵ��� ��� �ְ�, Text Type�� Text�� ��ϵ��� ��� ����

    protected void Bind<T>(Type type) where T : UnityEngine.Object // enum�� ��°�� �Ѱܹ����� ��ϵ��̶� ���� Object�� �������ִ� �Լ� // <T>, Button Component, Text Component�� ����ִ� Object�� ã������ ��Ʈ�� �ֱ� ����
    {
        string[] names = Enum.GetNames(type); // type���� �Ѱܹ��� enum�� ���� enum������ string���� ��ȯ�ؼ� �迭�� ����
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length]; // enum���� ������ŭ UnityEngine.Object�� �迭�� ������� // UnityEngine.Object���� ��� Object��(Text, Button ��)�� ���� ����
        _objects.Add(typeof(T), objects); // Key������ Type(Text, Button ��)�� �־��ְ�, Value������ objects�� �־��ֱ� // ��������ϸ� objects�� �� �迭 // object���� ã�Ƽ� �־������

        // names�� ����ִ� object�� �̸���� ���� object�� ã�� �������ִ� ����
        for (int i = 0; i < names.Length; i++) // names�� ����ִ� object���� �̸����� ����ŭ �ݺ�
        {
            if (typeof(T) == typeof(GameObject)) // TŸ���� GameObject���
            {
                objects[i] = Util.FindChild(gameObject, names[i], true); // GameObject ���� ������ FindChild �Լ� ȣ��
            }
            else // TŸ���� Component���
            {
                objects[i] = Util.FindChild<T>(gameObject, names[i], true); // gameObject�� UI_Button Script�� �����ϰ��ִ� UI_Button Object�� �ǹ� // Texts - pointText�� ��쿡�� gameObject�� �ڽ��� �ڽ��̱� ������ ��ʹ� true������
            }

            if (objects[i] == null) // �ش� Object�� ��ã������
            {
                Debug.Log($"Failed to bind({names[i]}!"); // names[i]��� �̸��� ����, TŸ���� component�� ����ִ�, Object�� ��ã�Ҵٴ� �ǹ�
            }
        }
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object // �ε����� �ش��ϴ� TŸ���� component�� ���� Object��ȯ
    {
        UnityEngine.Object[] objects = null; // ������ Value���� �����ϱ� ���� Object�迭
        if (_objects.TryGetValue(typeof(T), out objects) == false) // TryGetValue�� Key���� �̿��� Value �����ϴ� ���� �����ߴٸ�
        {
            return null; // null�� return
        }

        return objects[idx] as T; // Object�迭���� �ε����� �ش��ϴ� Value�� ���� // TŸ������ ĳ�����ؼ�(������ ObjectŸ������ ����Ǿ��־��� ����) return
    }

    /*protected Text GetText(int idx)
    {
        return Get<Text>(idx);
    }*/

    protected TMP_Text GetText(int idx) // ���� ����ϱ� ������ ����ȭ ��Ŵ
    {
        return Get<TMP_Text>(idx);
    }

    protected Button GetButton(int idx) // ���� ����ϱ� ������ ����ȭ ��Ŵ
    {
        return Get<Button>(idx);
    }

    protected Image GetImage(int idx) // ���� ����ϱ� ������ ����ȭ ��Ŵ
    {
        return Get<Image>(idx);
    }

    public static void AddUIEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click) // UI Event�� �߰����ִ� �Լ� ���� // (GameObject, ������ų �Լ�(CallBack), ������ ���� �̺�Ʈ(�⺻�� Ŭ������ ����))
    {
        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go); // UI_EventHandler component�� ã�� ������ �߰��ؼ�, evt�� �޾ƿ�

        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action; // �ߺ� ���� ����
                evt.OnClickHandler += action; // action�� OnClickHandler�� ������Ŵ
                break;
            case Define.UIEvent.Drag:
                evt.OnDragHandler -= action; // �ߺ� ���� ����
                evt.OnDragHandler += action; // action�� OnDragHandler�� ������Ŵ
                break;
        }
    }
}