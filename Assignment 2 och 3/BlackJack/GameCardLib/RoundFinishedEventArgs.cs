using System;

namespace GameCardLib
{
    public class RoundFinishedEventArgs : EventArgs
    {
        public Player Player { get; set; }
    }
}
