using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Global
{
    public static bool Paused { get; set; }

    private static int metals = 0;
    public static int Metals
    {
        get { return metals; }
        set
        {
            //to-do UI update resource
            metals = value;
        }
    }

    private static int circuit_boards = 0;
    public static int Circuit_Boards
    {
        get { return circuit_boards; }
        set
        {
            //to-do UI update resource
            circuit_boards = value;
        }
    }

    private static int gears = 0;
    public static int Gears
    {
        get { return gears; }
        set
        {
            //to-do UI update resource
            gears = value;
        }
    }

}