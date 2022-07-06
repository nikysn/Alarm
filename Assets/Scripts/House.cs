using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {

            _alarm.TurnOnAlarm();
            Debug.Log("������� ����");


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarm.TurnOffAlarm();
        }
    }
}
/*1. float volume - ����� �������� �������� target 
 * 2. if (_audioSource.volume == _minVolume) { _audioSource.Stop(); } - ��� ������������ ��������� � ����� �������� 
 * 3. ��������� ���������������. ������������ ������ ������ ������ ���������, �������� ����� ��� ������ ��� ������ �������� 
 * 4. _animator.SetBool("RunRight", true); - �� ����������� ��������� �������� ��� ������ � PlayerPrefs, ���������� ��� �������� ��������. 
 * ��������� ��������: https://agava.notion.site/40e2798c8c32487583180b03cbc5fccd 
 * 5. public class PlayerMove -> PlayerMovement 
 * 6. � ������ PlayerMove ����������� ��� ��������, ����� �������� ����� ������� �����������*/