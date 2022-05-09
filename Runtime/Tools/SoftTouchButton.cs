using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using ShawonGameTools;

namespace ShawonGameTools
{
    public class SoftTouchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        private bool touched;
        private int pointerID;

        public GameObject player;
        public Action ActionButtonFun;
        public Animator buttonAnim;
        void Awake()
        {
            touched = false;
        }
        void Start()
        {
           

        }
        //void Update()
        //{
        //    if (Input.GetTouch(0)) { player.GetComponent<PlayerController>().GoLeft(); }
        //}

        public void OnPointerDown(PointerEventData data)
        {
            
            if (buttonAnim != null)
            {
                buttonAnim.SetTrigger("Pressed");
            }

            ActionButtonFun?.Invoke();
            //Debug.Log("RightTap");
        }

        public void OnPointerUp(PointerEventData data)
        {
            
        }



    }
}


