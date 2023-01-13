using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView; // ī�޶� ��� ����

    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 8.0f, -6.0f); // ī�޶� �÷��̾�κ��� ���������� ��ġ

    [SerializeField]
    GameObject _player = null; // UnityChan(Player Object)�� �巡�� ������� �ֱ�

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void LateUpdate() // Player �̵� �� ī�޶� �̵��ϰ� �� // LateUpdate()�� Update()���� �ʰ� �����
    {
        if (_mode == Define.CameraMode.QuarterView) // ī�޶��尡 QuarterView�� ��
        {
            RaycastHit hit;
            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall"))) // (������ ������ġ, �������� ����, ������ �浹 ��ü, ������ �ִ� ����, Ư�� Layer�� ����) // ī�޶�� �÷��̾� ���̿� Wall�� �ִٸ�
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f; // (���� ��ġ���� - �÷��̾��� ��ġ���� = �÷��̾�� �� ������ �Ÿ�����)�� ũ���� 0.8�� // ī�޶� ��ġ ��Ű�� ���� �Ÿ� ũ��
                transform.position = _player.transform.position + _delta.normalized * dist; // �÷��̾� ��ġ + ī�޶� ������ �������� * ī�޶� ��ġ ��Ű�� ���� �Ÿ� ũ��
            }
            else
            {
                transform.position = _player.transform.position + _delta; // �÷��̾��� ��ġ���Ϳ� ī�޶� �÷��̾�κ��� ���������� ��ġ���͸� �����ֱ�
                transform.LookAt(_player.transform); // ���� ī�޶��� Rotation�� ���� �����ϴ� ���� �ƴ϶�(45���� �����߾���), �Լ��� �ش� Object�� ���Ѻ����� Rotation�� ��������
            }
        }
    }

    public void SetQuarterView(Vector3 delta) // ���߿� QuarterView�� �ڵ�� ������ ���� �ֱ� ������ �׳� �ۼ�
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}