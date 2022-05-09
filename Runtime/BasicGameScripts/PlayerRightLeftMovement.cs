using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace ShawonGameTools
{
    public class PlayerRightLeftMovement : MonoBehaviour
    {
        public enum DragMode
        {
            UpDown, FrontBack
        }
        public enum MovementMode
        {
            Local, Global
        }
        public DragMode dragModeCurrent;
        public MovementMode movementModeCurrent;
        public GameObject playerChildLocalRot;
        public GameObject playerChildSideMove;

        [SerializeField]
        private Vector2 maxRightLeft;
        [SerializeField]
        private Vector2 maxFrontBack;
        [SerializeField]
        Vector2 maxRightLeftCorrected
        {
            get { return (maxRightLeft - maxLimitReduction); }

        }
        Vector2 maxLimitReduction;
        [SerializeField]
        Vector3 oldPos;
        [SerializeField]
        Vector3 newPos;
        [SerializeField]
        float sideVel;
        [SerializeField]
        Vector3 smoothOldPos;

        public float dragSensitivity;

        public Action actionOnDragUpdate;


        [SerializeField]
        bool rightLeftAllowed;
        public static PlayerRightLeftMovement instance;

        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {

           
            //EnableRightLeftMovement();
            GetOldPos();
            Application.targetFrameRate = 60;

        }

        // Update is called once per frame
        void Update()
        {

            if (!rightLeftAllowed)
            {
                return;
            }

            DragFollow();
        }
        public void MaxLimitReductionTo(Vector2 f)
        {
            maxLimitReduction = f;
        }

        public void GetOldPos()
        {
            if(playerChildSideMove == null)
            {
                return;
            }
            oldPos = playerChildSideMove.transform.localPosition;
            if (!rightLeftAllowed)
            {
                return;
            }
            newPos = oldPos;
            Debug.Log("GotOldPos");
            //smoothOldPos = oldPos;
        }
        public void NewPosUpdate()
        {
            if (!rightLeftAllowed)
            {
                return;
            }
            Vector2 mouseVel = new Vector2(0, 0);
            switch (movementModeCurrent)
            {
                case MovementMode.Local:
                    {
                        mouseVel = InputMouseSystem.instance.mouseVelocity;
                        break;
                    }
                case MovementMode.Global:
                    {
                        
                        if (playerChildSideMove != null)
                        {
                            mouseVel = playerChildSideMove.transform.InverseTransformDirection(InputMouseSystem.instance.mouseVelocity);
                        }

                        break;
                    }
            }
            //newPos = oldPos + new Vector3(InputMouseSystem.instance.mouseProgression.x  *0.05f, 0, 0);
            switch (dragModeCurrent)
            {
                case DragMode.UpDown:
                    {
                       
                        newPos += new Vector3(mouseVel.x * dragSensitivity,  mouseVel.y * dragSensitivity,0);
                        newPos = new Vector3(Mathf.Clamp(newPos.x, maxRightLeftCorrected.x, maxRightLeftCorrected.y),  Mathf.Clamp(newPos.y, maxFrontBack.x, maxFrontBack.y),0);
                        break;
                    }
                case DragMode.FrontBack:
                    {
                        newPos += new Vector3(InputMouseSystem.instance.mouseVelocity.x * dragSensitivity, 0, InputMouseSystem.instance.mouseVelocity.y * dragSensitivity);
                        newPos = new Vector3(Mathf.Clamp(newPos.x, maxRightLeftCorrected.x, maxRightLeftCorrected.y), 0, Mathf.Clamp(newPos.z, maxFrontBack.x, maxFrontBack.y));
                        break;
                    }
            }
            


        }


        public void DragFollow()
        {

            if (playerChildSideMove == null)
            {
                return;
            }
            playerChildSideMove.transform.localPosition = Vector3.Lerp(playerChildSideMove.transform.localPosition, newPos, Time.deltaTime * 10);
            //playerChild.transform.localPosition = new Vector3(Mathf.Clamp(playerChild.transform.localPosition.x, -maxRightLeft, maxRightLeft), 0, 0);

            sideVel = (playerChildSideMove.transform.localPosition - smoothOldPos).x / Time.deltaTime;
            sideVel = Mathf.Clamp(sideVel, -5f, 5f);

            actionOnDragUpdate?.Invoke();
            smoothOldPos = playerChildSideMove.transform.localPosition;

        }
        public void InitialTasks()
        {
            ResetIt();
        }
        public void ResetIt()
        {

            ResetValues();
            //PlayerCarReferences.instance.carPathFollowSystem.SetMoveSpeedMul(0);
            DisableRightLeftMovement();
        }
        public void ResetValues()
        {
            oldPos = Vector3.zero;
            newPos = Vector3.zero;
            smoothOldPos = Vector3.zero;
            if (playerChildSideMove != null)
            {
                playerChildSideMove.transform.localPosition = Vector3.zero;
            }
            
            if (playerChildLocalRot != null)
            {
                playerChildLocalRot.transform.localRotation = Quaternion.Euler(Vector3.zero);
            }


            sideVel = 0;
        }
        public float GetSideVel()
        {
            return sideVel;
        }
        public void EnableRightLeftMovement()
        {
            rightLeftAllowed = true;
            GetOldPos();
        }
        public void DisableRightLeftMovement()
        {
            //ResetValues();
            rightLeftAllowed = false;
            sideVel = 0;
            //ResetValues();
        }
        public void FinishLineReachFun()
        {
            DisableRightLeftMovement();
        }

        public void SetThePlayerChildAs(GameObject go)
        {
            playerChildSideMove = go;
            GetOldPos();
        }
        public void ReleasePlayerChildAlone()
        {
            playerChildSideMove = null;
           
        }
        public void SetMaxRightLeftTo(Vector2 limitX)
        {
            maxRightLeft = limitX;
        }
        public void SetMaxFrontBackTo(Vector2 limitY)
        {
            maxFrontBack = limitY;
        }


    }
}

