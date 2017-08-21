using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour {

	[SerializeField] private int vida;

	// Use this for initialization
	void Start () {

		NavMeshAgent agente = GetComponent<NavMeshAgent> ();
		GameObject FimDoCaminho = GameObject.Find ("FimDoCaminho");
		Vector3 posicaoDoFimDoCaminho = FimDoCaminho.transform.position;

		agente.SetDestination(posicaoDoFimDoCaminho);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RecebeDano (int PontosDeDano)
	{
		vida -= PontosDeDano;
			if (vida <= 0) {
				Destroy(this.gameObject);
			}
	}
}
