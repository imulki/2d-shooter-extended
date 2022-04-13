using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory
{
    GameObject FactoryMethod(int tag);
    GameObject[] RandomMassFactoryMethod(int value, int[] tag, string specialCase);
}
