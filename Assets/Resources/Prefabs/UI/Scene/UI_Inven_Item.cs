using System.Collections;
using System.Collections.Generic;
using TMPro; // TMP_Text ����ϱ� ����
using UnityEngine;

public class UI_Inven_Item : UI_Base
{
    enum GameObjects
    {
        ItemIcon,
        ItemNameText
    }

    string _name;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<TMP_Text>().text = _name; // text�� _name���� ����

        Get<GameObject>((int)GameObjects.ItemIcon).AddUIEvent((PointerEventData) => { Debug.Log($"������ Ŭ��! {_name}"); }); // ������ Ŭ���ϸ� �α� ���
    }

    public void SetInfo(string name) // �ܺο��� �̸��� �����ϴ� �Լ�
    {
        _name = name; // �޾ƿ� �̸��� _name�� ����
    }
}