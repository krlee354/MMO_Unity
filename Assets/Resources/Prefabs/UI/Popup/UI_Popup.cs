using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject, true); // gameObject�� �ѱ��, popup�̱� ������ sorting �ش޶�� ��û
    }

    public virtual void ClosePopupUI() // ClosePopupUI()�� ���ο��� ���� ����� �� �ֵ��� ������ֱ�
    {
        Managers.UI.ClosePopupUI(this); // ���� ����
    }
}