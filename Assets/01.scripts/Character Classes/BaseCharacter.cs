using UnityEngine;
using System.Collections;
using System;					// added to access the enum class

public class BaseCharacter : MonoBehaviour {
	
	private string _name;
	private int _level;
	private uint _freeExp;

	private Attribute[] _primaryAttribute;
	private Vital[] _vital;
	private Skill[] _skill;
	
	public void Awake(){
		_name = string.Empty;
		_level = 0;
		_freeExp = 0;
		
		_primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		_vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];
		
		SetupPrimaryAttributes();
		SetupVitals();
		SetupSkills();
	}
	
	public string Name{
		get{ return _name; }
		set{ _name = value; }
	}
	
	public int level{
		get{ return _level; }
		set{ _level = value; }
	}
	
	public uint freeExp{
		get{ return _freeExp; }
		set{ _freeExp = value; }
	}
	
	public void AddExp(uint exp){
		_freeExp += exp;
		CalculateLevel();
	}
	
	// Take average of all of the players skills and assign that as the player level
	public void CalculateLevel(){
		
	}
	
	private void SetupPrimaryAttributes(){
		for(int cnt = 0; cnt < _primaryAttribute.Length; cnt++)
			_primaryAttribute[cnt] = new Attribute();
	}

	private void SetupVitals(){
		for(int cnt = 0; cnt < _vital.Length; cnt++)
			_vital[cnt] = new Vital();
		
		setupVitalModifiers ();
		
	}
	
	private void SetupSkills(){
		for(int cnt = 0; cnt < _skill.Length; cnt++)
			_skill[cnt] = new Skill();

		setupSkillModifiers ();
	}	
	
	public Attribute GetPrimaryAttribute (int index) {
		return _primaryAttribute[index];
	}
	
	public Vital GetVital(int index) {
		return _vital[index];
	}
	
	public Skill GetSkill(int index) {
		return _skill[index];
	}
	
	private void setupVitalModifiers(){
		// health
		GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), .5f));
		
		// energy
		GetVital((int)VitalName.Energy).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), 1));
		
		// mana
		GetVital((int)VitalName.Mana).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 1));
		
	}
	
	private void setupSkillModifiers(){
		// Melee offence
		GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Might), .33f));
		GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), .33f));
		
		// Melee defence
		GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), .33f));
		
		// Magic offence
		GetSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
		GetSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), .33f));
		
		// Magic defence
		GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
		GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), .33f));
		
		// Ranged offence
		GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
		GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		
		// Ranged defence
		GetSkill((int)SkillName.Ranged_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		GetSkill((int)SkillName.Ranged_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), .33f));
		
		
	}
	
	public void StatUpdate(){
		for(int cnt = 0; cnt < _vital.Length; cnt++)
			_vital[cnt].Update();
		
		for(int cnt = 0; cnt < _skill.Length; cnt++)
			_skill[cnt].Update();

	}
	
}
