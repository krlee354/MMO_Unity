using System; // Action 사용하기 위함
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // PointerEventData 사용하기 위함

public static class Extension // Extension Method 만들기 // Extension class를 만들때는 static이 필요, MonoBehaviour은 필요없음
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component // 해당 Component가 있으면 받아오고, 없으면 추가하라는 함수 // 조건을 입력해줘야 AddComponent<T>에 오류 발생하지 않음
    {
        /* 사용방법 */
        //go.GetOrAddComponent<T>(go);
        // Extention 메소드가 그냥 static 메소드가 아닌 확장 메서드로 인식되는 이유는 첫번째 파라미터에 this가 붙기 때문이다.
        // 여기서 this는 2가지 역할을 한다, 
        // 1. 어느 클래스의 확장 메서드가 될지 결정한다.
        // 2. 해당되는 클래스의 객체를 불러온다.

        return Util.GetOrAddComponent<T>(go);
    }

    public static void BindEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click) // UI Event를 추가해주는 함수 정의 // (GameObject, 구독시킬 함수(CallBack), 구독을 받을 이벤트(기본은 클릭으로 설정))
    {
        /* 사용방법 */
        //go.BindEvent(action);

        UI_Base.BindEvent(go, action, type);
    }
}