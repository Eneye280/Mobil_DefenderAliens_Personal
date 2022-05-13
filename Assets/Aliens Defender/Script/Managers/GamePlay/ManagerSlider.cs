using UnityEngine;
using UnityEngine.UI;

public class ManagerSlider : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Slider sliderProgress;

    [Header("Values")]
    [SerializeField] private float speedSliderProgress;
    [SerializeField] private float aggregatePercentageSlider;

    [Space]
    [SerializeField] private bool isAddSliderProgress;
    [SerializeField] private float maxValueSlider;

    private float interval;

    private void Start()
    {
        interval = 1;

        sliderProgress.maxValue = maxValueSlider;
    }

    private void Update()
    {
        if(Time.frameCount % interval == 0)
        {
            AddSliderProgress();
        }
    }

    private void AddSliderProgress()
    {
        if(sliderProgress.value <= sliderProgress.maxValue)
            isAddSliderProgress = true;
        else
            isAddSliderProgress = false;

        if (isAddSliderProgress)
        {
            sliderProgress.value += .1f * Time.deltaTime * aggregatePercentageSlider; 
        }
    }
}
