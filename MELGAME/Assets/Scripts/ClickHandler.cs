using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Source.Scripts.Objects;

public class ClickHandler : MonoBehaviour
{
    private void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>(); // Получаем массив дочерних объектов типа Button

        foreach (Button button in buttons)
        {
            EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>(); // Добавляем компонент EventTrigger к каждому дочернему объекту
            EventTrigger.Entry entry = new EventTrigger.Entry();

            entry.eventID = EventTriggerType.PointerClick; // Указываем тип события (клик мыши)
            entry.callback.AddListener((data) => { OnPointerClickDelegate((PointerEventData)data); }); // Добавляем делегат для обработки события
            trigger.triggers.Add(entry); // Добавляем событие к триггеру
        }
    }

    private void OnPointerClickDelegate(PointerEventData data)
    {
        GameObject clickedObject = data.pointerPress; // Получаем объект, на который был сделан клик

        if (clickedObject != null)
        {
            Target targetComponent = clickedObject.GetComponent<Target>(); // Получаем компонент Target с нажатого объекта

            if (targetComponent != null)
            {
                int value = targetComponent.GetValue(); // Получаем значение из компонента Target
                string key = targetComponent.GetSuit(); // Получаем ключ из компонента Target

               // Debug.Log("Значение: " + value + ", Ключ: " + key);
            }
            else
            {
                Debug.LogWarning("Нажатый объект не содержит компонент Target.");
            }
        }
    }

}
