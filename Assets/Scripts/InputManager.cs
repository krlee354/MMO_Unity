using System; // Action ����ϱ� ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // EventSystem ����ϱ� ����

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool _pressed = false;

    public void OnUpdate()
    {
        // UI�� Ŭ���ص� ��� �̺�Ʈ�� �߻���Ű�� ������ ĳ���Ͱ� �̵��ϴ� ��Ȳ�� �����ϱ� ���� �߰�
        if (EventSystem.current.IsPointerOverGameObject()) // UI Object�� Ŭ���Ǿ��ٸ�
        {
            return; // �׳� return
        }

        if (Input.anyKey && KeyAction != null)
        {
            KeyAction.Invoke();
        }

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if (_pressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                }
                _pressed = false;
            }
        }
    }
}