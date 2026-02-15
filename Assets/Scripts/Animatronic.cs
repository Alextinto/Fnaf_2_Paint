using UnityEngine;

public class Animatronic : MonoBehaviour
{
    [Header("Initial Settings")]
    //ID
    public AnimatronicID animatronicID;
    //Sala inicial del animatronico
    public Room initialRoom;
    public int aggressionLevel = 1;
    public float timeToMove;

    [Header("Runtime")]
    public Room currentRoom;

    private float timer;

    private void Start()
    {
        timer = 0;
        currentRoom = initialRoom;
        currentRoom.EnterThisRoom(animatronicID);
    }

    public void Update()
    {
        //Timer para mover al animatronico
        timer += Time.deltaTime;
        if (timer > timeToMove)
            TryMoveToRoom();
    }

    //Tirada de movimiento
    public void TryMoveToRoom()
    {
        timer = 0;

        int roll = Random.Range(0, 20);

        if (roll < aggressionLevel)
            MoveToRoom();
    }

    //Movimiento del animatronico
    private void MoveToRoom()
    {
        Room nextRoom = currentRoom.GetNextRoom(animatronicID);
        if (nextRoom != null)
        {
            currentRoom.ExitThisRoom(animatronicID);
            currentRoom = nextRoom;
            currentRoom.EnterThisRoom(animatronicID);
        }
    }

}
