using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ShawonGameTools
{
    public class SmoothGainValuesManager : MonoBehaviour
    {
        public static SmoothGainValuesManager instance;
        public SmoothGainAValue smoothGainAValue;
        public List<SmoothGainAValue> smoothGainValuesList;

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
            if (Input.GetKeyDown(KeyCode.T))
            {
                TransitionValueSetTo(0, 5, () => { Debug.Log("Started"); }, (float f) => { Debug.Log("Running " + f); }, () => { Debug.Log("Completed"); }, 1f);
            }
        }

        public void TransitionValueSetTo(float fromValue, float tarValue, Action start, Action<float> run, Action complete, float speed = 1, float delay = 0, float progression = 0)
        {
            bool assigned = false;

            for (int i = 0; i < smoothGainValuesList.Count; i++)
            {
                if (!smoothGainValuesList[i].transitionRunning)
                {
                    smoothGainValuesList[i].TransitionValueSetTo(fromValue, tarValue, start, run, complete, speed, delay, progression);
                    assigned = true;
                    break;
                }
            }
            if (!assigned)
            {
                GameObject go = Instantiate(smoothGainAValue.gameObject, transform.position, transform.rotation);
                go.transform.SetParent(transform);
                smoothGainValuesList.Add(go.GetComponent<SmoothGainAValue>());
                go.GetComponent<SmoothGainAValue>().TransitionValueSetTo(fromValue, tarValue, start, run, complete, speed, delay, progression);
            }

        }

    }
}

