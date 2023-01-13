using System; // Action ����ϱ� ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool _pressed = false; // ���콺 ���� ����

    // Update is called once per frame
    public void OnUpdate()
    {
        /*if (Input.anyKey == false)
        {
            return;
        }*/ // ���콺 �Է��� ������ ��츦 �����ϱ� ���� �ٷ� �Ʒ� �ڵ�� ��ħ

        if (Input.anyKey && KeyAction != null) // ��� Key �Է��� �־���, KeyAction�� �־��ٸ�
        {
            KeyAction.Invoke(); // ������ ���� KeyAction�� �־��ٰ� ����
        }

        if (MouseAction != null) // MouseAction�� �־��ٸ�
        {
            if (Input.GetMouseButton(0)) // ���� ���콺 ��ư�� ������ ��
            {
                MouseAction.Invoke(Define.MouseEvent.Press); // ������ ���� Press�̺�Ʈ��� ����
                _pressed = true; // ���콺 ���ȴٰ� ����
            }
            else // ���� ���콺 ��ư�� ���� ��
            {
                if (_pressed) // ������� ���콺�� ������ �־��ٸ�
                {
                    MouseAction.Invoke(Define.MouseEvent.Click); // ������ ���� Click�̺�Ʈ��� ����
                }
                _pressed = false; // �ٽ� ���콺 ������ ���� ������ ����
            }
        }
    }
}