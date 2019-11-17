using System;

namespace GameCardLib
{
    public class CardEventArgs : EventArgs
    {
        public Card Card { get; set; }
        public Player Player { get; set; }
    }
}
