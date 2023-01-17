using System; // Type ����ϱ� ����
using System.Collections;
using System.Collections.Generic;
using TMPro; // TMP_Text ����ϱ� ����
using UnityEngine;
using UnityEngine.UI; // Text ����ϱ� ����

public class UI_Button : MonoBehaviour
{
    /*[SerializeField]
    TMP_Text _text; // == TextMeshProUGUI _text;*/ // Unity���� �������� �ʰ�, �ڵ忡�� �̸����� ã�� �����ҰŶ� �ʿ� ����

    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>(); // Button Type�� Button�� ��ϵ��� ��� �ְ�, Text Type�� Text�� ��ϵ��� ��� ����

   
    enum Buttons // Button Object ��� �ۼ�
    {
        PointButton
    }

    enum Texts // Text(TMP_Text) Object ��� �ۼ�
    {
        PointText,
        ScoreText
    }

    // Start is called before the first frame update
    void Start()
    {
        Bind<Button>(typeof(Buttons)); // Button Component(<Button>)�� ã�� �ش��ϴ� Object�� �����ض�
        //Bind<Text>(typeof(Texts)); // Text Component(<Text>)�� ã�� �ش��ϴ� Object�� �����ض�
        Bind<TMP_Text>(typeof(Texts)); // Text Component(<TMP_Text>)�� ã�� �ش��ϴ� Object�� �����ض�
        //Debug.Log($"{typeof(Buttons)}"); // UI_Button+Buttons
        //Debug.Log($"{typeof(Texts)}"); // UI_Button+Texts
    }

  
    void Bind<T>(Type type) where T : UnityEngine.Object // enum�� ��°�� �Ѱܹ����� ��ϵ��̶� ���� Object�� �������ִ� �Լ� // <T>, Button Component, Text(TMP_Text) Component�� ����ִ� Object�� ã������ ��Ʈ�� �ֱ� ����
    {
        string[] names = Enum.GetNames(type); // type���� �Ѱܹ��� enum�� ���� enum������ string���� ��ȯ�ؼ� �迭�� ����
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length]; // enum���� ������ŭ UnityEngine.Object�� �迭�� ������� // UnityEngine.Object���� ��� Object��(Text, Button ��)�� ���� ����
        _objects.Add(typeof(T), objects); // Key������ Type(Button, Text(TMP_Text) ��)�� �־��ְ�, Value������ objects�� �־��ֱ� // ��������ϸ� objects�� �� �迭 // Object���� ã�Ƽ� �־������

        // names�� ����ִ� Object�� �̸���� ���� Object�� ã�� �������ִ� ����
        for (int i = 0; i < names.Length; i++) // names�� ����ִ� Object���� �̸����� ����ŭ �ݺ�
        {
            objects[i] = Util.FindChild<T>(gameObject, names[i], true); // gameObject�� UI_Button Script�� �����ϰ��ִ� UI_Button Object�� �ǹ� // Texts - pointText�� ��쿡�� gameObject�� �ڽ��� �ڽ��̱� ������ ��ʹ� true������
        }
    }

    int _score = 0;

    public void OnButtonClicked() // public���� �ۼ��ؾ� Unity���� �Լ��� ��
    {
        Debug.Log("ButtonClicked!");

        _score++; // �ѹ� Ŭ���� �߻��� ������ 1�� ����
        //_text.text = $"���� : {_score}��";

    }
}