using UnityEngine;
using System.Collections;


public class Postures {
	private bool searching;
	private int coef = 10;
	private float timer, limit = 1000;
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

	private Vector3[,] Corps = new Vector3[4,12];

	/*private Vector3[][] corps =
	{
		{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0), new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
		{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0), new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
		{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0), new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0), new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
		{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0), new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)}
	};*/
	
	// Ordre des angles : Epaule G , Coude G , Epaule D, Coude D, Hanche G, Jenou G, Hanche D, Jenou D
	private int[,] positionAngles = {{0,0,0,0,0,0,0,0},{1,1,1,1,1,1,1,1},{20,20,20,20,20,20,20,20},{70,70,70,70,70,70,70,70}};
	private int[] currAngle = {0,0,0,0,0,0,0,0};
	
	// Matrices de Kalmann
	private float[,] A = {{1,0,1,0},{0,1,0,1},{0,0,1,0},{0,0,0,1}}; // On ne mutiplie pas par deltaTime ici car on ne divise pas dans le calcul de la vitesse
	//private float[,] H = Matrix4x4.identity;
	/*private float[][] R = ; valeurs à choisir*/
	/*private float[][] Q = ; valeurs à choisir*/ 
	
	
	public void FixedUpdate(){
	   if (searching)
	   {
		   if (timer > limit)
		   {
				/*Posture identifié et tenu, interractions je fais quoi ? */
		   }   
		   else
		   {
				updatePositions();
				compAngles();
				int comp = rec_Postion();
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
	
	private void updatePositions()
	{
		//copyTab(Corps[1],Corps[2],12); copy int ind 1 ind 2 taille
		//copyTab(Corps[0],Corps[1],12);
		//diff(Corps[1],Corps[2],Corps[3],12);
		/*
		poitrine = Vector3(kinnect.poitrine.x, kinnect.poitrine.y,0);
		ventre = ;
		epauleG = ; 
		epauleD = ;
		coudeG  = ; 
		coudeD = ;
		genouG = ;
		genouD = ; 
		piedD = ;
		piedG = ;
		*/
		
		/* Kalmanisation de Hamza */

	}
	
	private void compAngles(){
		// on prend les angles en s'eloignant du torse
		Vector3 v1,v2;
		//epauleG
		/*v1 = (poitrine.transform.position - epauleG);
		v2 = (epauleG - coudeG);
		currAngle[0] = Mathf.Round((Mathf.Atan2(v2.x,v2.y) - Mathf.Atan2(v1.x,v1.y)) * Mathf.Rad2Deg / coef);
		//coudeG
		v1 = (epauleG - coudeG);
		v2 = (coudeG - mainG);
		currAngle[1] = Mathf.Round((Mathf.Atan2(v2.x,v2.y) - Mathf.Atan2(v1.x,v1.y)) * Mathf.Rad2Deg / coef);
		//epauleD
		v1 = (poitrine - epauleD);
		v2 = (epauleD - coudeD);
		currAngle[2] = Mathf.Round((Mathf.Atan2(v2.x,v2.y) - Mathf.Atan2(v1.x,v1.y)) * Mathf.Rad2Deg / coef);
		//coudeD
		v1 = (epauleD - coudeD);
		v2 = (coudeD - mainD);
		currAngle[3] = Mathf.Round((Mathf.Atan2(v2.x,v2.y) - Mathf.Atan2(v1.x,v1.y)) * Mathf.Rad2Deg / coef);
		//hancheG
		v1 = (poitrine - ventre);
		v2 = (ventre - genouG);
		currAngle[4] = Mathf.Round((Mathf.Atan2(v2.x,v2.y) - Mathf.Atan2(v1.x,v1.y)) * Mathf.Rad2Deg / coef);
		//genouG
		v1 = (ventre - genouG);
		v2 = (genouG - piedG);
		currAngle[5] = Mathf.Round((Mathf.Atan2(v2.x,v2.y) - Mathf.Atan2(v1.x,v1.y)) * Mathf.Rad2Deg / coef);
		//hancheD
		v1 = (poitrine - ventre);
		v2 = (ventre - genouD);
		currAngle[6] = Mathf.Round((Mathf.Atan2(v2.x,v2.y) - Mathf.Atan2(v1.x,v1.y)) * Mathf.Rad2Deg / coef);
		//genouG
		v1 = (ventre - genouD);
		v2 = (genouD - piedD);
		currAngle[7] = Mathf.Round((Mathf.Atan2(v2.x,v2.y) - Mathf.Atan2(v1.x,v1.y)) * Mathf.Rad2Deg / coef);	*/	
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
				if(positionAngles[j,i]!=currAngle[i])
				{
					recon=-1;
				}
				i++;
			}
		}
		return recon;
	}
	
	public void diff(Vector3[] Tab1, Vector3[] Tab2, Vector3[] Tab3, int size){
		
		for(int i=0;i<size;i++){
			Tab3[i]=Tab1[i]-Tab2[i];
		}
	}
	public void copyTab(Vector3[] Tab1, Vector3[] Tab2,int size){
		
		for(int i=0;i<size;i++){
			Tab2[i]=Tab1[i];
		}
	}
	
	
}