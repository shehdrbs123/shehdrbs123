﻿namespace BasicTeamProject;

public class InputMemory
{
    public int PreInput;
    public bool InputComplete;
    private int _start;
    private int _end;

    public InputMemory()
    {
        _start = 0;
        _end = 0;
    }

    public void SetRange(int start, int end)
    {
        _start = start;
        _end = end;
    }
    
    public bool TryGetKey(out int key)
    {
        key = 0;
        bool isOk = false;
        if (int.TryParse(Console.ReadLine(), out key))
        {
            if (_start <= key && key < _end)
            {
                PreInput = key;
                isOk = true;
            }
        }
        return isOk;
    }

    public bool TryGetKey(int range, out int key)
    {
        SetRange(0,range);
        return TryGetKey(out key);
    }

    public bool TryGetKey(int start, int end, out int key)
    {
        SetRange(start,end);
        return TryGetKey(out key);
    }

}