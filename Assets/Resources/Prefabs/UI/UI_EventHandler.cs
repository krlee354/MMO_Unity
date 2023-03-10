using System; // Action 사용하기 위함
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // IBeginDragHandler, IDragHandler 사용하기 위함

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IDragHandler // IPointerClickHandler, IBeginDragHandler, IDragHandler - interface // IBeginDragHandler은 필요하면 쓰기위해 삭제
{
    public Action<PointerEventData> OnClickHandler = null;
    //public Action<PointerEventData> OnBeginDragHandler = null; // 필요하면 추가하기
    public Action<PointerEventData> OnDragHandler = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClickHandler != null) // OnClickHandler에 구독자가 있다면
        {
            OnClickHandler.Invoke(eventData); // 구독한 곳에 OnClickHandler 이벤트가 있었다고 eventData와 함께 전파
        }
        //throw new NotImplementedException(); // interface 추가할 때 자동 생성됨
    }

    /*public void OnBeginDrag(PointerEventData eventData) // 드래그를 시작하기 직전 상황에 이벤트 발생(클릭만으로는 이 이벤트가 발생하지 않음)
    {
        if (OnBeginDragHandler != null) // OnBeginDragHandler에 구독자가 있다면
        {
            OnBeginDragHandler.Invoke(eventData); // 구독한 곳에 OnBeginDragHandler 이벤트가 있었다고 eventData와 함께 전파
        }
        //throw new System.NotImplementedException(); // interface 추가할 때 자동 생성됨
    }*/ // 필요하면 추가하기

    public void OnDrag(PointerEventData eventData) // 드래그를 하면 이벤트 발생
    {
        if (OnDragHandler != null) // OnDragHandler에 구독자가 있다면
        {
            OnDragHandler.Invoke(eventData); // 구독한 곳에 OnDragHandler 이벤트가 있었다고 eventData와 함께 전파
        }
        //throw new System.NotImplementedException(); // interface 추가할 때 자동 생성됨
    }
}