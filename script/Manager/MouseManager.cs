using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// [System.Serializable]
// public class  EventVector3:UnityEvent<Vector3>
// {
    
// }

public class MouseManager : MonoBehaviour
{
  RaycastHit hitInfo;
   //public EventVector3 OnMouseClick;
   public static MouseManager Instance ;
   
   public Texture2D walk,attack; // 鼠标光标的纹理

   public event Action<Vector3> OnMouseClicked;//定义一个事件，类型为 Action<Vector3>，用于通知其他脚本鼠标点击地面时的坐标。

  void Awake()
  {
   if(Instance!=null)
   {
     Destroy(gameObject);
   }
    Instance=this;
  }

  void Update()
  {
     SetCursorTexture();
     MouseControl();
  }
  void SetCursorTexture()
  {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if(Physics.Raycast(ray,out hitInfo))
      {
        switch(hitInfo.collider.gameObject.tag)
        {
          case "Ground":
            Cursor.SetCursor(walk,Vector2.zero,CursorMode.Auto);
            break;
          case "Interactable":
            Cursor.SetCursor(attack,Vector2.zero,CursorMode.Auto);
            break;
          default:
            Cursor.SetCursor(null,Vector2.zero,CursorMode.Auto);
            break;
        }
      }
  }

  void MouseControl()
  {
    if(Input.GetMouseButtonDown(0)&&hitInfo.collider!=null)
    {
      if(hitInfo.collider.tag=="Ground")
      {
        OnMouseClicked?.Invoke(hitInfo.point);
      }
    }
  }
}
