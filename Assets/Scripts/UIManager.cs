using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 10; // �ֱٿ� ����� order�� ���� // scene�� order���� 0, sort���ٶ��� ���۰��� 0�̸� scene���� �������� ����, �׷��� ó�� ���۰��� 10(0�� �ƴѼ�)���� �����ϱ� // 0~9�� UI�� ���� ��������� �� �� ����ϸ� ��

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>(); // GameObject�� ��� �־ ������, �˾��� ������ �ִ� �� Script component�� UI_Popup�� �ٵ� ��ӹް� �ֱ� ������, UI_Popup component�� ��� �ִ� ���� ����
    UI_Scene _sceneUI = null; // �Ϲ� UI�� _sceneUI�� ����

    // UI���� �ϳ��� ���� �ȿ� ���� �; ������ ������ִ� ��� // ���� �����δ� ������ �ƴ�(�� ������Ʈ�� ���� ó�� ���)
    public GameObject Root // ������Ƽ�� ����
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root"); // �ش� Object�� ã��
            if (root == null) // Object�� ������
            {
                root = new GameObject { name = "@UI_Root" }; // ���� ������ֱ�
            }
            return root;
        }
    }
    public void SetCanvas(GameObject go, bool sort = true) // �ܺο��� �˾��� ��� ��, �� �˾� Canvas�� Sort Order�� ä���ִ� �Լ� // (Object, sort ����)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go); // Canvas Component ����
        canvas.renderMode = RenderMode.ScreenSpaceOverlay; // Render Mode�� ScreenSpaceOverlay�� �������
        canvas.overrideSorting = true; // ���� Canvas�� �ٸ� Canvas �ȿ� ��ø�ؼ� ������, �θ� � Sort Order ���� ������ �������, ���� Canvas���� Sort Order���� ���� ���̶� �ǹ�

        if (sort) // sort ��û�� �־��ٸ�(true)
        {
            canvas.sortingOrder = _order; // sortingOrder�� _order������ ���� ��
            _order++; // 1 ����
        }
        else // sort ��û�� �����ٸ�, ��, Popup�̶� �������� �Ϲ� UI���
        {
            canvas.sortingOrder = 0; // 0���� ����
        }
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene // �Ϲ� UI ���� // name�� Prefab�� �̸�, T�� Script(component)�� �̸� // T�� UI_Scene�� ��ӹ޴� Script��
    {
        if (string.IsNullOrEmpty(name)) // name�� �ȹ޾Ҵٸ�
        {
            name = typeof(T).Name; // T�� �̸����� name�� ����
        }

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}"); // Prefab���� ������ ���� Object�� go�� ����
        T sceneUI = Util.GetOrAddComponent<T>(go); // T Script component�� ã�ƿ� TŸ���� popup�� ����
        _sceneUI = sceneUI;
        //_order++; // ShowPopupUI�� ���� Popup�� ��� ���� �ƴ϶�, ������ ������ Scene�� ����� ���� ��쿡 ���� �߻�

        go.transform.SetParent(Root.transform); // go�� �θ�� root�� ����

        return sceneUI; // TŸ���� popup�� return
    }

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup // �˾� ���� // name�� Prefab�� �̸�, T�� Script(component)�� �̸� // T�� UI_Popup�� ��ӹ޴� Script��
    {
        if (string.IsNullOrEmpty(name)) // name�� �ȹ޾Ҵٸ�
        {
            name = typeof(T).Name; // T�� �̸����� name�� ����
        }

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}"); // Prefab���� ������ ���� Object�� go�� ����
        T popup = Util.GetOrAddComponent<T>(go); // T Script component�� ã�ƿ� TŸ���� popup�� ����
        _popupStack.Push(popup); // popup�� _popupStack�� ����
        //_order++; // ShowPopupUI�� ���� Popup�� ��� ���� �ƴ϶�, ������ ������ Scene�� ����� ���� ��쿡 ���� �߻�

        go.transform.SetParent(Root.transform); // go�� �θ�� root�� ����

        return popup; // TŸ���� popup�� return
    }

    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base // SubItem ����� // parent�� SubItem�� �� �θ��� transform, name�� Prefab�� �̸�, T�� Script(component)�� �̸� // T�� UI_Base�� ��ӹ޴� Script��
    {
        if (string.IsNullOrEmpty(name)) // name�� �ȹ޾Ҵٸ�
        {
            name = typeof(T).Name; // T�� �̸����� name�� ����
        }

        GameObject go = Managers.Resource.Instantiate($"UI/SubItem/{name}"); // Prefab���� ������ ���� Object�� go�� ����
        if (parent != null) // SubItem�� �� �θ��� transform ������ �־����ٸ�
        {
            go.transform.SetParent(parent); // go�� �θ� parent�� ����
        }

        return Util.GetOrAddComponent<T>(go); // T Script�� component�� �߰��ϸ� TŸ�� ��ȯ
    }

    public void ClosePopupUI(UI_Popup popup) // ���� �˾��� ������༭, ���� �˾��� popup�� �´��� Ȯ�� // �� �� �������� ����
    {
        if (_popupStack.Count == 0) // _popupStack�� �ƹ��͵� ���ٸ�
        {
            return; // �׳� return
        }

        if (_popupStack.Peek() != popup) // Peek�� ������ Popup�� ������ͼ�, popup�� ���ߴµ� �ٸ���
        {
            Debug.Log("Close Popup Failed!");
            return; // �׳� return
        }

        ClosePopupUI(); // ������� ������������ �˾� �׳� �ݱ�
    }

    public void ClosePopupUI() // �˾� �ݱ�
    {
        if (_popupStack.Count == 0) // _popupStack�� �ƹ��͵� ���ٸ�
        {
            return; // �׳� return
        }

        UI_Popup popup = _popupStack.Pop(); // ���� �ֱٿ� ��� popup�� ������ UI_PopupŸ���� popup�� ����
        Managers.Resource.Destroy(popup.gameObject); // popup���� Object�� ã�� ����
        popup = null; // popup�� ���������� �����ϸ� �ȵ�, Ȥ�� ���� null�� �ʱ�ȭ
        _order--;
    }

    public void CloseAllPopupUI() // ��� �˾��� �� �����
    {
        while (_popupStack.Count > 0) // _popupStack�� �ƹ��͵� ���� ������
        {
            ClosePopupUI();
        }
    }
}