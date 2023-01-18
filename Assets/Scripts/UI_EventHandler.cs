using System; // Action ����ϱ� ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // IBeginDragHandler, IDragHandler ����ϱ� ����

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IDragHandler // IPointerClickHandler, IBeginDragHandler, IDragHandler - interface // IBeginDragHandler�� �ʿ��ϸ� �������� ����
{
    public Action<PointerEventData> OnClickHandler = null;
    //public Action<PointerEventData> OnBeginDragHandler = null; // �ʿ��ϸ� �߰��ϱ�
    public Action<PointerEventData> OnDragHandler = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClickHandler != null) // OnClickHandler�� �����ڰ� �ִٸ�
        {
            OnClickHandler.Invoke(eventData); // ������ ���� OnClickHandler �̺�Ʈ�� �־��ٰ� eventData�� �Բ� ����
        }
        //throw new NotImplementedException(); // interface �߰��� �� �ڵ� ������
    }

    /*public void OnBeginDrag(PointerEventData eventData) // �巡�׸� �����ϱ� ���� ��Ȳ�� �̺�Ʈ �߻�(Ŭ�������δ� �� �̺�Ʈ�� �߻����� ����)
    {
        if (OnBeginDragHandler != null) // OnBeginDragHandler�� �����ڰ� �ִٸ�
        {
            OnBeginDragHandler.Invoke(eventData); // ������ ���� OnBeginDragHandler �̺�Ʈ�� �־��ٰ� eventData�� �Բ� ����
        }
        //throw new System.NotImplementedException(); // interface �߰��� �� �ڵ� ������
    }*/ // �ʿ��ϸ� �߰��ϱ�

    public void OnDrag(PointerEventData eventData) // �巡�׸� �ϸ� �̺�Ʈ �߻�
    {
        if (OnDragHandler != null) // OnDragHandler�� �����ڰ� �ִٸ�
        {
            OnDragHandler.Invoke(eventData); // ������ ���� OnDragHandler �̺�Ʈ�� �־��ٰ� eventData�� �Բ� ����
        }
        //throw new System.NotImplementedException(); // interface �߰��� �� �ڵ� ������
    }
}