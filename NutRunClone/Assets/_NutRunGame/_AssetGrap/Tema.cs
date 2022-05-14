using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tema : MonoBehaviour
{
   
    public int hangiTema;
    public List<Temass> GuncelTemalar = new List<Temass>();

  


}



[System.Serializable]
public class Temass
{
    public Mesh karakterMesh;
    public Skybox skybox;
    public List<GameObject> binalar;
    public Sprite spritelar;
}