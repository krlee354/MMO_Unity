using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum CameraMode
    {
        QuarterView
    }

    public enum MouseEvent
    {
        Press,
        Click
    }

    public enum UIEvent // UI 이벤트
    {
        Click, // 클릭
        Drag // 드래그
    }
}