using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class Scene2_NoticeBoard_VR : MonoBehaviour {

	// Use this for initialization
	public string Destination; 
	public string craftname;

	public Button currentStatus; //default setting
	public Button NextStatus;

	public Text infoBox;
	public Text MenuTitle; 
	public Text WarningBox;



	//private variables
	private int currentcount =1;
	private int nextcount =1;

	private AudioSource notificationvoice;//Audio Source 


	private Dictionary<int,string> statusMap;
	private Dictionary<int,string> warningMap;
	private Dictionary<int,string> instrMap;
    


		void Start() {
		    UnityEngine.XR.XRSettings.enabled = false;
		    Destination = "Planet IDA";
		    craftname="USS-Valkyrie";
		    currentStatus.name = "Current Status";
		    NextStatus.name = "Next Instruction";
		    notificationvoice = GetComponent<AudioSource>();
		   // Initlaize Dictionary
			statusMap = new Dictionary<int,string>{ 
			    {1,"Starting your mission to " +Destination},{2,"Leaving Earth's Orbit.... " +Destination},
			    {3, "Approaching Moon....."},
				{4, "Approaching Mars....."},{5,"Approaching Tesla Roadster...."},
				{6,"Approaching Jupiter....."},
				{7, "WARNING !! WARNING !! "+craftname+" Out Of Control. AutoPilot Not Operable!!"},
			    {8, "New path calculated. Approaching Saturn,Uranus,Neptune"}

			};
		  
			warningMap= new Dictionary<int,string>{ 
				{1,"Possible Anamolies detected on your path to "+Destination},
				{6,"Warning: AutoPilot Failing...."},
				{7,"Hit the big RED Button for help.\n"+craftname+" entering atmosphere in 5 minutes."}
			};

			instrMap = new Dictionary<int,string> { 
			    {1,"Integrity Check Complete.Please Proceed with Caution."},
				{6,"Pilot must take over control,if Autopilot fails."},
			    {7,"!!!Hit the big RED Button for help!!!"},

			};
			
		   //Set Default Texts
			MenuTitle.text= craftname+" : FlightPlan\n\n"+ "Deliver critical Equipments to "+ Destination +
			               " located at the edge of MilkyWay Galaxy."; // Mission Statement

		    infoBox.text = "\n Welcome Aboard " + craftname + ".\n" + "You will be notified with further instructions";
		    WarningBox.text="";

			//Set Font,Font size and Color.
		    MenuTitle.color=Color.cyan;
			infoBox.color = Color.green;
			WarningBox.color=Color.yellow;


			//Add Listeners		   
			currentStatus.onClick.AddListener(()=>GetCurrentStatus());
			NextStatus.onClick.AddListener(()=>FetchNextInstruction());
		}

		void update() {}

	   /* Needs to be called by external GAme Object like SpaceCraft when it reaches a particular Marker
	    * REfer to statusMap initalization for status information 
	    * which will give you an idea at what markers,this method needs to be called 
	    */ 
		public void UpdateCurrentStatus(){
		if(currentcount<= statusMap.Count)  currentcount++;
		    notificationvoice.Play(0);
			GetCurrentStatus();

		}

		public void ResetSceneStatus(int resetToindex){
			if( !statusMap.ContainsKey(resetToindex) )
			{
				Debug.Log("NoticeBoard.ResetSceneStatus():Invalid Reset Index assigned ="+ resetToindex);
				Debug.Log("Index must be in range 1 to "+statusMap.Count);
				return;
			} 
			currentcount = resetToindex;
			GetCurrentStatus();

		}

	    // Called when NextStatus button is clicked. 
		private void FetchNextInstruction() {

			while(nextcount<=instrMap.Count)
			{
				nextcount++;
				if(instrMap.ContainsKey(nextcount)) {
				    notificationvoice.Play(0);
					if(nextcount==7) 
						infoBox.color=Color.red;
					else
						infoBox.color=Color.green;
					infoBox.text = "\n"+"INSTRUCTION: "+ instrMap[nextcount];

					return;
				}
			}


		}
	   
	   // Called when Current Status button is clicked.
	private void GetCurrentStatus() {
			nextcount = currentcount;
			string instruction="";

		  if(currentcount>statusMap.Count) {
				Debug.Log("No more status Updates available");
				infoBox.text = "\n STATUS: No Further anamolies detected on your path. Enjoy Rest of your journey to "+Destination;
				return;
		    }
			if (!instrMap.ContainsKey (nextcount)) {
				instruction = "No immediate threats detected.No action needs to be taken.";
			}
			else 
				instruction = instrMap[nextcount];

			if(nextcount==7) {
				infoBox.color=Color.red;
				WarningBox.color=Color.red;
			}
			else{
				infoBox.color=Color.green;
				WarningBox.color=Color.yellow;
			}
			infoBox.text = "\n"+"STATUS: "+statusMap[currentcount]+"\n\n"+"INSTRUCTION: "+instruction;

		 	if (!warningMap.ContainsKey(currentcount))
				WarningBox.text = "";
			else
				WarningBox.text = warningMap [currentcount];
		}

		



}
