using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base
{
    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject, false); // gameObject를 넘기며, scene이기 때문에 sorting 하지말라고 요청
    }
}