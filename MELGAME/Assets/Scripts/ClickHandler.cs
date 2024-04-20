using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Source.Scripts.Objects;

public class ClickHandler : MonoBehaviour
{
    private void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>(); // �������� ������ �������� �������� ���� Button

        foreach (Button button in buttons)
        {
            EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>(); // ��������� ��������� EventTrigger � ������� ��������� �������
            EventTrigger.Entry entry = new EventTrigger.Entry();

            entry.eventID = EventTriggerType.PointerClick; // ��������� ��� ������� (���� ����)
            entry.callback.AddListener((data) => { OnPointerClickDelegate((PointerEventData)data); }); // ��������� ������� ��� ��������� �������
            trigger.triggers.Add(entry); // ��������� ������� � ��������
        }
    }

    private void OnPointerClickDelegate(PointerEventData data)
    {
        GameObject clickedObject = data.pointerPress; // �������� ������, �� ������� ��� ������ ����

        if (clickedObject != null)
        {
            Target targetComponent = clickedObject.GetComponent<Target>(); // �������� ��������� Target � �������� �������

            if (targetComponent != null)
            {
                int value = targetComponent.GetValue(); // �������� �������� �� ���������� Target
                string key = targetComponent.GetSuit(); // �������� ���� �� ���������� Target

               // Debug.Log("��������: " + value + ", ����: " + key);
            }
            else
            {
                Debug.LogWarning("������� ������ �� �������� ��������� Target.");
            }
        }
    }

}
