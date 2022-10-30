using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandHandler
{
    public List<ICommand> m_Commands = new List<ICommand>();

    /// <summary>
    /// Adds an ICommand to the list/stack of commands.
    /// After adding, it will execute the command.
    /// </summary>
    /// <param name="command">
    /// The command to add to the command stack. Will be executed right away. 
    /// </param>
    public void AddCommand(ICommand command)
    {
        m_Commands.Add(command);
        command.Execute();
    }

    /// <summary>
    /// Undos the last command executed and 
    /// removes it from the command list/stack.
    /// Works like popping an element from the 
    /// stack, but calling ICommand.Undo() first.
    /// </summary>
    public void UndoCommand()
    {
        if (m_Commands.Count <= 0)
            return;

        m_Commands[m_Commands.Count - 1].Undo();
        m_Commands.RemoveAt(m_Commands.Count - 1);
    }

    /// <summary>
    /// Executes the command at the top of the command list.
    /// </summary>
    public void ExecuteCommand()
    {
        if (m_Commands.Count <= 0)
            return;
        
        m_Commands[m_Commands.Count - 1].Execute();
    }
}
