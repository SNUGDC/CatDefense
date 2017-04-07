using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MEvent
{
	void Fire();
}
public abstract class MEventComponent : MonoBehaviour, MEvent
{
    public abstract void Fire();
}
