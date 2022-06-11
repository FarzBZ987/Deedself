using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewSystems : MonoBehaviour
{
    private ScrollRect _scrollRect;

    [SerializeField] private ScrollButton _leftButton;
    [SerializeField] private ScrollButton _rightButton;
    [SerializeField] private float scrollSpeed = 0.5f;

    private void Start()
    {
        _scrollRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_leftButton != null)
        {
            if (_leftButton.isDown)
            {
                Debug.Log("MoveLeft");
                ScrollLeft();
            }
        }
        if (_rightButton != null)
        {
            if (_rightButton.isDown)
            {
                Debug.Log("MoveRight");
                ScrollRight();
            }
        }
    }

    private void ScrollLeft()
    {
        if (_scrollRect != null)
        {
            //if (_scrollRect.horizontalNormalizedPosition >= 0f)
            //{
            _scrollRect.horizontalNormalizedPosition -= scrollSpeed;
            // }
        }
    }

    private void ScrollRight()
    {
        if (_scrollRect != null)
        {
            //if (_scrollRect.horizontalNormalizedPosition <= 1f)
            //{
            _scrollRect.horizontalNormalizedPosition += scrollSpeed;
            // }
        }
    }
}