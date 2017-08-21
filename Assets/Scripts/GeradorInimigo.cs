using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigo : MonoBehaviour {

	[SerializeField] private GameObject inimigo;
	private float MomentoDaUltimaCriacao;

	[Range(0,3)]
	[SerializeField] private float TempoDeCriacao = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		GeraInimigos ();
	}

	public void GeraInimigos ()
	{
		float TempoAtual = Time.time;

		if (TempoAtual > MomentoDaUltimaCriacao + TempoDeCriacao) {
			MomentoDaUltimaCriacao = TempoAtual;
			Vector3 PosicaoDoGerador = this.transform.position;
			Instantiate (inimigo, PosicaoDoGerador, Quaternion.identity);
		}
	}
}
