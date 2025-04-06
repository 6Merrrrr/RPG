using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    
   private NavMeshAgent agent;
   private Animator anim;
   
   [SerializeField] GameObject bagPanel;
    // [SerializeField] GameObject equipmentPanel;
    // [SerializeField] GameObject itemPanel;
    private bool isBagOpen = false; // 标记背包是否打开
   
   void Awake()
   {
       agent = GetComponent<NavMeshAgent>();
       anim = GetComponent<Animator>();
   }
 void Start()
{
    MouseManager.Instance.OnMouseClicked += HandleMouseClick;
}
void Update()
{
   SwitchAnimation();
    OpenBag();
}
  
  private void SwitchAnimation()
  {
    anim.SetFloat("Speed", agent.velocity.sqrMagnitude);
  }
  
   
   public void MoveToTarget(Vector3 target)
   {
       agent.destination=target;
   }

  public void OpenBag()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isBagOpen = !isBagOpen; // 切换背包状态
            bagPanel.SetActive(isBagOpen);
            // Cursor.lockState = isBagOpen ? CursorLockMode.None : CursorLockMode.Locked;
            // Cursor.visible = isBagOpen; // 显示或隐藏鼠标光标
        }
    }

    private void HandleMouseClick(Vector3 target)
    {
        // 如果背包打开，忽略鼠标点击事件
        if (isBagOpen)
        {
            return;
        }

        // 背包未打开时，处理鼠标点击事件
        MoveToTarget(target);
    }
}
