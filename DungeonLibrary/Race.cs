using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public enum Race
    {
        //There is no direct way to create an enum through the Visual Studio
        //interface, so to make one you create a class, make it public and change
        //the class keyword to enum. The values contain no spaces and 
        //are comma-separated.

        BostonTerrier,
        Chihuahua,
        Dachshund,
        GermanShepherd,
        IrishWolfhound,
        Mastiff


    }//end enum
}//end namespace
