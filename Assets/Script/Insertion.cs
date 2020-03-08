using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Insertion : MonoBehaviour
{
	public int NumberOfCubes;
	public int CubeHeightMax = 10;
	public GameObject[] Cubes;
	public Material Munsorted;
	public Material Msorted;
	Material Lands;
	public Text textComponent;
	public Text textInfo;

	void Awake()
	{
		Lands = Resources.Load("Land",typeof(Material)) as Material;
	}

	public void PlaySortingASC()
	{
		textComponent = GameObject.Find("Total").GetComponent<Text>();
		textInfo = GameObject.Find("info").GetComponent<Text>();
		InitializeRandom();
		StartCoroutine(InsertionSortASC(Cubes));
	}
	public void PlaySortingDSC()
	{
		textInfo = GameObject.Find("info").GetComponent<Text>();
		textComponent = GameObject.Find("Total").GetComponent<Text>();
		InitializeRandom();
		StartCoroutine(InsertionSortDSC(Cubes));	
	}
	IEnumerator InsertionSortASC(GameObject[] unsortedList)
	{
		
		int j;
		GameObject key;
		unsortedList[0].GetComponent<MeshRenderer>().material = Msorted;
		unsortedList[0].GetComponent<MeshRenderer>().material.color = Color.green;
		for(int i = 1; i < unsortedList.Length; i++)
		{
			key = unsortedList[i];
			key.GetComponent<MeshRenderer>().material.color = Color.blue;
			textInfo.text = "Key Baru";
			yield return new WaitForSeconds(2);
			j = i-1;

			if(j >= 0 && unsortedList[j].transform.localScale.y > key.transform.localScale.y)
			{
				while(j >= 0 && unsortedList[j].transform.localScale.y > key.transform.localScale.y)
					{
								unsortedList[j+1] = unsortedList[j];
						textInfo.text = "Key masih lebih kecil dari block sebelumnya , Tukar key dengan block sebelumnya";
						yield return new WaitForSeconds(3);
						textInfo.text = "Menukar....";
						yield return new WaitForSeconds(1);
						
						key.GetComponent<MeshRenderer>().material.color = Color.blue;
						unsortedList[i-1].GetComponent<MeshRenderer>().material.color = Color.blue;
						LeanTween.moveLocalX(key,
							unsortedList[j+1].transform.localPosition.x,
							1);
						LeanTween.moveLocalZ(key,
							3,
							.5f).setLoopPingPong(1);
						LeanTween.moveLocalX(unsortedList[j],
							key.transform.localPosition.x,
							1);
						LeanTween.moveLocalZ(unsortedList[j],
							-3,
							.5f).setLoopPingPong(1);
						j = j - 1;
					unsortedList[i-1].GetComponent<MeshRenderer>().material = Msorted;
					unsortedList[i-1].GetComponent<MeshRenderer>().material.color = Color.green;
					int num = int.Parse(textComponent.text)+1;
					textComponent.text = num.ToString();

					}
				textInfo.text = "Key sudah lebih besar dengan block sebelumnya , Pindah key berikutnya";
				yield return new WaitForSeconds(2);
			}else{
				textInfo.text = "Key sudah lebih besar dengan block sebelumnya , Pindah key berikutnya";
				yield return new WaitForSeconds(3);
				textInfo.text = "Memindahkan....";
				yield return new WaitForSeconds(2);


			}
			
			unsortedList[j+1] = key;
			unsortedList[j+1].GetComponent<MeshRenderer>().material = Msorted;
			unsortedList[j+1].GetComponent<MeshRenderer>().material.color = Color.green;

		}
		
		textInfo.text = "SELESAI";

	}

		IEnumerator InsertionSortDSC(GameObject[] unsortedList)
	{
		
		int j;
		GameObject key;
		unsortedList[0].GetComponent<MeshRenderer>().material = Msorted;
		unsortedList[0].GetComponent<MeshRenderer>().material.color = Color.green;
		for(int i = 1; i < unsortedList.Length; i++)
		{
			key = unsortedList[i];
			key.GetComponent<MeshRenderer>().material.color = Color.blue;
			textInfo.text = "Key Baru";
			yield return new WaitForSeconds(2);
			j = i-1;

			if(j >= 0 && unsortedList[j].transform.localScale.y < key.transform.localScale.y)
			{
				while(j >= 0 && unsortedList[j].transform.localScale.y < key.transform.localScale.y)
					{
								unsortedList[j+1] = unsortedList[j];
						textInfo.text = "Key masih lebih besar dari block sebelumnya , Tukar key dengan block sebelumnya";
						yield return new WaitForSeconds(3);
						textInfo.text = "Menukar....";
						yield return new WaitForSeconds(1);
						
						key.GetComponent<MeshRenderer>().material.color = Color.blue;
						unsortedList[i-1].GetComponent<MeshRenderer>().material.color = Color.blue;
						LeanTween.moveLocalX(key,
							unsortedList[j+1].transform.localPosition.x,
							1);
						LeanTween.moveLocalZ(key,
							3,
							.5f).setLoopPingPong(1);
						LeanTween.moveLocalX(unsortedList[j],
							key.transform.localPosition.x,
							1);
						LeanTween.moveLocalZ(unsortedList[j],
							-3,
							.5f).setLoopPingPong(1);
						j = j - 1;
					unsortedList[i-1].GetComponent<MeshRenderer>().material = Msorted;
					unsortedList[i-1].GetComponent<MeshRenderer>().material.color = Color.green;
					int num = int.Parse(textComponent.text)+1;
					textComponent.text = num.ToString();

					}
				textInfo.text = "Key sudah lebih kecil dengan block sebelumnya , Pindah key berikutnya";
				yield return new WaitForSeconds(2);
			}else{
				textInfo.text = "Key sudah lebih kecil dengan block sebelumnya , Pindah key berikutnya";
				yield return new WaitForSeconds(3);
				textInfo.text = "Memindahkan....";
				yield return new WaitForSeconds(2);


			}
			
			unsortedList[j+1] = key;
			unsortedList[j+1].GetComponent<MeshRenderer>().material = Msorted;
			unsortedList[j+1].GetComponent<MeshRenderer>().material.color = Color.green;

		}
		
		textInfo.text = "SELESAI";

	}

	void InitializeRandom()
	{
		Cubes = new GameObject[NumberOfCubes];
		int textOffset = -2;
		for(int i = 0; i < NumberOfCubes; i++)
		{
			int randomNumber = Random.Range(1, CubeHeightMax + 1);

			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.localScale = new Vector3(0.9f,randomNumber,1);
			cube.transform.position = new Vector3(i,randomNumber/2.0f,0);
			cube.transform.parent = this.transform;
			cube.GetComponent<MeshRenderer>().material = Munsorted;
			cube.GetComponent<MeshRenderer>().material.color = Color.white;
			
			///
			GameObject ChildObj = new GameObject();
			ChildObj.transform.parent = cube.transform;
			ChildObj.name = "Text";

			TextMesh textMesh = ChildObj.AddComponent<TextMesh>();
			textMesh.text = randomNumber.ToString();
			textMesh.characterSize = 0.5f;

			textMesh.anchor = TextAnchor.MiddleCenter;
			textMesh.alignment = TextAlignment.Center;
			textMesh.fontStyle = FontStyle.Bold;
			textMesh.transform.position = new Vector3(cube.transform.position.x,-1.0f,cube.transform.position.z);
			Cubes[i] = cube;
			if(i == 0)
			{
				GameObject batas_kiri = GameObject.CreatePrimitive(PrimitiveType.Cube);
				batas_kiri.transform.localScale = new Vector3(0.4f,20,50);
				batas_kiri.transform.position = new Vector3(i-10,0,0);
				batas_kiri.transform.parent = this.transform;
				batas_kiri.GetComponent<MeshRenderer>().enabled = false;
			}
			if(i == NumberOfCubes-1)
			{
				GameObject batas_kanan = GameObject.CreatePrimitive(PrimitiveType.Cube);
				batas_kanan.transform.localScale = new Vector3(0.4f,20,50);
				batas_kanan.transform.position = new Vector3(i+10,0,0);
				batas_kanan.transform.parent = this.transform;	
				batas_kanan.GetComponent<MeshRenderer>().enabled = false;

			}
			if(i == NumberOfCubes/2)
			{
				GameObject batas_bawah = GameObject.CreatePrimitive(PrimitiveType.Plane);
				batas_bawah.transform.localScale = new Vector3(NumberOfCubes+10,1,5);
				batas_bawah.transform.position = new Vector3(-5,-1.6f,0);
				batas_bawah.transform.parent = this.transform;
				batas_bawah.GetComponent<MeshRenderer>().material = Lands;
			    batas_bawah.GetComponent<MeshRenderer>().material.color = Color.black;
		
			}
		}

		transform.position = 
			new Vector3(-NumberOfCubes/2f, -CubeHeightMax/2.0f,0);
		
	}

	void update()
	{
		 
	}

	
}
