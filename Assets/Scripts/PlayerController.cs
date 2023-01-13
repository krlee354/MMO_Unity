using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float _speed = 15.0f;

    //bool _moveToDest = false; // �̵��� �̷� ������ bool���·� �����߾�����, state �������� ����
    Vector3 _destPos;

    // Start is called before the first frame update
    void Start()
    {
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    public enum PlayerState // Player�� ����
    {
        Die, // ����
        Moving, // ������
        Idle // ����
    }

    PlayerState _state = PlayerState.Idle; // �ʱ� ���¸� �������� ����

    void UpdateDie()
    {
        // �ƹ��͵� ����
    }

    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle; // ���� ����
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);

            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }

        // �ִϸ��̼�
        Animator anim = GetComponent<Animator>(); // Animator Component �ҷ�����
        // ���� ���ӻ��¿����� ���� �ִϸ������� �Ķ���ͷ� �ѱ��.
        anim.SetFloat("speed", _speed);
    }

    void UpdateIdle()
    {
        // �ִϸ��̼�
        Animator anim = GetComponent<Animator>(); // Animator Component �ҷ�����
        // ���� ���ӻ��¿����� ���� �ִϸ������� �Ķ���ͷ� �ѱ��.
        anim.SetFloat("speed", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //state ����
        switch (_state)
        {
            case PlayerState.Die: // ���� ���¶��
                UpdateDie();
                break;
            case PlayerState.Moving: // �����̴� ���¶��
                UpdateMoving();
                break;
            case PlayerState.Idle: // ���� ���¶��
                UpdateIdle();
                break;
        }
    }

    void OnMouseClicked(Define.MouseEvent e)
    {
        if (_state == PlayerState.Die) // ���� ���¶��
        {
            return; // ���콺 �̺�Ʈ�� �־ �׳� return
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving; // �����̴� ����
        }
    }
}
