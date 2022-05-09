using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace ShawonGameTools
{
    public class SmoothGainAValue : MonoBehaviour
    {

        public float transitionVal;
        //public float outVal;
        public bool transitionRunning;
        public Action<float> actionOnTransitioning;
        public Action actionOnTransitionStart;
        public Action actionOnTransitionEnd;
        // Start is called before the first frame update
        void Start()
        {

            //TransitionValueSetToInstant(0);
            //TransitionValueSetTo(0, 2);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TransitionValueSetTo(float fromValue, float tarValue, Action start, Action<float> run, Action complete, float speed = 1, float delay = 0, float progression = 0)
        {
            StopAllCoroutines();
            transitionRunning = true;
            AssignTransitionFuntions(start, run, complete);
            StartCoroutine(SetTransitionTo(fromValue, tarValue, speed, delay, progression));
        }
        public void TransitionValueSetToInstant(float tarValue)
        {
            StopAllCoroutines();
            transitionVal = tarValue;
            UpdateAccordingToTransitionValue();
        }

        IEnumerator SetTransitionTo(float fromValue, float tarValue, float speed, float delay = 0, float progression = 0)
        {
            yield return new WaitForSeconds(delay);
            if (progression == 0)
            {

                transitionVal = fromValue;
                actionOnTransitionStart?.Invoke();
            }

            progression += Time.deltaTime * speed;
            if (progression >= 1)
            {
                progression = 1;
                transitionRunning = false;
                transitionVal = tarValue;
                UpdateAccordingToTransitionValue();
                actionOnTransitionEnd?.Invoke();
            }
            transitionVal = Mathf.SmoothStep(fromValue, tarValue, progression);

            if (progression < 1)
            {
                UpdateAccordingToTransitionValue();
                StartCoroutine(SetTransitionTo(fromValue, tarValue, speed, delay, progression));
            }


        }
        public void UpdateAccordingToTransitionValue()
        {
            actionOnTransitioning?.Invoke(transitionVal);

        }

        //IEnumerator VanishDelayed(float d)
        //{
        //    yield return new WaitForSeconds(d);
        //    TransitionValueSetTo(0, 2);
        //}

        private void OnEnable()
        {

            //TransitionValueSetToInstant(0);
            //TransitionValueSetTo(1,2);
            //StartCoroutine( VanishDelayed(1f));
        }

        private void OnDisable()
        {
            //TransitionValueSetToInstant(0);
        }
        public void AssignTransitionFuntions(Action start, Action<float> run, Action complete)
        {
            actionOnTransitioning = null;
            actionOnTransitionStart = null;
            actionOnTransitionEnd = null;
            actionOnTransitioning += run;
            actionOnTransitionStart += start;
            actionOnTransitionEnd += complete;
        }
    }
}

