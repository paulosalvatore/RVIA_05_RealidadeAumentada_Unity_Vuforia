using UnityEngine;

public class Personagem : MonoBehaviour
{
	public float distancia = 3f;
	public float velocidade = 0.015f;
	public float velocidadeRotacao = 2f;

	private Vector3 destino;

	private void Start()
	{
		destino = transform.position;
	}

	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(
				Input.mousePosition
			);

			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, distancia))
			{
				// Ray tocou em algum ponto
				destino = hit.point;
			}
		}

		destino.y = transform.position.y;
		var rotacao = Quaternion.Slerp(
			transform.rotation,
			Quaternion.LookRotation(destino),
			velocidadeRotacao * Time.deltaTime
		);
		rotacao.eulerAngles = new Vector3(
			0,
			rotacao.eulerAngles.y,
			0
		);
		transform.rotation = rotacao;

		if (Vector3.Distance(transform.position, destino) > 0.05f)
		{
			transform.Translate(
				Vector3.forward * velocidade * Time.deltaTime
			);
		}
	}
}
