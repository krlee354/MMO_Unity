using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject, true); // gameObject를 넘기며, popup이기 때문에 sorting 해달라고 요청
    }

    public virtual void ClosePopupUI() // ClosePopupUI()를 내부에서 쉽게 사용할 수 있도록 만들어주기
    {
        Managers.UI.ClosePopupUI(this); // 나를 종료
    }
}