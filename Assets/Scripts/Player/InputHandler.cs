using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;

    //Queue untuk menyimpan list command
    Queue<Command> commands = new Queue<Command>();

    void FixedUpdate()
    {
        //Menghandle input movement
        Command moveCommand = InputMovementHandling();
        if (moveCommand != null)
        {
            commands.Enqueue(moveCommand);

            moveCommand.Execute();
        }
    }

    void Update()
    {
        //Mengahndle shoot
        Command shootCommand = InputShootHandling();
        if (shootCommand != null)
        {
            shootCommand.Execute();
        }
    }

    Command InputMovementHandling()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            //Undo movement
            return Undo();
        }

        int hMove = 0;
        int vMove = 0;

        //Check jika movement sesuai dengan key nya
        if (Input.GetKey(KeyCode.D))
        {
            hMove += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            hMove += -1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            vMove += 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vMove += -1;
        }

        Vector2 moveDir = new Vector2(hMove, vMove);
        moveDir.Normalize();

        return new MoveCommand(playerMovement, moveDir.x, moveDir.y); ;
    }

    Command Undo()
    {
        //Jika Queue command tidak kosong, lakukan perintah undo
        if(commands.Count > 0)
        {
            Command undoCommand = commands.Dequeue();
            undoCommand.UnExecute();
        }
        return null;
    }
    
    Command InputShootHandling()
    {
        //Jika menembak trigger shoot command
        if (Input.GetButton("Fire1"))
        {
            return new ShootCommand(playerShooting);
        }
        else
        {
            return null;
        }
    }
}