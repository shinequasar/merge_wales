using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
    public class ToggleAnim : MonoBehaviour
    {
        Toggle toggleObject;
        Animator toggleAnimator;
        public GameObject Panel;
        
        void Start()
        {
            toggleObject = gameObject.GetComponent<Toggle>();
            toggleAnimator = gameObject.GetComponent<Animator>();
            toggleObject.onValueChanged.AddListener(TaskOnClick);

            if (toggleObject.isOn)
                toggleAnimator.Play("Toggle On");

            else
                toggleAnimator.Play("Toggle Off");
        }

        void TaskOnClick(bool value)
        {
            if (toggleObject.isOn)
            {
                toggleAnimator.Play("Toggle On");
                Panel.gameObject.SetActive(false); //슬라이더 가리기용 패널 비활성화
            }
            else
            {
                toggleAnimator.Play("Toggle Off");
                Panel.gameObject.SetActive(true); //슬라이더 가리기용 패널 활성화
            }
                
        }
    }
}