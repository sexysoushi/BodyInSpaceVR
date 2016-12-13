using UnityEngine;
using System.Collections;


public class Postures : MonoBehaviour {
	//private bool searching = true;
	private int coef = 30;
	private float timer = 0 , limit = 3;
	private int id_Position;

	// Ordre 1 : Corps à t , t-1, t-2, vitess corps
	// Ordre 2: poitrine, ventre, epauleG, epauleD, coudeG, coudeD, mainG, mainD, genouG, genouD, piedD, piedG;    

	public GameObject poitrine;
	public GameObject ventre;
	public GameObject epauleG;
	public GameObject epauleD;
	public GameObject coudeG;
	public GameObject coudeD;
	public GameObject mainG;
	public GameObject mainD;
	public GameObject genouG;
	public GameObject genouD;
	public GameObject piedD;
	public GameObject piedG;

	// Ordre des angles : Epaule G , Coude G , Epaule D, Coude D, Hanche G, Jenou G, Hanche D, Jenou D
	private int[,] positionAngles = {{-1,-9,2,3,0,0,0,1},{-2,0,1,0,1,0,-1,0},{0,-8,1,0,0,0,0,0},{0,1,0,0,0,0,0,0,0}};
	private int[] currAngle = {0,0,0,0,0,0,0,0};
	public int comp = -1;

	
	public void FixedUpdate(){
		if (SimonGame.search)
	   {
		   if (timer > limit)
		   {
				SimonGame.search = false;
				SimonGame.numPos = comp;
				timer = 0;
		   }   
		   else
		   {
				compAngles();
				for (int l = 0; l < 7; l++) {
				}
					
				if (rec_Postion() == -1)
			   {
				   timer = 0;
			   }
				else if (rec_Postion() == comp)
			   {
				   timer += Time.deltaTime;
			   }
				else
			   {
				   comp = rec_Postion();
				   timer = 0;
			   }
		   }
	   }
	}

	
	private void compAngles(){
		// on prend les angles en s'eloignant du torse
		Vector3 v1,v2;
		//epauleG
		v1 = (poitrine.transform.position - epauleG.transform.position);
		v2 = (epauleG.transform.position - coudeG.transform.position);
		currAngle[0] = (int)(Mathf.Round((Mathf.Atan2(v2.z,v2.y) - Mathf.Atan2(v1.z,v1.y)) * Mathf.Rad2Deg / coef));
		//coudeG
		v1 = (epauleG.transform.position - coudeG.transform.position);
		v2 = (coudeG.transform.position - mainG.transform.position);
		currAngle[1] = (int)(Mathf.Round((Mathf.Atan2(v2.z,v2.y) - Mathf.Atan2(v1.z,v1.y)) * Mathf.Rad2Deg / coef));
		//epauleD
		v1 = (poitrine.transform.position - epauleD.transform.position);
		v2 = (epauleD.transform.position - coudeD.transform.position);
		currAngle[2] = (int)(Mathf.Round((Mathf.Atan2(v2.z,v2.y) - Mathf.Atan2(v1.z,v1.y)) * Mathf.Rad2Deg / coef));
		//coudeD
		v1 = (epauleD.transform.position - coudeD.transform.position);
		v2 = (coudeD.transform.position - mainD.transform.position);
		currAngle[3] = (int)(Mathf.Round((Mathf.Atan2(v2.z,v2.y) - Mathf.Atan2(v1.z,v1.y)) * Mathf.Rad2Deg / coef));
		//hancheG
		v1 = (poitrine.transform.position - ventre.transform.position);
		v2 = (ventre.transform.position - genouG.transform.position);
		currAngle[4] = (int)(Mathf.Round((Mathf.Atan2(v2.z,v2.y) - Mathf.Atan2(v1.z,v1.y)) * Mathf.Rad2Deg / coef));
		//genouG
		v1 = (ventre.transform.position - genouG.transform.position);
		v2 = (genouG.transform.position - piedG.transform.position);
		currAngle[5] = (int)(Mathf.Round((Mathf.Atan2(v2.z,v2.y) - Mathf.Atan2(v1.z,v1.y)) * Mathf.Rad2Deg / coef));
		//hancheD
		v1 = (poitrine.transform.position - ventre.transform.position);
		v2 = (ventre.transform.position - genouD.transform.position);
		currAngle[6] = (int)(Mathf.Round((Mathf.Atan2(v2.z,v2.y) - Mathf.Atan2(v1.z,v1.y)) * Mathf.Rad2Deg / coef));
		//genouG
		v1 = (ventre.transform.position - genouD.transform.position);
		v2 = (genouD.transform.position - piedD.transform.position);
		currAngle[7] = (int)(Mathf.Round((Mathf.Atan2(v2.z,v2.y) - Mathf.Atan2(v1.z,v1.y)) * Mathf.Rad2Deg / coef));	
	}
	
	public int rec_Postion()
	{
		int recon = -1;
		int j=-1,i=0;
		
		while (j<3 && recon==-1)
		{
			j++;
			recon=j;
			i=0;
			while (recon==j && i<8)
			{
				if(Mathf.Abs(positionAngles[j,i]-currAngle[i])>1)
				{
					recon=-1;
				}
				i++;
			}
		}
		return recon;
	}
	
/*	public void diff(Vector3[] Tab1, Vector3[] Tab2, Vector3[] Tab3, int size){
		
		for(int i=0;i<size;i++){
			Tab3[i]=Tab1[i]-Tab2[i];
		}
	}
	public void copyTab(Vector3[] Tab1, Vector3[] Tab2,int size){
		
		for(int i=0;i<size;i++){
			Tab2[i]=Tab1[i];
		}
	}

*/

	/* Matrices de Kalmann
	private float[,] A = {{1,0,1,0},{0,1,0,1},{0,0,1,0},{0,0,0,1}}; // On ne mutiplie pas par deltaTime ici car on ne divise pas dans le calcul de la vitesse
	//private float[,] H = Matrix4x4.identity;
	/*private float[][] R = ; valeurs à choisir*/
	/*private float[][] Q = ; valeurs à choisir*/ 

}