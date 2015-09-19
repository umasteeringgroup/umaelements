using UnityEngine;
using UMAElements;
using UMA;

public class Example : MonoBehaviour
{
	public RuntimeAnimatorController animController;

	private HumanoidStructure human, humanf;
	private GameObject myuma, myumaf;

	void Start()
	{
		// let's start by initialising the builder with the atlas scale of half		
		HumanoidBuilder.Initialize(1.0f);
		
		// now let's generate a humanoid male
		human = new HumanoidStructure('M');
	
		// set the basic body slots.
		// Use color indexes from the GamePalette.cs
		HumanoidStructure.BodyAdd(human, "Human Male Eyes 01");
		HumanoidStructure.BodyAdd(human, "Human Male Head 01", 4);
		HumanoidStructure.BodyAdd(human, "Human Male HeadEars 01", 4);
		HumanoidStructure.BodyAdd(human, "Human Male HeadEyes 01", 4);
		HumanoidStructure.BodyAdd(human, "Human Male HeadMouth 01", 4);
		HumanoidStructure.BodyAdd(human, "Human Male HeadNose 01", 4);
		HumanoidStructure.BodyAdd(human, "Human Male Head InnerMouth");
		HumanoidStructure.BodyAdd(human, "Human Male Torso 01", 4);
		HumanoidStructure.BodyAdd(human, "Human Male Hands 01", 4);
		HumanoidStructure.BodyAdd(human, "Human Male Legs 01", 4);
		HumanoidStructure.BodyAdd(human, "Human Male Feet 01", 4);
		
		// let's add some clothing
		HumanoidStructure.WardrobeAdd(human, "Male Jeans 01", 12);
		HumanoidStructure.WardrobeAdd(human, "MaleShirt 01", 1);
	
		// just a test of packing a human ( just a proof it all works)
		string testpack = HumanoidStructure.Pack(human);
		Debug.Log(testpack);
		Debug.Log("Pack size " + testpack.Length);
		
		// now lets unpack and generate the uma (we're using the packed version just to show that packing/unpacking works)
		HumanoidStructure testhuman = HumanoidStructure.Unpack(testpack);
		myuma = HumanoidBuilder.Create(testhuman, "myumaM", animController, new Vector3(0.5f, 0, 0) , 0, false, true);

		//Set up a callback thats run when UMA has finished loading
		myuma.GetComponent<UMAData>().OnCharacterCreated += UMAMaleFinished;

		// now let's generate a humanoid female
		humanf = new HumanoidStructure('F');
	
		// you can add tails, horns, eyelashes, etc after these basics
		// but the build order is vital to keep attachment vertex indecies
		// This time we use Color32 to set the color instead.
		HumanoidStructure.BodyAdd(humanf, "Human Female Eyes 01");
		HumanoidStructure.BodyAdd(humanf, "Human Female Head 01", new Color32(188, 188, 188, 255));
		HumanoidStructure.BodyAdd(humanf, "Human Female HeadEars 01", new Color32(188, 188, 188, 255));
		HumanoidStructure.BodyAdd(humanf, "Human Female HeadEyes 01", new Color32(188, 188, 188, 255));
		HumanoidStructure.BodyAdd(humanf, "Human Female HeadMouth 01", new Color32(188, 188, 188, 255));
		HumanoidStructure.BodyAdd(humanf, "Human Female HeadNose 01", new Color32(188, 188, 188, 255));
		HumanoidStructure.BodyAdd(humanf, "Human Female Head InnerMouth");
		HumanoidStructure.BodyAdd(humanf, "Human Female Torso 01", new Color32(188, 188, 188, 255));
		HumanoidStructure.BodyAdd(humanf, "Human Female Hands 01", new Color32(188, 188, 188, 255));
		HumanoidStructure.BodyAdd(humanf, "Human Female Legs 01", new Color32(188, 188, 188, 255));
		HumanoidStructure.BodyAdd(humanf, "Human Female Feet 01", new Color32(188, 188, 188, 255));
		
		// let's add some clothing
		HumanoidStructure.WardrobeAdd(humanf, "MaleShirt 01", 2);

		// just a test of packing a human ( just a proof it all works)
		string testpackf = HumanoidStructure.Pack(humanf);
		Debug.Log(testpackf);
		Debug.Log("Pack size " + testpackf.Length);
		
		// now lets unpack and generate the uma
		HumanoidStructure testhumanf = HumanoidStructure.Unpack(testpackf);
		myumaf = HumanoidBuilder.Create(testhumanf, "myumaF", animController, new Vector3(-0.5f, 0, 0), 0, false, true);

		//Set up a callback thats run when UMA has finished loading
		myumaf.GetComponent<UMAData>().OnCharacterCreated += UMAFemaleFinished;
	}

	//When UMA has finished loaded:
	private void UMAMaleFinished(UMAData umaData)
	{
		// and finally lets give him a sword
		HumanoidStructure.AttachmentsAdd(human, "Item AngelicSword 01");
		// activate his sword
		HumanoidStructure.AttachmentSetActive(human, "Item AngelicSword 01");
		// Update UMA
		HumanoidBuilder.Update(myuma.name, human, false, false);
	}

	//When UMA has finished loaded:
	private void UMAFemaleFinished(UMAData umaData)
	{
		// and finally lets give him a sword
		HumanoidStructure.AttachmentsAdd(humanf, "Item AngelicSword 01");
		// activate his sword
		HumanoidStructure.AttachmentSetActive(humanf, "Item AngelicSword 01");
		// Update UMA
		HumanoidBuilder.Update(myumaf.name, humanf, false, false);
	}

	void Update()
	{
		// holster/ready weapon
		if(Input.GetKeyUp(KeyCode.Z))
		{
			if(HumanoidStructure.AttachcmentIsActive(human, "Item AngelicSword 01"))
			{
				HumanoidStructure.AttachmentSetDefault(human, "Item AngelicSword 01");
			} else {
				HumanoidStructure.AttachmentSetActive(human, "Item AngelicSword 01");
			}
			HumanoidBuilder.Update(myuma.name, human, false, false);
		}
		
		// toggle trousers with recoloring
		if(Input.GetKeyUp(KeyCode.X))
		{
			if(HumanoidStructure.WardrobeHasElement(human, "Male Jeans 01"))
			{
				HumanoidStructure.WardrobeRemove(human, "Male Jeans 01");
			} 
			else 
			{
				int c1 = Random.Range(1, 20);
				HumanoidStructure.WardrobeAdd(human, "Male Jeans 01", c1);
			}
			HumanoidBuilder.Update(myuma.name, human, true, false);
		}
		
		// change chainmail dye colors
		if(Input.GetKeyUp(KeyCode.C))
		{
			HumanoidStructure.WardrobeRemove(human, "MaleShirt 01");
			int c1 = Random.Range(1,20);
			int c2 = Random.Range(1,20);
			int c3 = Random.Range(1,20);
			HumanoidStructure.WardrobeAdd(human, "MaleShirt 01", c1, c2, c3);
			HumanoidBuilder.Update(myuma.name, human, true, false);
		}
	}
}
