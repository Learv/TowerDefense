using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missil : MonoBehaviour {

	public GameObject alvo;
	private float velocidade = 10;
	[SerializeField] private int PontosDeDano;

	// Use this for initialization
	void Start () {

		alvo = GameObject.Find ("Inimigo(Clone)");

		AutoDestroiDepoisDeSegundos (5);
	}
	
	// Update is called once per frame
	void Update () {

		Anda ();
		if (GameObject.Find ("Inimigo(Clone)") != null) {
			AlteraDirecao ();
		}
	}

	private void Anda ()
	{
		Vector3 posicaoAtual = transform.position;
		Vector3 descolamento = transform.forward * Time.deltaTime * velocidade;
		transform.position = posicaoAtual + descolamento;
	}

	private void AlteraDirecao()
	{
		Vector3 posicaoAtual = transform.position;
		Vector3 posicaoDoAlvo = alvo.transform.position;
		Vector3 direcaoDoAlvo = posicaoDoAlvo - posicaoAtual;
		transform.rotation = Quaternion.LookRotation (direcaoDoAlvo);
	}

	void OnTriggerEnter(Collider elementoColidido) { 
		if (elementoColidido.CompareTag ("Inimigo")) {
			Destroy (this.gameObject);
			Inimigo inimigo = elementoColidido.GetComponent<Inimigo> ();
			inimigo.RecebeDano (PontosDeDano);
		}
	}

	private void AutoDestroiDepoisDeSegundos (float segundos) {
		Destroy (this.gameObject, segundos);
	}
}
