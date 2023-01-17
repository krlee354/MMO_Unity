using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object // (최상위 부모, 이름, 재귀적으로 찾을지 여부)를 받아 T타입의 component를 가진 object를 찾는 함수 // 이름을 입력하지 않으면 이름은 비교하지않고 T타입에만 해당하면 return, recursive - 자식의 자식까지 찾을 것인지 여부 // T는 Object만 가능
    {
        if (go == null) // 최상위 객체가 null이면
        {
            return null; // null을 return
        }

        if (recursive == false) // 직속 자식만 찾음
        {
            for (int i = 0; i < go.transform.childCount; i++) // gameObject의 자식 개수만큼 순회
            {
                Transform transform = go.transform.GetChild(i); // gameObject의 자식중 i번째에 해당하는 자식을 찾음
                if (string.IsNullOrEmpty(name) || transform.name == name) // 이름을 입력하지 않았거나, transform의 이름이 찾고싶은 이름과 같으면
                {
                    T component = transform.GetComponent<T>(); // T타입의 component를 들고있는지 확인
                    if (component != null) // 실제로 T타입의 component를 들고있었으면
                    {
                        return component; // component를 return
                    }
                }
            }
        }
        else // 자식의 자식까지 찾음
        {
            foreach (T component in go.GetComponentsInChildren<T>()) // gameObject가 갖고있는 T타입의 Object들을 모두 찾고, 각각을 순회
            {
                if (string.IsNullOrEmpty(name) || component.name == name) // 이름을 입력하지 않았거나, component의 이름이 찾고싶은 이름과 같으면
                {
                    return component; // component를 return
                }
            }
        }

        return null; // 최종적으로 못찾았으면 null을 return
    }
}