using System;

namespace GameCardLib
{
    public class PlayerTurnEventArgs : EventArgs
    {
        public Player Player { get; set; }
    }
}
