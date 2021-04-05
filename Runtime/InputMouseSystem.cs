using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ShawonGameTools
{


    public class InputMouseSystem : MonoBehaviour
    {
        public static InputMouseSystem instance;

        public Vector2 oldPos;
        public Vector2 newPos;
        public Vector2 mouseProgression;
        public Vector2 mouseProgressionWRTScreen;
        public Vector2 mouseProgressionLastFrame;
        public Vector2 mouseVelocity;
        [SerializeField]
        bool tapped;

        public Action actionTouchIn;
        public Action actionTouchHolded;
        public Action actionTouchOut;

        public Action actionSwipeRight;
        public Action actionSwipeLeft;
        [SerializeField]
        bool touchEnabled;
        public float swipeThreshold;
        [SerializeField]
        bool swipping;

        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!touchEnabled)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                actionTouchIn?.Invoke();
                swipping = true;
                oldPos = newPos = Input.mousePosition;

                mouseProgression = newPos - oldPos;

                mouseProgressionLastFrame = mouseProgression;
            }
            if (Input.GetMouseButton(0))
            {
                tapped = true;
                //oldPos = newPos;
                newPos = Input.mousePosition;
                mouseProgression = newPos - oldPos;
                mouseVelocity = (mouseProgression - mouseProgressionLastFrame) / Screen.width;
                mouseProgressionLastFrame = mouseProgression;

                actionTouchHolded?.Invoke();

                if (swipping && Mathf.Abs(mouseProgression.x) > (Screen.width * swipeThreshold))
                {
                    if (mouseProgression.x > 0)
                    {
                        actionSwipeRight?.Invoke();
                    }
                    else
                    {
                        actionSwipeLeft?.Invoke();
                    }

                    swipping = false;
                }
            }
            else
            {
                tapped = false;
            }
            if (Input.GetMouseButtonUp(0))
            {
                actionTouchOut?.Invoke();
                oldPos = newPos;
                mouseVelocity = Vector2.zero;
            }

            mouseProgressionWRTScreen = mouseProgression / Screen.width;
        }

        public bool MouseTappedOrNot()
        {
            return tapped;
        }

        public bool TouchEnabledOrNot()
        {
            return touchEnabled;
        }

        public void TouchEnable()
        {
            touchEnabled = true;
        }
        public void TouchDisable()
        {
            touchEnabled = false;
            tapped = false;
            actionTouchOut?.Invoke();
        }
    }
}
