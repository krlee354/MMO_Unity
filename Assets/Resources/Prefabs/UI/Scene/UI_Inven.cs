using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel // UI_Inven Object�� �ڽ�
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);

        // �ݺ����� ���鼭 GridPanel�� ���� �ڽ��� �� �����ϴ� �ڵ�
        foreach (Transform child in gridPanel.transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }

        // ���� �κ��丮 ������ �����ؼ� ������������ �ӽ÷� ���� ����
        for (int i = 0; i < 8; i++)
        {
            /*GameObject item = Managers.Resource.Instantiate("UI/Scene/UI_Inven_Item"); // �����տ��� �������� �ҷ�����
            item.transform.SetParent(gridPanel.transform); // �ҷ��� �������� �θ� girdPanel�� ����

            //UI_Inven_Item invenitem = Util.GetOrAddComponent<UI_Inven_Item>(item); // item�� UI_Inven_Item Script Component �ٿ��ֱ�
            UI_Inven_Item invenitem = item.GetOrAddComponent<UI_Inven_Item>(); // �ٷ� ���ٰ� ����
            invenitem.SetInfo($"�����{i}��"); // item�� �̸� ����*/

            // MakeSubItem�� ����ϸ� ���ڵ带 ���� �� ����
            GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(gridPanel.transform).gameObject;
            item.GetComponent<UI_Inven_Item>().SetInfo($"�����{i}��");
        }
    }
}

