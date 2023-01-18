using System.Collections;
using System.Collections.Generic;
using TMPro; // TMP_Text ����ϱ� ����
using UnityEngine;
using UnityEngine.EventSystems; // PointerEventData ����ϱ� ����
using UnityEngine.UI; // Text ����ϱ� ����

public class UI_Button : UI_Base // ���������� MonoBehaviour�� ��ӹް�(UI_Base�� ��ӹް� ����) �ֱ� ������ Object�� Script Component�� ��� ����
{
    enum Buttons // Button Object ��� �ۼ�
    {
        PointButton
    }

    enum Texts // Text Object ��� �ۼ�
    {
        PointText,
        ScoreText
    }

    enum Images // Image Object ��� �ۼ�
    {
        ItemIcon
    }

    enum GameObjects // UI�� ���þ��� Object ��� �ۼ�
    {
        TestObject,
        //ScoreText
    }

    // Start is called before the first frame update
    void Start()
    {
        Bind<Button>(typeof(Buttons)); // Button Component(<Button>)�� ã�� �ش��ϴ� Object�� �����ض�
        //Bind<Text>(typeof(Texts)); // Text Component(<Text>)�� ã�� �ش��ϴ� Object�� �����ض�
        Bind<TMP_Text>(typeof(Texts)); // Text Component(<TMP_Text>)�� ã�� �ش��ϴ� Object�� �����ض�
        //Debug.Log($"{typeof(Buttons)}"); // UI_Button+Buttons
        //Debug.Log($"{typeof(Texts)}"); // UI_Button+Texts
        Bind<Image>(typeof(Images)); // Image Component(<Image>)�� ã�� �ش��ϴ� Object�� �����ض�
        Bind<GameObject>(typeof(GameObjects)); // GameObject Component(<GameObject>)�� ã�� �ش��ϴ� Object�� �����϶�� �ǹ�����, GameObject�� component�� �ƴ϶� ���� �߻� // FindChild �Լ� ���� �ʿ�

        //Get<Text>((int)Texts.ScoreText).text = "Bind Test"; // �Լ� �׽�Ʈ��
        //Get<TMP_Text>((int)Texts.ScoreText).text = "Bind Test"; // �Լ� �׽�Ʈ��
        //GetText((int)Texts.ScoreText).text = "Bind Test"; // �Լ� �׽�Ʈ��

        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked); // Extension Method�� ����ؼ� Button Ŭ�� �̺�Ʈ ����


        // UI_EventHandler���� �ٷ� �̺�Ʈ�� ȣ������ �ʰ�, ������������ ó����
        GameObject go = GetImage((int)Images.ItemIcon).gameObject; // Image Component�� ���� ItemIcon Object�� GameObject�� ��ȯ
        /*UI_EventHandler evt = go.GetComponent<UI_EventHandler>(); // Object�κ��� UI_EventHandler Component�� ã��
        evt.OnDragHandler += ((PointerEventData data) => { evt.gameObject.transform.position = data.position; }); // �Լ��� �����ϸ� ������û // evt.gameObject�� ItemIcon Object�� ã�� transform component�� ������*/

        // �ٷ� ���ڵ� ����ȭ
        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);

        // #���� // ���ذ� �ȵȴٸ� �� �κ��� �Ѿ��
        //Get<GameObject>((int)GameObjects.ScoreText).transform.GetComponent<TMP_Text>().text = "Bind Test2"; // ������ ���� ScoreText�� GameObject, GameObject�� ScoreText�� ã��, �ű⼭ TMP_Text Component�� ã�Ƽ�, �ؽ�Ʈ ���� ����
    }

    int _score = 0;

    public void OnButtonClicked(PointerEventData data) // public���� �ۼ��ؾ� Unity���� �Լ��� �� // PointerEventData�� �޾ƾ���
    {
        Debug.Log("ButtonClicked!");

        _score++; // �ѹ� Ŭ���� �߻��� ������ 1�� ����

        GetText((int)Texts.ScoreText).text = $"���� : {_score}��";
    }
}