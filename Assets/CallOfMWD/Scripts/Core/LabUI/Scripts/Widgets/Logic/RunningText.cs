using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace lab.ui
{
    public class RunningText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private RectTransform scrollViewZone;
        [SerializeField] private TMP_Text text;
        
        [SerializeField] private float velocity = 30;
        [SerializeField] private float margin = 10;
        
        private bool run = false;
        private bool pointerOver = false;
        private RectTransform runningZone;
        private float minVal;
        private float maxVal;
        private string textVal;

        private void Awake()
        {
            runningZone = text.rectTransform;
        }

        private IEnumerator Start()
        {
            yield return null;
            StartCoroutine(SetupRect());
        }

        private void Update()
        {
            if (textVal != text.text)
            {
                run = false;
                StartCoroutine(SetupRect());
            }
            
            if (!pointerOver)
                return;
            
            if (run)
            {
                float posX = runningZone.anchoredPosition.x;
                posX -= Time.deltaTime * velocity;

                if (posX < minVal)
                {
                    posX = maxVal;
                }
                
                runningZone.anchoredPosition = new Vector2(posX, runningZone.anchoredPosition.y);
            }
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            pointerOver = true;
            StartCoroutine(SetupRect());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            pointerOver = false;          
            StartCoroutine(SetupRect());
        }

        private IEnumerator SetupRect()
        {
            yield return new WaitForEndOfFrame();
            
            runningZone.anchoredPosition = Vector2.zero;
            
            if (SetupMovingRect())
            {
                maxVal = margin;
                minVal = scrollViewZone.sizeDelta.x - runningZone.sizeDelta.x * runningZone.localScale.x - margin;

                runningZone.anchoredPosition += new Vector2(margin, 0);
                
                run = true;
            }
            else
            {
                run = false;
            }
            
            textVal = text.text;
        }

        private bool SetupMovingRect()
        {
            if (runningZone.sizeDelta.x * runningZone.localScale.x  <= scrollViewZone.sizeDelta.x)
            {
                runningZone.anchorMin = new Vector2(0.5f, 0.5f);
                runningZone.anchorMax = new Vector2(0.5f, 0.5f);
                runningZone.pivot = new Vector2(0.5f, 0.5f);

                return false;
            }
            else
            {
                runningZone.anchorMin = new Vector2(0, 0.5f);
                runningZone.anchorMax = new Vector2(0, 0.5f);
                runningZone.pivot = new Vector2(0, 0.5f);

                return true;
            }
        }


    }
}