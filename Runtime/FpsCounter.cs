using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShawonGameTools
{
    public class FpsCounter : MonoBehaviour
    {
        public Text fpsText;
        public float fps;
        // Start is called before the first frame update
        void Start()
        {
            fpsText = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.deltaTime != 0)
            {
                fps = Mathf.Lerp(fps, 1 / Time.deltaTime, Time.deltaTime * 2);
                fpsText.text = "" + Mathf.RoundToInt(fps);

            }
        }
    }
}

