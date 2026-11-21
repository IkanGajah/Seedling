using System;
using UnityEngine;

public interface IHasHealth
{
    public event EventHandler<OnHealthReducedEventArgs> OnHealthReduced;
    public class OnHealthReducedEventArgs : EventArgs {
        public float healthNormalized;
    }
}
